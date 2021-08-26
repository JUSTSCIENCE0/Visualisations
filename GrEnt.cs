using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Visualisations
{
    class GrPoint
    {
        //main
        public int id;
        public List<int> Connections;

        //graphics
        public  Point position;
        public  bool mouseDowned;
        private Point mouseOffset;
        private Pen BluePen = new Pen(Color.Blue, 3);
        private Pen YellowPen = new Pen(Color.Yellow, 3);
        private Font font = new Font("Arial", 20);
        private string state;

        public GrPoint(int ID, int x, int y)
        {
            id = ID;
            Connections = new List<int>();
            state = "Moving";
            position.X = x;
            position.Y = y;
            mouseDowned = false;
            mouseOffset.X = 0;
            mouseOffset.Y = 0;
        }

        public void Connect(GrPoint another)
        {
            int check = Connections.Find(num => num == another.id);
            if (check == 0)
                Connections.Add(another.id);
            check = another.Connections.Find(num => num == id);
            if (check == 0)
                another.Connections.Add(id);
        }

        public void Disconnect(GrPoint another)
        {
            Connections.Remove(another.id);
            another.Connections.Remove(id);
        }

        public void Draw(PaintEventArgs e)
        {
            Brush brush;
            Pen pen;
            switch (state)
            {
                case "Moving":
                    brush = Brushes.LightBlue;
                    pen = BluePen;
                    break;
                case "Connecting":
                    brush = Brushes.LightYellow;
                    pen = YellowPen;
                    break;
                default:
                    brush = Brushes.LightBlue;
                    pen = BluePen;
                    break;
            }

            e.Graphics.FillEllipse(brush, position.X - 25, position.Y - 25, 50, 50);
            e.Graphics.DrawEllipse(pen, position.X - 25, position.Y - 25, 50, 50);
            e.Graphics.DrawString(id.ToString("D3"), font, Brushes.Blue, position.X - 25, position.Y - 15);
        }

        public bool CheckPosition(int x, int y)
        {
            if (x < position.X + 25 && x > position.X - 25)
                if (y < position.Y + 25 && y > position.Y - 25)
                {
                    mouseOffset.X = position.X - x;
                    mouseOffset.Y = position.Y - y;
                    return true;
                }
            return false;
        }

        public void MoveToCursor(int x, int y)
        {
            position.X = x + mouseOffset.X;
            position.Y = y + mouseOffset.Y;
        }

        public void SetState(string st)
        {
            state = st;
        }
    }

    class GrConnection
    {
        //main
        public int id;
        public Point hosts;
        public Point First;
        public Point Second;
        public int weight;

        //graphics
        private Pen BluePen = new Pen(Color.Blue, 5);
        private Pen YellowPen = new Pen(Color.Yellow, 5);
        private Font font = new Font("Arial", 15);
        private string state;

        public GrConnection(int ID, GrPoint frst, GrPoint scnd)
        {
            id = ID;
            hosts.X = frst.id;
            hosts.Y = scnd.id;
            First = frst.position;
            Second = scnd.position;
            state = "Stand";
            weight = 1;
        }

        public void UpdatePosition(Point frst, Point scnd)
        {
            First = frst;
            Second = scnd;
        }

        public bool CheckHost(int id)
        {
            if (hosts.X == id || hosts.Y == id)
                return true;
            else
                return false;
        }

        public void Draw(PaintEventArgs e)
        {
            Pen pen;
            switch (state)
            {
                case "Stand":
                    pen = BluePen;
                    break;
                case "Pick":
                    pen = YellowPen;
                    break;
                default:
                    pen = BluePen;
                    break;
            }
            e.Graphics.DrawLine(pen, First, Second);
            Point center = GetCenter();
            e.Graphics.DrawString(weight.ToString(), font, Brushes.Green, center.X - 6, center.Y - 25);
        }

        public void SetState(string st)
        {
            state = st;
        }

        public bool CheckPosition(int x, int y)
        {
            double dist = Distanse(x, y);
            if (dist <= 7)
                return true;
            else
                return false;
        }

        private double Distanse(int x0, int y0)
        {
            int x1 = First.X;
            int y1 = First.Y;
            int x2 = Second.X;
            int y2 = Second.Y;
            double triangle = (y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1;
            double distanse = Math.Sqrt((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1));
            return Math.Abs(triangle) / distanse;
        }

        private Point GetCenter()
        {
            Point center = new Point();
            int x1 = First.X;
            int y1 = First.Y;
            int x2 = Second.X;
            int y2 = Second.Y;
            center.X = (x1 + x2) / 2;
            center.Y = (y1 + y2) / 2;
            return center;
        }
    }

    class DijkstraPoint
    {
        public int id;
        public int distance;
        public List<int> ConnIDs;
        public bool visited;

        public DijkstraPoint(int ID)
        {
            id = ID;
            distance = Int32.MaxValue;
            ConnIDs = new List<int>();
            visited = false;
        }

        public void SetVisited(bool visit)
        {
            visited = visit;
        }

        public void SetDistance(int dist)
        {
            distance = dist;
        }

        public void SetPath(List<int> conns, int add)
        {
            ConnIDs = new List<int>();
            for (int i=0; i<conns.Count; i++)
            {
                ConnIDs.Add(conns[i]);
            }
            ConnIDs.Add(add);
        }
    }

    class GrDijkstra
    {
        private List<DijkstraPoint> points;
        private List<GrConnection> connections;
        private int main;

        public GrDijkstra(List<GrPoint> pnts, List<GrConnection> conns, int mainID)
        {
            points = new List<DijkstraPoint>();
            connections = conns;
            main = mainID;

            for(int i=0; i<pnts.Count; i++)
            {
                DijkstraPoint newPnt = new DijkstraPoint(pnts[i].id);
                if (pnts[i].id == mainID)
                {
                    newPnt.distance = 0;
                    //newPnt.visited = true;
                }
                points.Add(newPnt);
            }
        }

        public List<int> GetShortestPath(int id)
        {
            Calculate();
            DijkstraPoint pnt = points.Find(ent => ent.id == id);
            return pnt.ConnIDs;
        }

        private void Calculate()
        {
            while (points.Find(ent => !ent.visited) != null)
            {
                int indx = FindNear();
                List<GrConnection> cons = connections.FindAll(ent => ent.CheckHost(points[indx].id));
                for (int i = 0; i < cons.Count; i++)
                {
                    int anouther;
                    if (cons[i].hosts.X == points[indx].id)
                        anouther = cons[i].hosts.Y;
                    else
                        anouther = cons[i].hosts.X;
                    int anIndx = points.FindIndex(ent => ent.id == anouther);
                    int dist = points[indx].distance + cons[i].weight;
                    if (points[anIndx].distance > dist)
                    {
                        points[anIndx].SetDistance(dist);
                        points[anIndx].SetPath(points[indx].ConnIDs, cons[i].id);
                    }
                }

                points[indx].SetVisited(true);
            }
        }

        private int FindNear()
        {
            DijkstraPoint near = new DijkstraPoint(0);
            int itrt = 0;
            for (int i=0; i<points.Count; i++)
            {
                if (!points[i].visited)
                {
                    if (near.distance > points[i].distance)
                    {
                        near = points[i];
                        itrt = i;
                    }
                }
            }

            return itrt;
        }
    }
}
