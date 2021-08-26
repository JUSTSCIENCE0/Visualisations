using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Visualisations
{
    class FPSCalculator
    {
        private DateTime LastTime;
        private int FPS;
        private int checker;
        private int summ;
        private Font font = new Font("Arial", 10);

        public FPSCalculator()
        {
            LastTime = DateTime.Now;
            FPS = 0;
            checker = 0;
            summ = 0;
        }

        private void NextRedrawing()
        {
            TimeSpan delta = DateTime.Now - LastTime;
            if (delta.TotalMilliseconds != 0)
            {
                summ += 1000 / Convert.ToInt32(delta.TotalMilliseconds);
                LastTime = DateTime.Now;
                checker++;
                if (checker > 20)
                {
                    FPS = summ / 20;
                    summ = 0;
                    checker = 0;
                }
            }
        }

        public void DrawFPS(PaintEventArgs e)
        {
            NextRedrawing();
            e.Graphics.DrawString(FPS.ToString(), font, Brushes.Black, 0, 0);
        }
    }
}
