using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Game_Ball
{
    class Level
    {
        private static int levelNumber;
        public static int LevelNumber
        {
            get { return Level.levelNumber; }
            set { Level.levelNumber = value; }
        }
        private Image image = null;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        private static List<Rectangle> rectangle = new List<Rectangle>();
        public static List<Rectangle> Rectangle
        {
            get { return Level.rectangle; }
            set { Level.rectangle = value; }
        }
        private const int mapW = 18;
        public int MapW
        {
            get { return mapW; }
        }
        private const int mapH = 10;
        public int MapH
        {
            get { return mapH; }
        }
        private string[,] tileSetMap;
        public string[,] TileSetMap
        {
            get { return TileSetMap; }
            set { TileSetMap = value; }
        }
        private static bool isLevelCompleted;
        public static bool IsLevelCompleted
        {
            get { return Level.isLevelCompleted; }
            set { Level.isLevelCompleted = value; }
        }
        public Level(int levelNumebr, string[,] tileSetMap)
        {
            this.tileSetMap = tileSetMap;
            image = Properties.Resources.Star;
            LevelNumber = levelNumebr;
        }
        public static void AddLevel(Level level)
        {
            for (int i = 0; i < mapH; i++)
            {
                for (int j = 0; j < mapW; j++)
                {
                    if (level.tileSetMap[i, j] == "s")
                    {
                        rectangle.Add(new Rectangle(115 + j * 40, 100 + i * 40, 40, 40));
                    }
                    if (level.tileSetMap[i, j] == " ")
                    {
                        continue;
                    }
                }
            }
        }
        public void Draw(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < rectangle.Count; i++)
            {
                g.DrawImage(image, rectangle[i]);
            }
        }
        internal void LevelPainter(Graphics graphics)
        {
            Font font = new Font("Arial", 75, FontStyle.Italic);
            Rectangle rectString = new Rectangle(944 / 4 - 15, 761 / 3 - 40, 7 * 75, font.Height);
            string gameOverText = " Level " + Level.LevelNumber;
            Point[] pt =
            {
                new Point(260,290),
                new Point(700,290),
                new Point(650,350),
                new Point(210,350)
            };
            Point[] pt1 =
            {
                new Point(270,font.Height),
                new Point(800,font.Height),
                new Point((int)font.Size*9,350),
                new Point(220,350)
            };
            PathGradientBrush pth = new PathGradientBrush(pt);
            PathGradientBrush pth1 = new PathGradientBrush(pt1);
            pth.CenterPoint = new Point(290, 310);
            pth.CenterColor = Color.FromArgb(100, 255, 255, 255);
            pth1.CenterColor = Color.FromArgb(230, 100, 150, 255);
            pth1.WrapMode = WrapMode.TileFlipY;
            pth.SurroundColors = new Color[]
            {
                Color.FromArgb(100,50,50,50)
            };
            pth1.SurroundColors = new Color[]
            {
                Color.FromArgb(250,100,150,100)
            };
            graphics.FillRectangle(pth, rectString);
            graphics.DrawString(gameOverText, font, pth1, rectString.X, rectString.Y);
        }
        public static void LevelCompleted(Graphics g)
        {
            Font font = new Font("Arial", 50, FontStyle.Italic);
            Rectangle rectString = new Rectangle(944 / 4 - 100, 761 / 3, 11*75, font.Height);
            string gameOverText = "  Level "+levelNumber+" completed";
            Point[] pt =
            {
                new Point(180,290),
                new Point(800,290),
                new Point(750,350),
                new Point(130,350)
            };
            Point[] pt1 =
            {
                new Point(180,font.Height),
                new Point(800,font.Height),
                new Point((int)font.Size*18,350),
                new Point(130,350)
            };
            PathGradientBrush pth = new PathGradientBrush(pt);
            PathGradientBrush pth1 = new PathGradientBrush(pt1);
            pth.CenterPoint = new Point(290, 290);
            pth.CenterColor = Color.FromArgb(100, 255, 255, 255);
            pth1.CenterColor = Color.FromArgb(230, 100, 150, 255);
            pth1.WrapMode = WrapMode.TileFlipY;
            pth.SurroundColors = new Color[]
            {
                Color.FromArgb(100,50,50,50)
            };
            pth1.SurroundColors = new Color[]
            {
                Color.FromArgb(250,100,150,100)
            };
            g.FillRectangle(pth, rectString);
            g.DrawString(gameOverText, font, pth1, rectString.X, rectString.Y);
        }
    }
}
    

