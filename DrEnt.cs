using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Visualisations
{
    class DrPoint
    {
        protected float xC, yC;
        protected float _x, _y, _z;
        protected float __x, __y;

        protected const float sin30 = 0.5f;
        protected const float cos30 = 0.866f;

        public DrPoint(float x, float y, float z, float xc, float yc)
        {
            _x = x; _y = y; _z = z;
            xC = xc; yC = yc;
            RecalcView();
        }

        public float viewX
        {
            get { return __x; }
        }

        public float viewY
        {
            get { return __y; }
        }

        public float XC
        {
            get { return xC; }
            set 
            {
                xC = value;
                RecalcView();
            }
        }

        public float YC
        {
            get { return yC; }
            set { 
                yC = value;
                RecalcView();
            }
        }

        public float X
        {
            set
            { 
                _x = value;
                RecalcView();
            }
            get { return _x; }
        }

        public float Z
        {
            get { return _z; }
            set 
            {
                _z = value;
                RecalcView();
            }
        }

        public void RotateX(float angle)
        {
            angle = DegToRad(angle);
            double ry = _y * Math.Cos(angle) - _z * Math.Sin(angle);
            double rz = _y * Math.Sin(angle) + _z * Math.Cos(angle);
            _y = (float)ry;
            _z = (float)rz;
            RecalcView();
        }

        public void RotateY(float angle)
        {
            angle = DegToRad(angle);
            _x = -_x;
            double rx = _x * Math.Cos(angle) - _z * Math.Sin(angle);
            double rz = _x * Math.Sin(angle) + _z * Math.Cos(angle);
            _x = -(float)rx;
            _z = (float)rz;
            RecalcView();
        }

        public void RotateZ(float angle)
        {
            angle = DegToRad(angle);
            double rx = _x * Math.Cos(angle) - _y * Math.Sin(angle);
            double ry = _x * Math.Sin(angle) + _y * Math.Cos(angle);
            _x = (float)rx;
            _y = (float)ry;
            RecalcView();
        }

        public virtual void Draw(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Blue, __x - 5, __y - 5, 10, 10);
        }

        protected float DegToRad(float angle)
        {
            return (float)((angle / 180) * Math.PI);
        }

        protected virtual void RecalcView()
        {
            __x = xC; __y = yC;
            __x -= cos30 * _x;
            __y += sin30 * _x;
            __x += cos30 * _y;
            __y += sin30 * _y;
            __y -= _z;
        }
    }

    class DrEdge
    {
        public int A, B;

        public DrEdge(int a, int b)
        {
            A = a; B = b;
        }

        public void Draw(PaintEventArgs e, List<DrPoint> points)
        {
            e.Graphics.DrawLine(Pens.Blue, points[A].viewX, points[A].viewY, points[B].viewX, points[B].viewY);
        }

        public void Draw(PaintEventArgs e, List<DrPoint4D> points)
        {
            e.Graphics.DrawLine(Pens.Blue, points[A].viewX, points[A].viewY, points[B].viewX, points[B].viewY);
        }
    }

    class DrEnt
    {
        protected struct PNT
        {
            public float X, Y;

            public PNT(float x, float y)
            {
                X = x; Y = y;
            }
        }

        protected List<DrPoint> points;
        protected List<DrEdge> edges;
        protected float xC, yC;

        public DrEnt(float xc, float yc)
        {
            xC = xc; yC = yc;
            points = new List<DrPoint>();
            edges = new List<DrEdge>();
        }

        public void RotateX(float angle)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateX(angle);
            }
        }

        public void RotateY(float angle)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateY(angle);
            }
        }

        public void RotateZ(float angle)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateZ(angle);
            }
        }

        public virtual void Draw(PaintEventArgs e)
        {
            for (int i=0; i<points.Count; i++)
            {
                points[i].Draw(e);
            }
            for (int i=0; i<edges.Count; i++)
            {
                edges[i].Draw(e, points);
            }
        }

        public virtual void UpdateCenter(float xc, float yc)
        {
            for (int i=0; i<points.Count; i++)
            {
                points[i].XC = xc;
                points[i].YC = yc;
            }
        }

        protected PNT RotatePnt(float x, float y, float angle)
        {
            angle = DegToRad(angle);
            double rx = x * Math.Cos(angle) - y * Math.Sin(angle);
            double ry = x * Math.Sin(angle) + y * Math.Cos(angle);
            return new PNT((float)rx, (float)ry);
        }

        protected float DegToRad(float angle)
        {
            return (float)((angle / 180) * Math.PI);
        }
    }

    class DrPoint4D : DrPoint
    {
        private float _d;

        public DrPoint4D(float x, float y, float z, float d, float xc, float yc) : base(x, y, z, xc, yc)
        {
            _d = d;
            RecalcView();
        }

        public void RotateYZ(float angle)
        {
            angle = DegToRad(angle);
            double ry = _y * Math.Cos(angle) - _z * Math.Sin(angle);
            double rz = _y * Math.Sin(angle) + _z * Math.Cos(angle);
            _y = (float)ry;
            _z = (float)rz;
            RecalcView();
        }

        public void RotateXZ(float angle)
        {
            angle = DegToRad(angle);
            _x = -_x;
            double rx = _x * Math.Cos(angle) - _z * Math.Sin(angle);
            double rz = _x * Math.Sin(angle) + _z * Math.Cos(angle);
            _x = -(float)rx;
            _z = (float)rz;
            RecalcView();
        }

        public void RotateXY(float angle)
        {
            angle = DegToRad(angle);
            double rx = _x * Math.Cos(angle) - _y * Math.Sin(angle);
            double ry = _x * Math.Sin(angle) + _y * Math.Cos(angle);
            _x = (float)rx;
            _y = (float)ry;
            RecalcView();
        }

        public void RotateXD(float angle)
        {
            angle = DegToRad(angle);
            double rx = _x * Math.Cos(angle) - _d * Math.Sin(angle);
            double rd = _x * Math.Sin(angle) + _d * Math.Cos(angle);
            _x = (float)rx;
            _d = (float)rd;
            RecalcView();
        }

        public void RotateYD(float angle)
        {
            angle = DegToRad(angle);
            double ry = _y * Math.Cos(angle) - _d * Math.Sin(angle);
            double rd = _y * Math.Sin(angle) + _d * Math.Cos(angle);
            _y = (float)ry;
            _d = (float)rd;
            RecalcView();
        }

        public void RotateZD(float angle)
        {
            angle = DegToRad(angle);
            double rz = _z * Math.Cos(angle) - _d * Math.Sin(angle);
            double rd = _z * Math.Sin(angle) + _d * Math.Cos(angle);
            _z = (float)rz;
            _d = (float)rd;
            RecalcView();
        }

        protected override void RecalcView()
        {
            float dd = (_d + 200) / 300; 
            __x = xC; __y = yC;
            __x -= cos30 * _x * dd;
            __y += sin30 * _x * dd;
            __x += cos30 * _y * dd;
            __y += sin30 * _y * dd;
            __y -= _z * dd;
        }
    }

    class DrCube : DrEnt
    {
        public DrCube(float xc, float yc) : base(xc, yc)
        {
            points.Add(new DrPoint(100, 100, -100, xc, yc));
            points.Add(new DrPoint(-100, 100, -100, xc, yc));
            points.Add(new DrPoint(100, -100, -100, xc, yc));
            points.Add(new DrPoint(-100, -100, -100, xc, yc));
            points.Add(new DrPoint(100, 100, 100, xc, yc));
            points.Add(new DrPoint(-100, 100, 100, xc, yc));
            points.Add(new DrPoint(100, -100, 100, xc, yc));
            points.Add(new DrPoint(-100, -100, 100, xc, yc));

            edges.Add(new DrEdge(0, 1));
            edges.Add(new DrEdge(0, 2));
            edges.Add(new DrEdge(1, 3));
            edges.Add(new DrEdge(2, 3));
            edges.Add(new DrEdge(4, 5));
            edges.Add(new DrEdge(4, 6));
            edges.Add(new DrEdge(5, 7));
            edges.Add(new DrEdge(6, 7));
            edges.Add(new DrEdge(0, 4));
            edges.Add(new DrEdge(1, 5));
            edges.Add(new DrEdge(2, 6));
            edges.Add(new DrEdge(7, 3));
        }
    }

    class DrCilinder : DrEnt
    {
        public DrCilinder(float xc, float yc) : base(xc, yc)
        {
            PNT pnt = new PNT(0, 100);
            for (int i=0; i< 36; i++)
            {
                points.Add(new DrPoint(pnt.X, pnt.Y, -100, xc, yc));
                points.Add(new DrPoint(pnt.X, pnt.Y, 100, xc, yc));
                edges.Add(new DrEdge(2 * i, 2 * i + 1));
                if (i != 35)
                {
                    edges.Add(new DrEdge(2 * i, 2 * i + 2));
                    edges.Add(new DrEdge(2 * i + 1, 2 * i + 3));
                }
                pnt = RotatePnt(pnt.X, pnt.Y, 10);
            }
            edges.Add(new DrEdge(0, 70));
            edges.Add(new DrEdge(1, 71));
        }
    }

    class DrBall : DrEnt
    {
        public DrBall(float xc, float yc) : base(xc, yc)
        {
            PNT pnt = new PNT(0, 200);
            int angle = 0;
            for (int j = 0; j < 24; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    points.Add(new DrPoint(pnt.X, pnt.Y, 0, xc, yc));
                    points[points.Count - 1].RotateX(angle);
                    pnt = RotatePnt(pnt.X, pnt.Y, 15);
                    if (i != 23)
                    {
                        edges.Add(new DrEdge(24*j + i, 24 * j + i + 1));
                    }
                }
                angle += 15;
            }

            for (int i=0; i<552; i++)
            {
                edges.Add(new DrEdge(i, i+24));
            }
        }

    }

    class DrTor: DrEnt
    {
        public DrTor(float xc, float yc) : base(xc, yc)
        {
            PNT pnt = new PNT(0, 100);
            int angle = 0;
            for (int i=0; i<24; i++)
            {
                for(int j=0; j<24; j++)
                {
                    points.Add(new DrPoint(pnt.X + 200, pnt.Y, 0, xc, yc));
                    points[points.Count - 1].RotateX(90);
                    points[points.Count - 1].RotateZ(angle);
                    pnt = RotatePnt(pnt.X, pnt.Y, 15);
                    if (i != 23)
                    {
                        edges.Add(new DrEdge(24 * j + i, 24 * j + i + 1));
                    }
                }
                angle += 15;
            }

            for (int i = 0; i < 576; i += 24)
            {
                edges.Add(new DrEdge(i, i + 23));
            }

            for (int i = 0; i < 552; i++)
            {
                edges.Add(new DrEdge(i, i + 24));
            }

            for (int i = 0; i<24; i++)
            {
                edges.Add(new DrEdge(i, i + 552));
            }
        }
    }

    class DrPlane : DrEnt
    {
        private int[] weigth = new int[400];
        private DateTime calcPoint;

        public DrPlane(float xc, float yc) : base(xc, yc)
        {
            for(int i = -300; i<300; i+=30)
            {
                for(int j=-300; j<300; j+=30)
                {
                    points.Add(new DrPoint(i, j, 0, xc, yc));
                }
            }

            for(int i=0; i<20; i++)
            {
                for(int j=0; j<19; j++)
                {
                    edges.Add(new DrEdge(20 * i + j, 20 * i + j + 1));
                }
            }

            for(int i=0; i<380; i++)
            {
                edges.Add(new DrEdge(i, i+20));
            }

            int wdht = 0;
            for (int i=0; i<20; i++)
            {
                weigth[i] = wdht;
                wdht += 18;
            }

            for (int i=20; i<400; i++)
            {
                weigth[i] = weigth[i - 20] + 18;
                //weigth[i] = weigth[i - 20];
            }

            calcPoint = DateTime.Now;
        }

        public override void Draw(PaintEventArgs e)
        {
            TimeSpan delta = DateTime.Now - calcPoint;
            if (delta.TotalMilliseconds >= 10)
            {
                calcPoint = DateTime.Now;
                for (int i=0; i<400; i++)
                {
                    weigth[i]+=5;
                    points[i].Z = (float)(50 * Math.Sin(DegToRad(weigth[i])));
                }

            }
            base.Draw(e);
        }
    }

    class DrEllipticalParaboloid : DrEnt
    {
        public DrEllipticalParaboloid(float xc, float yc) : base(xc, yc)
        {
            for(int z = 0; z<=600; z+=20)
            {
                CalcPoints(z);
            }
        }

        private void CalcPoints(float z)
        {
            if (z == 0)
                points.Add(new DrPoint(0, 0, z - 300, xC, yC));
            //x*x / a*a + y*y / b*b = 1
            float a = (float)Math.Sqrt(20 * z);
            float b = (float)Math.Sqrt(80 * z);

            for (float x = -a; x <= a; x += 25)
            {
                float y = (float)Math.Sqrt(b * b * (1 - x * x / (a * a)));
                points.Add(new DrPoint(x, y, z - 300, xC, yC));
                points.Add(new DrPoint(x, -y, z - 300, xC, yC));
            }

            for (float y = -b; y <= b; y += 25)
            {
                float x = (float)Math.Sqrt(a * a * (1 - y * y / (b * b)));
                points.Add(new DrPoint(x, y, z - 300, xC, yC));
                points.Add(new DrPoint(-x, y, z - 300, xC, yC));
            }
        }
    }

    class Dr4DEnt : DrEnt
    {
        new protected List<DrPoint4D> points;

        public Dr4DEnt(float xc, float yc) : base(xc, yc)
        {
            points = new List<DrPoint4D>();
        }

        public void RotateYZ(float angel)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateYZ(angel);
            }
        }

        public void RotateXZ(float angel)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateXZ(angel);
            }
        }

        public void RotateXY(float angel)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateXY(angel);
            }
        }

        public void RotateXD(float angel)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateXD(angel);
            }
        }

        public void RotateYD(float angel)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateYD(angel);
            }
        }

        public void RotateZD(float angel)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].RotateZD(angel);
            }
        }

        public override void Draw(PaintEventArgs e)
        {
            for (int i=0; i<points.Count; i++)
            {
                points[i].Draw(e);
            }
            for (int i = 0; i < edges.Count; i++)
            {
                edges[i].Draw(e, points);
            }
        }

        public override void UpdateCenter(float xc, float yc)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].XC = xc;
                points[i].YC = yc;
            }
        }
    }

    class DrTesserakt : Dr4DEnt
    {
        public DrTesserakt(float xc, float yc) : base(xc, yc)
        {
            points.Add(new DrPoint4D( 100,  100, -100, -100, xc, yc));
            points.Add(new DrPoint4D(-100,  100, -100, -100, xc, yc));
            points.Add(new DrPoint4D( 100, -100, -100, -100, xc, yc));
            points.Add(new DrPoint4D(-100, -100, -100, -100, xc, yc));
            points.Add(new DrPoint4D( 100,  100,  100, -100, xc, yc));
            points.Add(new DrPoint4D(-100,  100,  100, -100, xc, yc));
            points.Add(new DrPoint4D( 100, -100,  100, -100, xc, yc));
            points.Add(new DrPoint4D(-100, -100,  100, -100, xc, yc));

            points.Add(new DrPoint4D( 100,  100, -100,  100, xc, yc));
            points.Add(new DrPoint4D(-100,  100, -100,  100, xc, yc));
            points.Add(new DrPoint4D( 100, -100, -100,  100, xc, yc));
            points.Add(new DrPoint4D(-100, -100, -100,  100, xc, yc));
            points.Add(new DrPoint4D( 100,  100,  100,  100, xc, yc));
            points.Add(new DrPoint4D(-100,  100,  100,  100, xc, yc));
            points.Add(new DrPoint4D( 100, -100,  100,  100, xc, yc));
            points.Add(new DrPoint4D(-100, -100,  100,  100, xc, yc));

            edges.Add(new DrEdge(0, 1));
            edges.Add(new DrEdge(0, 2));
            edges.Add(new DrEdge(1, 3));
            edges.Add(new DrEdge(2, 3));
            edges.Add(new DrEdge(4, 5));
            edges.Add(new DrEdge(4, 6));
            edges.Add(new DrEdge(5, 7));
            edges.Add(new DrEdge(6, 7));
            edges.Add(new DrEdge(0, 4));
            edges.Add(new DrEdge(1, 5));
            edges.Add(new DrEdge(2, 6));
            edges.Add(new DrEdge(7, 3));

            edges.Add(new DrEdge(8, 9));
            edges.Add(new DrEdge(8, 10));
            edges.Add(new DrEdge(9, 11));
            edges.Add(new DrEdge(10, 11));
            edges.Add(new DrEdge(12, 13));
            edges.Add(new DrEdge(12, 14));
            edges.Add(new DrEdge(13, 15));
            edges.Add(new DrEdge(14, 15));
            edges.Add(new DrEdge(8, 12));
            edges.Add(new DrEdge(9, 13));
            edges.Add(new DrEdge(10, 14));
            edges.Add(new DrEdge(15, 11));

            for (int i=0; i<8; i++)
            {
                edges.Add(new DrEdge(i, i + 8));
            }
        }
    }

    class DrHyperSphere : Dr4DEnt
    {
        public DrHyperSphere(float xc, float yc) : base(xc, yc)
        {
            for (int i=0; i<432; i++)
            {
                points.Add(new DrPoint4D(300, 0, 0, 0, xc, yc));
            }

            for (int h = 0; h < 3; h++)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        points[144 * h + 12 * i + j].RotateXY(30 * j);
                        points[144 * h + 12 * i + j].RotateXZ(30 * i);
                        points[144 * h + 12 * i + j].RotateXD(120 * h);
                    }
                }
            }

            for (int i=0; i < 36; i++)
            {
                for(int j=0; j < 11; j++)
                {
                    edges.Add(new DrEdge(12 * i + j, 12 * i + j + 1));
                }
            }

            for (int i=0; i < 420; i++)
            {
                edges.Add(new DrEdge(i, i + 12));
            }
        }
    }

}
