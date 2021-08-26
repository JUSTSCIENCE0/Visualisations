using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Visualisations
{
    public partial class MainForm : Form
    {
        List<GrPoint> points;
        List<GrConnection> connections;
        GrDijkstra calculator;
        int numPoints;
        int numConn;
        int currentMouse;

        StBubbleSort    sortBubble;
        StInsertSort    sortInsert;
        StMergeSort     sortMerge;
        StSelectionSort sortSelection;
        StCombSort      sortComb;
        StFastSort      sortFast;
        StShellSort     sortShell;
        Thread thread;

        FPSCalculator monitor;
        string CurrentAction;
        string currentSort;

        string phAction;
        bool calcPhisics;
        Point phBase;
        int curBody;
        List<PhBody> bodies;
        DateTime calcPoint;
        PhVector PhG = new PhVector(0, 1, Color.Black);

        DrEnt drawEnt;
        int DrXC, DrYC;
        float RotX, RotY, RotZ;

        Dr4DEnt draw4DEnt;
        //float RotXY, RotYZ, RotXZ, RotXD, RotYD, RotZD;

        public MainForm()
        {
            InitializeComponent();
            monitor = new FPSCalculator();
            CurrentAction = "Moving";
            points = new List<GrPoint>();
            connections = new List<GrConnection>();
            numPoints = 0;
            numConn = 0;
            currentMouse = 0;
            currentSort = "";
            
            phAction = "AddSphere";
            bodies = new List<PhBody>();
            butPhPause.Enabled = false;
            calcPhisics = false;
            curBody = -1;
            butAddSphere.Font = new Font(butAddSphere.Font, FontStyle.Bold);

            DrXC = DrPicture.Width / 2;
            DrYC = DrPicture.Height / 2;
            //drawEnt = new DrCube(DrXC, DrYC);
            drawEnt = new DrCilinder(DrXC, DrYC);
            RotX = 0;
            RotY = 0;
            RotZ = 0;

            draw4DEnt = new DrTesserakt(DrXC, DrYC);
            //RotXY = 0;
            //RotXZ = 0;
            //RotYZ = 0;
            //RotXD = 0;
            //RotYD = 0;
            //RotZD = 0;
        }

        private void GrPicture_Paint(object sender, PaintEventArgs e)
        {
            GrPicture.Invalidate();

            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].Draw(e);
            }
            for (int i=0; i<points.Count; i++)
            {
                points[i].Draw(e);
            }

            monitor.DrawFPS(e);
        }

        private void GrPicture_MouseDown(object sender, MouseEventArgs e)
        {
            bool updateInfo = true;
            if (e.Button == MouseButtons.Left)
            {
                GrPoint pnt = points.Find(ent => ent.CheckPosition(e.X, e.Y));
                if (pnt != null)
                {
                    if (CurrentAction == "Moving")
                    {
                        currentMouse = pnt.id;
                        return;
                    }
                    if (CurrentAction == "Connecting")
                    {
                        if (currentMouse == 0)
                        {
                            int indx = points.FindIndex(ent => ent.id == pnt.id);
                            points[indx].SetState("Connecting");
                            currentMouse = pnt.id;
                        }
                        else
                        {
                            int indx1 = points.FindIndex(ent => ent.id == currentMouse);
                            int indx2 = points.FindIndex(ent => ent.id == pnt.id);
                            points[indx1].Connect(points[indx2]);

                            numConn++;
                            GrConnection conn = new GrConnection(numConn, points[indx1], points[indx2]);
                            connections.Add(conn);

                            currentMouse = 0;
                            points[indx1].SetState("Moving");
                        }
                        return;
                    }
                    if (CurrentAction == "Delete")
                    {
                        for (int i=0; i<points.Count; i++)
                        {
                            points[i].Disconnect(pnt);
                        }
                        for (int i=0; i<connections.Count; i++)
                        {
                            if (connections[i].CheckHost(pnt.id))
                            {
                                connections.RemoveAt(i);
                                i--;
                            }
                        }
                        points.Remove(pnt);
                        return;
                    }
                    if (CurrentAction == "FindShortest")
                    {
                        if (currentMouse == 0)
                        {
                            for(int i=0; i<connections.Count; i++)
                            {
                                connections[i].SetState("Stand");
                            }
                            calculator = new GrDijkstra(points, connections, pnt.id);
                            int indx = points.FindIndex(ent => ent.id == pnt.id);
                            currentMouse = pnt.id;
                            points[indx].SetState("Connecting");
                            return;
                        }
                        else
                        {
                            List<int> conns = calculator.GetShortestPath(pnt.id);
                            for (int i=0; i<conns.Count; i++)
                            {
                                int indx = connections.FindIndex(ent => ent.id == conns[i]);
                                connections[indx].SetState("Pick");
                            }
                            int indx1 = points.FindIndex(ent => ent.id == currentMouse);
                            points[indx1].SetState("Moving");
                            currentMouse = 0;
                            return;
                        }
                    }
                }

                GrConnection con = connections.Find(ent => ent.CheckPosition(e.X, e.Y));
                if (con != null)
                {
                    if (CurrentAction == "Disconnecting")
                    {
                        Point hosts = con.hosts;
                        connections.Remove(con);
                        int host_indx = points.FindIndex(ent => ent.id == hosts.X);
                        points[host_indx].Connections.Remove(hosts.Y);
                        host_indx = points.FindIndex(ent => ent.id == hosts.Y);
                        points[host_indx].Connections.Remove(hosts.X);
                        return;
                    }
                    if (CurrentAction == "SetWeights")
                    {
                        int indx = connections.FindIndex(ent => ent.id == con.id);
                        connections[indx].weight++;
                        return;
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                GrPoint pnt = points.Find(ent => ent.CheckPosition(e.X, e.Y));
                if (pnt != null)
                {
                    if (CurrentAction == "Moving")
                    {
                        string message = "Point" + Environment.NewLine;
                        message += "id = " + pnt.id + Environment.NewLine;
                        message += "Connections: " + Environment.NewLine;
                        for(int i=0; i<pnt.Connections.Count; i++)
                        {
                            message += (i+1).ToString() + ": with " + pnt.Connections[i].ToString() + Environment.NewLine;
                        }
                        DebugText.Text = message;
                        updateInfo = false;
                        return;
                    }
                }
                
                GrConnection con = connections.Find(ent => ent.CheckPosition(e.X, e.Y));
                if (con != null)
                {
                    if (CurrentAction == "Moving")
                    {
                        string message = "Connection line" + Environment.NewLine;
                        message += "id = " + con.id + Environment.NewLine;
                        message += "Connect " + con.hosts.X + " with " + con.hosts.Y;
                        if (updateInfo)
                            DebugText.Text = message;

                        return;
                    }
                    if (CurrentAction == "SetWeights")
                    {
                        int indx = connections.FindIndex(ent => ent.id == con.id);
                        connections[indx].weight--;
                        return;
                    }
                }
            }
            DebugText.Text = "";
        }

        private void GrPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                if (currentMouse != 0)
                {
                    int indx = points.FindIndex(ent => ent.id == currentMouse);
                    points[indx].MoveToCursor(e.X, e.Y);
                    for (int i=0; i<connections.Count; i++)
                    {
                        if (connections[i].CheckHost(currentMouse))
                        {
                            if (connections[i].hosts.X == currentMouse)
                                connections[i].First = points[indx].position;
                            else
                                connections[i].Second = points[indx].position;
                        }
                    }
                }
            }
        }

        private void GrPicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                currentMouse = 0;
            }
        }

        private void AddPoint_Click(object sender, EventArgs e)
        {
            numPoints++;
            GrPoint pnt = new GrPoint(numPoints, 200, 200);
            points.Add(pnt);
        }

        private void ConnectPoints_Click(object sender, EventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                currentMouse = 0;
                CurrentAction = "Connecting";
                ConnectPoints.Text = "Cancel";

                return;
            }
            if (CurrentAction == "Connecting")
            {
                if (currentMouse != 0)
                {
                    int indx = points.FindIndex(ent => ent.id == currentMouse);
                    points[indx].SetState("Moving");
                }
                currentMouse = 0;
                CurrentAction = "Moving";
                ConnectPoints.Text = "ConnectPoints";

                return;
            }
        }

        private void DisconnectPoints_Click(object sender, EventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                currentMouse = 0;
                CurrentAction = "Disconnecting";
                DisconnectPoints.Text = "Cancel";

                return;
            }
            if (CurrentAction == "Disconnecting")
            {
                currentMouse = 0;
                CurrentAction = "Moving";
                DisconnectPoints.Text = "Delete Connection";

                return;
            }
        }

        private void SetWeights_Click(object sender, EventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                currentMouse = 0;
                CurrentAction = "SetWeights";
                SetWeights.Text = "Cancel";

                return;
            }
            if (CurrentAction == "SetWeights")
            {
                currentMouse = 0;
                CurrentAction = "Moving";
                SetWeights.Text = "Set Weights";

                return;
            }
        }

        private void DeletePoint_Click(object sender, EventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                currentMouse = 0;
                CurrentAction = "Delete";
                DeletePoint.Text = "Cancel";

                return;
            }
            if (CurrentAction == "Delete")
            {
                currentMouse = 0;
                CurrentAction = "Moving";
                DeletePoint.Text = "Delete Point";

                return;
            }
        }

        private void SaveGraph_Click(object sender, EventArgs e)
        {
            byte sinhro = 0x76;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Graph (*.gph)|*.gph|All files(*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFile.FileName;
            BinaryWriter output = new BinaryWriter(File.Open(filename, FileMode.Create));
            output.Write(sinhro);
            output.Write(points.Count);
            for (int i=0; i < points.Count; i++)
            {
                output.Write(sinhro);
                output.Write(points[i].id);
                output.Write(points[i].position.X);
                output.Write(points[i].position.Y);
                output.Write(sinhro);
                output.Write(points[i].Connections.Count);
                for (int j=0; j<points[i].Connections.Count; j++)
                {
                    output.Write(points[i].Connections[j]);
                }
            }
            output.Write(sinhro);
            output.Write(connections.Count);
            for (int i=0; i < connections.Count; i++)
            {
                output.Write(sinhro);
                output.Write(connections[i].id);
                output.Write(connections[i].hosts.X);
                output.Write(connections[i].hosts.Y);
                output.Write(connections[i].First.X);
                output.Write(connections[i].First.Y);
                output.Write(connections[i].Second.X);
                output.Write(connections[i].Second.Y);
                output.Write(connections[i].weight);
            }
        }

        private void LoadGraph_Click(object sender, EventArgs e)
        {
            byte sinhro = 0x76;
            List<GrPoint> pnts = new List<GrPoint>();
            List<GrConnection> cncts = new List<GrConnection>();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Graph (*.gph)|*.gph|All files(*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFile.FileName;
            BinaryReader input = new BinaryReader(File.Open(filename, FileMode.Open));

            if (input.ReadByte() != sinhro)
            {
                DebugText.Text = "File breaked: invalid sinhro in start";
                return;
            }
            int countPoints = input.ReadInt32();
            if (countPoints < 0)
            {
                DebugText.Text = "File breaked: invalid count";
                return;
            }
            for (int i = 0; i < countPoints; i++)
            {
                if (input.ReadByte() != sinhro)
                {
                    DebugText.Text = "File breaked: invalid sinhro in start point";
                    return;
                }

                int pntID = input.ReadInt32();
                int pntX = input.ReadInt32();
                int pntY = input.ReadInt32();

                if (input.ReadByte() != sinhro)
                {
                    DebugText.Text = "File breaked: invalid sinhro in point connections";
                    return;
                }
                numPoints = pntID;
                GrPoint newPnt = new GrPoint(pntID, pntX, pntY);
                int ConnectionCount = input.ReadInt32();

                if (ConnectionCount < 0)
                {
                    DebugText.Text = "File breaked: invalid count in point connections";
                    return;
                }
                for (int j=0; j< ConnectionCount; j++)
                {
                    newPnt.Connections.Add(input.ReadInt32());
                }
                pnts.Add(newPnt);
            }
            if (input.ReadByte() != sinhro)
            {
                DebugText.Text = "File breaked: invalid sinhro in start connections";
                return;
            }
            int ConnCount = input.ReadInt32();
            if (ConnCount < 0)
            {
                DebugText.Text = "File breaked: invalid count connections";
                return;
            }
            for (int i=0; i<ConnCount; i++)
            {
                if (input.ReadByte() != sinhro)
                {
                    DebugText.Text = "File breaked: invalid sinhro in start connection";
                    return;
                }

                int connID = input.ReadInt32();
                int host1ID = input.ReadInt32();
                int host2ID = input.ReadInt32();
                int host1X = input.ReadInt32();
                int host1Y = input.ReadInt32();
                int host2X = input.ReadInt32();
                int host2Y = input.ReadInt32();
                int weight = input.ReadInt32();
                GrPoint pnt1 = new GrPoint(host1ID, host1X, host1Y);
                GrPoint pnt2 = new GrPoint(host2ID, host2X, host2Y);
                GrConnection newConn = new GrConnection(connID, pnt1, pnt2);
                numConn = connID;
                newConn.weight = weight;
                cncts.Add(newConn);
            }
            points = pnts;
            connections = cncts;
        }

        private void ShortestWay_Click(object sender, EventArgs e)
        {
            if (CurrentAction == "Moving")
            {
                currentMouse = 0;
                CurrentAction = "FindShortest";
                ShortestWay.Text = "Cancel";
                
                return;
            }
            if (CurrentAction == "FindShortest")
            {
                for (int i = 0; i < connections.Count; i++)
                {
                    connections[i].SetState("Stand");
                }
                if (currentMouse != 0)
                {
                    int indx = points.FindIndex(ent => ent.id == currentMouse);
                    points[indx].SetState("Moving");
                }
                currentMouse = 0;
                CurrentAction = "Moving";
                ShortestWay.Text = "Shortest Way";

                return;
            }
        }

        private void StPicture_Paint(object sender, PaintEventArgs e)
        {
            StPicture.Invalidate();

            switch(currentSort)
            {
                case "BubbleSorting":
                    sortBubble.Draw(e);
                    break;
                case "InsertSorting":
                    sortInsert.Draw(e);
                    break;
                case "MergeSorting":
                    sortMerge.Draw(e);
                    break;
                case "SelectionSorting":
                    sortSelection.Draw(e);
                    break;
                case "CombSorting":
                    sortComb.Draw(e);
                    break;
                case "FastSorting":
                    sortFast.Draw(e);
                    break;
                case "ShellSorting":
                    sortShell.Draw(e);
                    break;
                default:
                    break;
            }
        }

        private void butStSortBubble_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortBubble = new StBubbleSort();
            thread = new Thread(sortBubble.Sorting);
            thread.Name = "BubbleSorting";
            thread.Start();
            currentSort = "BubbleSorting";
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
        }

        private void butStSortInsert_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortInsert = new StInsertSort();
            thread = new Thread(sortInsert.Sorting);
            thread.Name = "InsertSorting";
            thread.Start();
            currentSort = "InsertSorting";
        }

        private void butSortMerge_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortMerge = new StMergeSort();
            thread = new Thread(sortMerge.Sorting);
            thread.Name = "MergeSorting";
            thread.Start();
            currentSort = "MergeSorting";
        }

        private void butSortSelection_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortSelection = new StSelectionSort();
            thread = new Thread(sortSelection.Sorting);
            thread.Name = "SelectionSorting";
            thread.Start();
            currentSort = "SelectionSorting";
        }

        private void butCombSort_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortComb = new StCombSort();
            thread = new Thread(sortComb.Sorting);
            thread.Name = "CombSorting";
            thread.Start();
            currentSort = "CombSorting";
        }

        private void butQuickSort_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortFast = new StFastSort();
            thread = new Thread(sortFast.Sorting);
            thread.Name = "FastSorting";
            thread.Start();
            currentSort = "FastSorting";
        }

        private void butShellSort_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.IsAlive)
                    thread.Abort();
            sortShell = new StShellSort();
            thread = new Thread(sortShell.Sorting);
            thread.Name = "ShellSorting";
            thread.Start();
            currentSort = "ShellSorting";
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Tabs.Width = this.Width - 52;
            Tabs.Height = this.Height - 93;

            PhPicture.Width = this.Width - 64;
            PhPicture.Height = this.Height - 37;

            DrPicture.Width = this.Width - 64;
            DrPicture.Height = this.Height - 37;

            pic4D.Width = this.Width - 64;
            pic4D.Height = this.Height - 37;

            DrXC = DrPicture.Width / 2;
            DrYC = DrPicture.Height / 2;
            drawEnt.UpdateCenter(DrXC, DrYC);
            draw4DEnt.UpdateCenter(DrXC, DrYC);
        }

        private void PhPicture_Paint(object sender, PaintEventArgs e)
        {
            PhPicture.Invalidate();

            if (calcPhisics)
            {
                TimeSpan delta = DateTime.Now - calcPoint;
                if (delta.TotalMilliseconds >= 17)
                {
                    //Newton gravity
                    if (PhGrawMode.Value == 1)
                    {
                        for (int i = 0; i < bodies.Count; i++)
                        {
                            for (int j = i+1; j < bodies.Count; j++)
                            {
                                bodies[i].AddGravity(bodies[j]);
                            }
                        }
                    }

                    //gravity down
                    if (PhGrawMode.Value == 2)
                    {
                        for (int i = 0; i < bodies.Count; i++)
                        {
                            bodies[i].AddAcceleration(PhG);
                        }
                    }

                    //move bodies
                    for (int i = 0; i < bodies.Count; i++)
                    {
                        bodies[i].CalcPhisics();

                        //delete far bodies
                        if (bodies[i].CheckPos())
                        {
                            bodies.RemoveAt(i);
                            i--;
                        }
                    }

                    //Delete collisions
                    for (int i = 0; i < bodies.Count; i++)
                    {
                        for (int j = i + 1; j < bodies.Count; j++)
                        {
                            bodies[i].CheckCollision(bodies[j]);
                        }
                    }
                }
            }

            for (int i=0; i<bodies.Count; i++)
            {
                bodies[i].Draw(e, 0);
            }

            monitor.DrawFPS(e);
        }

        private void PhPicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (phAction == "AddSphere")
            {
                PhSphere sphere = new PhSphere((int)(phRadius.Value), (int)(phMass.Value), e.Location);
                bodies.Add(sphere);
                return;
            }
            if (phAction == "AddForce")
            {
                if (curBody != -1)
                {
                    PhVector force = new PhVector(e.X - phBase.X, e.Y - phBase.Y, Color.Black);
                    bodies[curBody].AddForce(10 * force);
                    curBody = -1;
                }
            }
        }

        private void PhPicture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void butPhStart_Click(object sender, EventArgs e)
        {
            butPhStart.Enabled = false;
            butPhPause.Enabled = true;
            calcPhisics = true;
            calcPoint = DateTime.Now;
        }

        private void butPhPause_Click(object sender, EventArgs e)
        {
            butPhStart.Enabled = true;
            butPhPause.Enabled = false;
            calcPhisics = false;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            bodies.Clear();
        }

        private void butAddForce_Click(object sender, EventArgs e)
        {
            phAction = "AddForce";
            butAddSphere.Font = new Font(butAddSphere.Font, FontStyle.Regular);
            butAddForce.Font = new Font(butAddForce.Font, FontStyle.Bold);
        }

        private void butAddSphere_Click(object sender, EventArgs e)
        {
            phAction = "AddSphere";
            butAddSphere.Font = new Font(butAddSphere.Font, FontStyle.Bold);
            butAddForce.Font = new Font(butAddForce.Font, FontStyle.Regular);
        }

        private void DrRotateX_CheckedChanged(object sender, EventArgs e)
        {
            valRotateX.Enabled = !valRotateX.Enabled;
        }

        private void DrRotateY_CheckedChanged(object sender, EventArgs e)
        {
            valRotateY.Enabled = !valRotateY.Enabled;
        }

        private void valRotateY_ValueChanged(object sender, EventArgs e)
        {
            if (!DrRotateY.Checked)
            {
                float diff = (float)valRotateY.Value - RotY;
                drawEnt.RotateY(diff);
                RotY = (float)valRotateY.Value;
            }
        }

        private void DrRotateZ_CheckedChanged(object sender, EventArgs e)
        {
            valRotateZ.Enabled = !valRotateZ.Enabled;
        }

        private void valRotateZ_ValueChanged(object sender, EventArgs e)
        {
            if (!DrRotateZ.Checked)
            {
                float diff = (float)valRotateZ.Value - RotZ;
                drawEnt.RotateZ(diff);
                RotZ = (float)valRotateZ.Value;
            }
        }

        private void drCurFigure_TextChanged(object sender, EventArgs e)
        {
            if (drCurFigure.Text == "Куб")
            {
                drawEnt = new DrCube(DrXC, DrYC);
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                valRotateX.Value = 0;
                valRotateY.Value = 0;
                valRotateZ.Value = 0;
                return;
            }
            if (drCurFigure.Text == "Цилиндр")
            {
                drawEnt = new DrCilinder(DrXC, DrYC);
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                valRotateX.Value = 0;
                valRotateY.Value = 0;
                valRotateZ.Value = 0;
                return;
            }
            if (drCurFigure.Text == "Шар")
            {
                drawEnt = new DrBall(DrXC, DrYC);
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                valRotateX.Value = 0;
                valRotateY.Value = 0;
                valRotateZ.Value = 0;
                return;
            }
            if (drCurFigure.Text == "Тор")
            {
                drawEnt = new DrTor(DrXC, DrYC);
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                valRotateX.Value = 0;
                valRotateY.Value = 0;
                valRotateZ.Value = 0;
                return;
            }
            if (drCurFigure.Text == "Плоскость")
            {
                drawEnt = new DrPlane(DrXC, DrYC);
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                valRotateX.Value = 0;
                valRotateY.Value = 0;
                valRotateZ.Value = 0;
                return;
            }
            if (drCurFigure.Text == "Эллиптический параболоид")
            {
                drawEnt = new DrEllipticalParaboloid(DrXC, DrYC);
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                valRotateX.Value = 0;
                valRotateY.Value = 0;
                valRotateZ.Value = 0;
                return;
            }
        }

        private void pic4D_Paint(object sender, PaintEventArgs e)
        {
            pic4D.Invalidate();
            TimeSpan delta = DateTime.Now - calcPoint;
            if (delta.TotalMilliseconds >= 10)
            {
                calcPoint = DateTime.Now;
                if (rotate4Dxy.Checked)
                {
                    draw4DEnt.RotateXY(0.5f);
                }
                if (rotate4Dxz.Checked)
                {
                    draw4DEnt.RotateXZ(0.5f);
                }
                if (rotate4Dyz.Checked)
                {
                    draw4DEnt.RotateYZ(0.5f);
                }
                if (rotate4Dxd.Checked)
                {
                    draw4DEnt.RotateXD(0.5f);
                }
                if (rotate4Dyd.Checked)
                {
                    draw4DEnt.RotateYD(0.5f);
                }
                if (rotate4Dzd.Checked)
                {
                    draw4DEnt.RotateZD(0.5f);
                }
            }
            draw4DEnt.Draw(e);
        }

        private void cur4DFig_TextChanged(object sender, EventArgs e)
        {
            if (cur4DFig.Text == "Тессеракт")
            {
                draw4DEnt = new DrTesserakt(DrXC, DrYC);
            }
            if (cur4DFig.Text == "Гиперсфера")
            {
                draw4DEnt = new DrHyperSphere(DrXC, DrYC);
            }
        }

        private void PhPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (phAction == "AddForce")
            {
                curBody = bodies.FindIndex(ent => ent.CheckPosition(e.Location));
                if (curBody != -1)
                {
                    phBase.X = e.X;
                    phBase.Y = e.Y;
                }
            }
        }

        private void valRotateX_ValueChanged(object sender, EventArgs e)
        {
            if (!DrRotateX.Checked)
            {
                float diff = (float)valRotateX.Value - RotX;
                drawEnt.RotateX(diff);
                RotX = (float)valRotateX.Value;
            }
        }

        private void DrPicture_Paint(object sender, PaintEventArgs e)
        {
            TimeSpan delta = DateTime.Now - calcPoint;
            if (delta.TotalMilliseconds >= 10)
            {
                calcPoint = DateTime.Now;
                if (DrRotateX.Checked)
                {
                    drawEnt.RotateX(0.5f);
                    valRotateX.Value += (decimal)0.5;
                    if (valRotateX.Value > 180)
                        valRotateX.Value = -179;
                    RotX = (float)valRotateX.Value;
                }
                if (DrRotateY.Checked)
                {
                    drawEnt.RotateY(0.5f);
                    valRotateY.Value += (decimal)0.5;
                    if (valRotateY.Value > 180)
                        valRotateY.Value = -179;
                    RotY = (float)valRotateY.Value;
                }
                if (DrRotateZ.Checked)
                {
                    drawEnt.RotateZ(0.5f);
                    valRotateZ.Value += (decimal)0.5;
                    if (valRotateZ.Value > 180)
                        valRotateZ.Value = -179;
                    RotZ = (float)valRotateZ.Value;
                }
            }

            DrPicture.Invalidate();
            drawEnt.Draw(e);

            monitor.DrawFPS(e);
        }
    }
}
