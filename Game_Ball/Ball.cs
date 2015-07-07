using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Game_Ball
{
    class Ball
    {
        private Rectangle rect;
        private Image image = null;

        public Image Image
        {
            get { return image; }
        }
        private string imageName;
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
        private int width;
        public int Width
        {
            get { return width; }
        }
        private int height;
        public int Height
        {
            get { return height; }
        }
        private int deltaX;
        public int DeltaX
        {
            get { return deltaX; }
            set { deltaX = value; }
        }
        private int deltaY;

        public int DeltaY
        {
            get { return deltaY; }
            set { deltaY = value; }
        }
        public Ball(string imageName,int x,int y)
        {
            this.imageName = imageName;
            this.x = x;
            this.y = y;
            image = Image.FromFile(imageName);
            this.width = image.Width;
            this.height = image.Height;
        }
        public void Paint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            rect = new Rectangle(x, y, image.Width, image.Height);
            g.DrawImage(image, rect);
            
        }
    }
}
