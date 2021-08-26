using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Visualisations
{
    class PhVector
    {
        private double x, y;
        private double r;
        private double angle;

        private Pen pen;

        public PhVector(double X, double Y, Color color)
        {
            pen = new Pen(color, 5);
            pen.EndCap = LineCap.ArrowAnchor;

            x = X; y = Y;
            r = Math.Sqrt((x*x + y*y));
            angle = Math.Atan2(y, x);
        }

        public void Draw(Point pos, PaintEventArgs e, bool fullmode)
        {
            e.Graphics.DrawLine(pen, pos.X, pos.Y, (float)(pos.X + x), (float)(pos.Y + y));
            if (fullmode)
            {
                e.Graphics.DrawString("x = " + x.ToString() + " ; y = " + y.ToString(),
                    new Font("Arial", 20), Brushes.Black, 100, 100);
                e.Graphics.DrawString("radius = " + r.ToString(),
                    new Font("Arial", 20), Brushes.Black, 100, 130);
                e.Graphics.DrawString("angle = " + (angle / Math.PI * 180).ToString(),
                    new Font("Arial", 20), Brushes.Black, 100, 160);
            }
        }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                r = Math.Sqrt((x * x + y * y));
                angle = Math.Atan2(y, x);
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                r = Math.Sqrt((x * x + y * y));
                angle = Math.Atan2(y, x);
            }
        }

        public double R
        {
            get
            {
                return r;
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
                x = r * Math.Cos(angle);
                y = r * Math.Sin(angle);
            }
        }

        public void SetZero()
        {
            x = 0; y = 0;
            r = 0;
            angle = 0;
        }

        public static PhVector operator +(PhVector a, PhVector b)
        {
            double _x = a.X + b.X;
            double _y = a.Y + b.Y;
            return new PhVector(_x, _y, Color.Black);
        }

        public static PhVector operator *(PhVector vec, double n)
        {
            PhVector res = new PhVector(vec.x, vec.y, Color.Black);
            res.x *= n;
            res.y *= n;
            res.r *= n;
            return res;
        }

        public static PhVector operator *(double n, PhVector vec)
        {
            PhVector res = new PhVector(vec.x, vec.y, Color.Black);
            res.x *= n;
            res.y *= n;
            res.r *= n;
            return res;
        }
    }

    class PhBody
    {
        public double mass;
        public double x, y;

        public PhVector Force;
        public PhVector Velocity;

        protected SolidBrush color;
        public int size;

        public PhBody()
        {
            size = 1;
        }

        public void AddForce(PhVector force)
        {
            Force += force;
        }

        public void AddAcceleration(PhVector acceleration)
        {
            PhVector force = mass * acceleration;
            Force += force;
        }

        public virtual void CalcPhisics()
        {
            PhVector velocity = (double)(0.17 / mass) * Force;
            Velocity += velocity;
            x += Velocity.X;
            y += Velocity.Y;
            Force.SetZero();
        }

        public virtual void AddGravity(PhBody body)
        {
            PhVector force = new PhVector(body.x - x, body.y - y, Color.Black);
            if (force.R < size + body.size)
                return;
            double distanse = force.R * force.R;
            force = (1 / force.R) * force;
            force = mass * body.mass / distanse * force;
            AddForce(force);
            body.AddForce((-1) * force);
        }

        public bool CheckPos()
        {
            if (x > 3840)
                return true;
            if (x < -1920)
                return true;
            if (y > 2160)
                return true;
            if (y < -1080)
                return true;
            return false;
        }

        public virtual bool CheckPosition(Point pnt)
        {
            return false;
        }

        public virtual void Draw(PaintEventArgs e, int mode)
        {
        }

        public virtual void CheckCollision(PhBody body)
        {

        }
    }

    class PhSphere : PhBody
    {
        public int radius;

        public PhSphere(int r, int m, Point pos)
        {
            radius = r;
            size = radius;
            mass = m;
            x = pos.X;
            y = pos.Y;
            Force = new PhVector(0, 0, Color.Black);
            Velocity = new PhVector(0, 0, Color.Green);
            int seed = DateTime.Now.Second * 1000 + DateTime.Now.Millisecond + r * 1000 + m * 100;
            Random rnd = new Random(seed);
            color = new SolidBrush(Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256)));
        }

        public override void Draw(PaintEventArgs e, int mode)
        {
            e.Graphics.FillEllipse(color, (float)(x - radius), (float)(y - radius), 2* radius, 2 * radius);
            base.Draw(e, mode);
        }

        public override bool CheckPosition(Point pnt)
        {
            double s = Math.Sqrt((x - pnt.X) * (x - pnt.X) + (y - pnt.Y) * (y - pnt.Y));
            if (s > radius)
                return false;
            else
                return true;
        }

        public override void CheckCollision(PhBody body)
        {
            double dist = Math.Sqrt((x - body.x) * (x - body.x) + (y - body.y) * (y - body.y));
            double colis = radius + body.size;
            if (dist < colis)
            {
                double diff = (colis - dist);
                double k = body.mass / (mass + body.mass);
                PhVector vec = new PhVector((x - body.x), (y - body.y), Color.Black);
                PhVector vec1 = vec * ((1 / vec.R) * diff * k);
                x += vec1.X;
                y += vec1.Y;
                PhVector vec2 = vec * ((1 / vec.R) * diff * (1 - k));
                body.x -= vec2.X;
                body.y -= vec2.Y;

                PhVector pulse = mass * Velocity + body.mass * body.Velocity;
                Velocity = ( 1 / (2 * mass)) * pulse;
                body.Velocity = (1 / (2 * body.mass)) * pulse;
            }
        }
    }
}
