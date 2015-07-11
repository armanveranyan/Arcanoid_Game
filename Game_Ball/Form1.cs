using System;
using System.Media;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Game_Ball
{
    public partial class Form1 : Form
    {
        private Ball ball;
        private Paddle paddle;
        private Random rnd = new Random();
        private int score = 0;
        private bool isStart = false;
        private bool isGameOver = false;
        private bool isNewGame = false;
        private SoundPlayer sound;
        private Level level1 = null;
        const int mapH = 10;
        const int mapW = 18;
        string[,] Map = new string[mapH, mapW]
    {
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
        {"s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s",},
    };
        public Form1()
        {
            InitializeComponent();
            pictureBox_Game.Paint += pictureBox_Game_Paint;
            pictureBox_Game.MouseClick += pictureBox_Game_MouseClick;
            pictureBox_Game.MouseMove += pictureBox_Game_MouseMove;
            labelScore.Parent = pictureBox_Game;
            sound = new SoundPlayer(Properties.Resources.Blowing);
            ResizeRedraw = true;
            ball = new Ball(0, 0);
            paddle = new Game_Ball.Paddle(pictureBox_Game.Width / 2 - 60, pictureBox_Game.Height - 20, 100, 20);
            ball.X = paddle.X + paddle.Width / 2 - ball.Width / 2;
            ball.Y = paddle.Y - ball.Height;
            ball.DeltaY = 10;
            level1 = new Level(1, Map);
        }
        void pictureBox_Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isStart && isNewGame)
            {
                if (ball.X > paddle.X + (paddle.Width - ball.Width / 2))
                {
                    ball.X = paddle.X + paddle.Width - ball.Width / 2;
                }
                else
                    if (ball.X < paddle.X - (paddle.Width / 10))
                    {
                        ball.X = paddle.X - (paddle.Width / 10);
                    }
                if (ball.X + ball.Width / 2 > paddle.X + (paddle.Width / 3) && ball.X + ball.Width / 2 < paddle.X + (2 * paddle.Width / 3))
                {
                    ball.DeltaX = 0;
                }
                else
                    if (ball.X + ball.Width / 2 < paddle.X + (paddle.Width / 10))
                    {
                        ball.DeltaX = -5;
                    }
                    else
                        if (ball.X + ball.Width / 2 > paddle.X + (paddle.Width - (paddle.Width / 10)))
                        {
                            ball.DeltaX = 5;
                        }
                        else
                            if (ball.X + ball.Width / 2 < paddle.X + (paddle.Width / 3) * 2)
                            {
                                ball.DeltaX = -1;
                            }
                            else
                                if (ball.X + ball.Width / 2 > paddle.X + (2 * paddle.Width / 3))
                                {
                                    ball.DeltaX = 1;
                                }
                pictureBox_Game.Refresh();
            }
            if (e.X + paddle.Width / 2 >= pictureBox_Game.Width && !isGameOver)
            {
                paddle.X = pictureBox_Game.Width - paddle.Width;
            }
            else
                if (e.X - paddle.Width / 2 <= pictureBox_Game.Location.X && !isGameOver)
                {
                    paddle.X = pictureBox_Game.Location.X;
                }
                else if (!isGameOver)
                {
                    paddle.X = e.X - paddle.Width / 2;
                }
        }
        void pictureBox_Game_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isStart)
            {
                timerBall.Enabled = true;
                isStart = true;
                pictureBox_Game.Refresh();
            }
        }
        void pictureBox_Game_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (isNewGame)
            {
                level1.Draw(e);
                ball.Paint(e);
                paddle.Paint(e);
                GameOver(e);
            }
        }
        private void timerBall_Tick(object sender, EventArgs e)
        {
            if (isGameOver)
            {
                ball.DeltaY = 0;
                ball.DeltaX = 0;
                isStart = false;
                Level.Rectangle.Clear();
            }
            for (int i = 0; i < Level.Rectangle.Count; i++)
            {
                if (Level.Rectangle[i].Contains(ball.X + ball.Width / 2, ball.Y))
                {
                    sound.Play();
                    Level.Rectangle.RemoveAt(i);
                    ball.DeltaY = 10;
                    score += 1;
                    labelScore.Text = "Score - " + score.ToString();
                }
                else
                    if (Level.Rectangle[i].Contains(ball.X + ball.Width, ball.Y + ball.Height / 2))
                    {
                        sound.Play();
                        Level.Rectangle.RemoveAt(i);
                        ball.DeltaX = -5;
                        score += 1;
                        labelScore.Text = "Score - " + score.ToString();
                    }
                    else
                        if (Level.Rectangle[i].Contains(ball.X + ball.Width / 2, ball.Y + ball.Height))
                        {
                            sound.Play();
                            Level.Rectangle.RemoveAt(i);
                            ball.DeltaY = -10;
                            score += 1;
                            labelScore.Text = "Score - " + score.ToString();
                        }
                        else
                            if (Level.Rectangle[i].Contains(ball.X, ball.Y + ball.Height / 2))
                            {
                                sound.Play();
                                Level.Rectangle.RemoveAt(i);
                                ball.DeltaX = 5;
                                score += 1;
                                labelScore.Text = "Score - " + score.ToString();
                            }
            }
            if (ball.X + ball.Width > ClientRectangle.Width || ball.X < ClientRectangle.X)
            {
                ball.DeltaX = -ball.DeltaX;
            }
            if (ball.Y < ClientRectangle.Y)
            {
                ball.DeltaY = -ball.DeltaY;
            }
            if ((new Rectangle(paddle.X, paddle.Y, paddle.Width, paddle.Height).Contains(new Point(ball.X, ball.Y + ball.Height)) && ball.Y + ball.Height == paddle.Y) || (new Rectangle(paddle.X, paddle.Y, paddle.Width, paddle.Height).Contains(new Point(ball.X + ball.Width, ball.Y + ball.Height)) && ball.Y + ball.Height == paddle.Y))
            {
                paddle.ColorFromArgb(rnd.Next(180, 220), rnd.Next(256), rnd.Next(256), rnd.Next(256));
                ball.DeltaY = -ball.DeltaY;
                if (ball.X + ball.Width / 2 > paddle.X + paddle.Width / 3 && ball.X + ball.Width / 2 < paddle.X + (2 * paddle.Width / 3))
                {
                    ball.DeltaX = 0;
                }
                else
                    if (ball.X + ball.Width / 2 < paddle.X + (paddle.Width / 10))
                    {
                        ball.DeltaX = -5;
                    }
                    else
                        if (ball.X + ball.Width / 2 > paddle.X + (paddle.Width - (paddle.Width / 10)))
                        {
                            ball.DeltaX = 5;
                        }
                        else
                            if (ball.X + ball.Width / 2 < paddle.X + (paddle.Width / 3) * 2)
                            {
                                ball.DeltaX = -2;
                            }
                            else
                                if (ball.X + ball.Width / 2 > paddle.X + (2 * paddle.Width / 3))
                                {
                                    ball.DeltaX = 2;
                                }
            }
            ball.X += ball.DeltaX;
            ball.Y += ball.DeltaY;
            pictureBox_Game.Refresh();
        }
        void GameOver(PaintEventArgs e)
        {
            if (ball.Y > pictureBox_Game.Height)
            {
                isGameOver = true;
                Graphics g = e.Graphics;
                Font font = new Font("Arial", 75, FontStyle.Italic);
                Rectangle rectString = new Rectangle(pictureBox_Game.Width / 4 , pictureBox_Game.Height / 6 - 40, 8 * 75, font.Height);
                string gameOverText = "Game over";
                Point[] pt =
            {
                new Point(270,160),
                new Point(760,160),
                new Point(710,220),
                new Point(220,220)
            };
                Point[] pt1 =
            {
                new Point(270,font.Height),
                new Point(760,font.Height),
                new Point((int)font.Size*10,220),
                new Point(220,220)
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
                g.FillRectangle(pth, rectString);
                g.DrawString(gameOverText, font, pth1, rectString.X, rectString.Y);
                button_Exit.Show();
                button_Options.Show();
                button_NewGame.Show();
            }
        }
        private async void button_NewGame_Click(object sender, EventArgs e)
        {
            if (ball.Y > pictureBox_Game.Height)
            {
                timerBall.Enabled = false;
                ball.DeltaY = 10;
                score = 0;
                labelScore.Text ="Score - "+ score.ToString();
                isStart = false;
                isNewGame = false;
                isGameOver = false;
                ball.X = paddle.X + paddle.Width / 2 - ball.Width / 2;
                ball.Y = paddle.Y - ball.Height;
                button_Exit.Hide();
                button_NewGame.Hide();
                button_Options.Hide();
                pictureBox_Game.Refresh();
                level1.LevelPainter(pictureBox_Game.CreateGraphics());
                await Task.Delay(2000);
                isNewGame = true;
                Level.AddLevel(level1);
                pictureBox_Game.Refresh();
            }
            else
            {
                labelScore.Visible = true;
                button_Exit.Hide();
                button_NewGame.Hide();
                button_Options.Hide();
                pictureBox_Game.Refresh();
                level1.LevelPainter(pictureBox_Game.CreateGraphics());
                await Task.Delay(2000);
                isNewGame = true;
                Level.AddLevel(level1);
                pictureBox_Game.Refresh();
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Options_Click(object sender, EventArgs e)
        {
            button_Exit.Dispose();
            button_NewGame.Dispose();
            button_Options.Dispose();
            pictureBox_Game.Refresh();
            Graphics g = pictureBox_Game.CreateGraphics();
            DrawOptions();
        }
        private void DrawOptions()
        {
            Graphics g = pictureBox_Game.CreateGraphics();
            Font font = new Font("Arial", 75, FontStyle.Italic);
            Rectangle rectString = new Rectangle(pictureBox_Game.Width / 4 - 15, pictureBox_Game.Height / 3 - 40, 7 * 75, font.Height);
            string gameOverText = " Options";
            Point[] pt =
            {
                new Point(260,290),
                new Point(650,290),
                new Point(600,350),
                new Point(210,350)
            };
            Point[] pt1 =
            {
                new Point(270,font.Height),
                new Point(760,font.Height),
                new Point((int)font.Size*8,350),
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
            g.FillRectangle(pth, rectString);
            g.DrawString(gameOverText, font, pth1, rectString.X, rectString.Y);
        }
    }
}
