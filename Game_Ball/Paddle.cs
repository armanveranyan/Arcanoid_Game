using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Game_Ball
{
    class Paddle 
    {
        private Random random=new Random();
        private Rectangle rect;
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        int A=100, R=100, G=150, B=255;
        public Paddle(int x,int y,int width,int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public void Paint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            rect = new Rectangle(x, y, width, height);
            Point[] pt =
            {
                new Point(rect.X,rect.Y),
                new Point(rect.X+rect.Width,rect.Y),
                new Point(rect.X+rect.Width,rect.Y+rect.Height),
                new Point(rect.X,rect.Y+rect.Height)
            };
            PathGradientBrush pth = new PathGradientBrush(pt);
            pth.SurroundColors = new Color[]
            {
                Color.FromArgb(10,R,G,B)
            };
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X + rect.Width / 10, rect.Y), new Point(rect.X + rect.Width / 10, rect.Y + rect.Height));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X, rect.Y), new Point(rect.X + (rect.Width / 10), rect.Y));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X + (rect.Width - rect.Width / 10), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X + (rect.Width - rect.Width / 10), rect.Y), new Point(rect.X + (rect.Width - rect.Width / 10), rect.Y + rect.Height));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X + rect.Width / 3, rect.Y + 3), new Point(rect.X + rect.Width / 3, rect.Y + rect.Height));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X + (rect.Width / 3) * 2, rect.Y + 3), new Point(rect.X + (rect.Width / 3) * 2, rect.Y + rect.Height));
            g.DrawLine(new Pen(Color.FromArgb(255, R, G, B), 2), new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            pth.CenterColor = Color.FromArgb(A, R, G, B);
            g.FillRectangle(pth, rect);
        }
        public void ColorFromArgb(int A,int R,int G,int B)
        {
            this.A = A;
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }
}
