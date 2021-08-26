using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Visualisations
{
    class StSort
    {
        public int[] nums = new int[100];
        protected Pen BluePen = new Pen(Color.Blue, 3);
        protected Pen YellowPen = new Pen(Color.Yellow, 3);
        protected Pen GreenPen = new Pen(Color.Green, 3);
        protected int cur_i, cur_j;
        protected SoundPlayer simpleSound;

        protected string status;
        protected DateTime time_point;

        public StSort()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                nums[i] = i + 1;
            }
            for (int i = 0; i < 1000; i++)
            {
                int a = rnd.Next(0, 100);
                int b = rnd.Next(0, 100);
                Swap(a, b);
            }
            status = "Init";
            time_point = DateTime.Now;
            cur_i = 0;
            cur_j = 0;
            simpleSound = new SoundPlayer(@"..\..\Data\click.wav");
        }

        public virtual void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Brush brush;
                Pen pen;
                brush = Brushes.LightBlue;
                pen = BluePen;
                if(i == cur_i)
                {
                    brush = Brushes.LightYellow;
                    pen = YellowPen;
                }
                if (i == cur_j)
                {
                    brush = Brushes.LightGreen;
                    pen = GreenPen;
                }
                Rectangle rect = CulcRect(i, nums[i]);
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        public virtual void Sorting()
        {

        }

        protected void Swap(int a, int b)
        {
            int tmp = nums[a];
            nums[a] = nums[b];
            nums[b] = tmp;
        }

        protected Rectangle CulcRect(int pos, int wdht)
        {
            int x, y, width, height;
            x = 25 + pos * 14;
            y = 590 - wdht * 5;
            width = 12;
            height = wdht * 5;
            return new Rectangle(x, y, width, height);
        }
    }

    class StBubbleSort : StSort
    {
        public override void Sorting()
        {
            Thread.Sleep(1000);
            int freq;
            for (int i = 0; i < 100; i++)
            {
                cur_i = i;
                for (int j = 0; j < 100; j++)
                {
                    freq = 500 - 4 * nums[j];
                    cur_j = j;
                    if (nums[i] < nums[j])
                    {
                        Swap(i, j);
                    }
                    Thread.Sleep(20);
                    //Console.Beep(freq, 20);
                }
            }
        }
    }

    class StInsertSort : StSort
    {
        public override void Sorting()
        {
            int key;
            Thread.Sleep(1000);
            for (int i=1; i<100; i++)
            {
                cur_i = i;
                key = nums[i];
                for(cur_j = i-1; cur_j >= 0 ; cur_j--)
                {
                    if (nums[cur_j] <= key)
                        break;
                    nums[cur_j + 1] = nums[cur_j];
                    Thread.Sleep(20);
                }
                nums[cur_j + 1] = key;
            }
        }
    }

    class StMergeSort : StSort
    {
        private void mergeSort(int start, int size)
        {
            if (size > 1)
            {
                int left_size = size / 2;
                int right_size = size - left_size;

                mergeSort(start, left_size);
                mergeSort(start + left_size, right_size);

                int lidx = 0, ridx = left_size, idx = 0;
                int[] tmp_array = new int[size];

                while (lidx < left_size || ridx < size)
                {
                    cur_i = start + lidx;
                    cur_j = start + ridx;
                    if (nums[start + lidx] < nums[start + ridx])
                    {
                        tmp_array[idx] = nums[start + lidx];
                        idx++;
                        lidx++;
                    }
                    else
                    {
                        tmp_array[idx] = nums[start + ridx];
                        idx++;
                        ridx++;
                    }

                    if (lidx == left_size)
                    {
                        for(int i = ridx; i<size; i++)
                        {
                            tmp_array[idx] = nums[start + idx];
                            idx++;
                            Thread.Sleep(20);
                        }
                        break;
                    }
                    if (ridx == size)
                    {
                        for(int i=lidx ; i<left_size; i++)
                        {
                            tmp_array[idx] = nums[start + i];
                            idx++;
                            Thread.Sleep(20);
                        }
                        break;
                    }
                }

                for (int i = 0; i<size; i++)
                {
                    cur_i = start + i; cur_j = start + i;
                    nums[start + i] = tmp_array[i];
                    Thread.Sleep(20);
                }

            }
        }

        public override void Sorting()
        {
            Thread.Sleep(1000);
            mergeSort(0, 100);
        }
    }

    class StSelectionSort : StSort
    {
        public override void Sorting()
        {
            for(int i=0; i<100; i++)
            {
                cur_i = i;
                for (int j = i+1; j<100; j++)
                {
                    cur_j = j;
                    if (nums[j] < nums[cur_i])
                    {
                        cur_i = j;
                    }
                    Thread.Sleep(20);
                }
                Swap(i, cur_i);
            }
        }
    }

    class StCombSort : StSort
    {
        private double fakt = 1.2473309;

        public override void Sorting()
        {
            int step = 99;
            while (step >= 1)
            {
                for (int i = 0; i + step < 100; i++)
                {
                    cur_i = i;
                    cur_j = i + step;
                    if (nums[i] > nums[i + step])
                        Swap(i, i + step);
                    Thread.Sleep(20);
                }
                step = (int)(step / fakt);
            }
        }
    }

    class StFastSort : StSort
    {
        private void quicksort(int lo, int hi)
        {
            if (lo<hi)
            {
                int p = partition(lo, hi);
                quicksort(lo, p);
                quicksort(p + 1, hi);
            }
        }

        private int partition(int low, int high)
        {
            int pivot = (nums[low] + nums[high]) / 2;
            int i = low - 1;
            int j = high + 1;
            cur_i = i;
            cur_j = j;
            while (true)
            {
                do
                {
                    i++;
                    cur_i = i;
                    Thread.Sleep(20);
                } while (nums[i] < pivot);

                do
                {
                    j--;
                    cur_j = j;
                    Thread.Sleep(20);
                } while (nums[j] > pivot);

                if (i >= j)
                    return j;

                Swap(i, j);
            }
        }

        public override void Sorting()
        {
            quicksort(0, 99);
        }
    }

    class StShellSort : StSort
    {
        public override void Sorting()
        {
            for (int step = 50; step > 0; step /= 2)
            {
                for (int i = step; i<100; i++)
                {
                    cur_i = i;
                    for (int j = i - step; j>=0 && nums[j] > nums[j + step]; j -= step)
                    {
                        cur_j = j;
                        Swap(j, j + step);
                        Thread.Sleep(20);
                    }
                }
            }
        }
    }
}
