using StructuresLibrary;
using System.Diagnostics;

namespace MySnakeUI
{
    public partial class Form1 : Form
    {
        private const int cols = 10;
        private const int rows = 10;
        private const int SNAKE_HEAD = 1;
        private int cellWidth, cellHeight;
        private int score, bestScore = 0;
        private DateTime startTime;

        private Point snakeHead;
        private SnakeDirection direction;

        private Random rand = new Random();

        private Point apple;

        private Deque<Point> snakeBody = new Deque<Point>();

        public Form1()
        {
            InitializeComponent();

            cellWidth = pictureBox1.Width / cols;
            cellHeight = pictureBox1.Height / rows;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            StartNewGame();
        }

        private void StartNewGame()
        {
            ResetAll();

            RedrawGrid();
            
            PlaceApple();
            RedrawApple();
            
            RedrawSnake();

            MakeStep();
            timer1.Start();
        }

        private void ResetAll()
        {
            score = 0;
            startTime = DateTime.Now.AddMilliseconds(timer1.Interval);
            lblGameOver.Visible = lblWin.Visible = false;
            ResetSnakeAndDirection();
        }

        private void ResetSnakeAndDirection()
        {
            snakeHead = new Point(2, 0);
            snakeBody.Clear();
            for (int i = 0; i < 2; i++)
            {
                snakeBody.AddLast(new Point(i, 0));
            }
            direction = SnakeDirection.Right;
        }

        private void RedrawSnake()
        {
            using var gr = Graphics.FromImage(pictureBox1.Image);

            gr.FillRectangle(Brushes.Black, snakeHead.X * cellWidth, snakeHead.Y * cellHeight, cellWidth, cellHeight);

            foreach (var peace in snakeBody)
            {
                gr.FillRectangle(Brushes.Black, peace.X * cellWidth, peace.Y * cellHeight, cellWidth, cellHeight);
            }

            pictureBox1.Invalidate();
        }

        private void PlaceApple()
        {
            Point ap;

            do
            {
                // Choose a new point for the apple that is not occupied by the snake
                ap = new Point(rand.Next(0, cols), rand.Next(0, rows));
            } while (snakeBody.Contains(ap) || snakeHead == ap);

            apple = ap;
        }

        private void RedrawApple()
        {
            using var gr = Graphics.FromImage(pictureBox1.Image);

            int cellMiddleY = cellHeight * apple.Y;
            int cellMiddleX = cellWidth * apple.X;
            // Draw a new apple
            gr.FillEllipse(Brushes.Red, cellMiddleX, cellMiddleY, cellWidth, cellHeight);
            pictureBox1.Invalidate();
        }

        private void RedrawGrid()
        {
            using var gr = Graphics.FromImage(pictureBox1.Image);
            gr.Clear(Color.White);

            // Draw vertical lines
            for (int i = 1; i < cols; i++)
            {
                gr.DrawLine(Pens.Black, cellWidth * i, 0, cellWidth * i, pictureBox1.Height);
            }

            // Draw horizontal lines
            for (int i = 1; i < rows; i++)
            {
                gr.DrawLine(Pens.Black, 0, cellHeight * i, pictureBox1.Width, cellHeight * i);
            }

            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MakeStep();
        }

        private void CheckCollision()
        {
            Point delta = GetDeltaPoint();

            var nextHead = new Point(snakeHead.X + delta.X, snakeHead.Y + delta.Y);

            // Anticipate going beyond the boundaries of the field or a collision with our tail
            if (nextHead.X < 0
                || nextHead.Y < 0
                || nextHead.X >= cols
                || nextHead.Y >= rows
                || IsRanIntoTail(nextHead))
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            timer1.Stop();
            lblGameOver.Visible = true;
            CheckBestScore();
        }

        private void CheckBestScore()
        {
            if (score > bestScore)
            {
                bestScore = score;
                lblBestScore.Text = bestScore.ToString();
            }
        }

        private bool IsRanIntoTail(Point headPoint)
        {
            return snakeBody.Contains(headPoint);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Do not allow the movement of the snake in the opposite direction
            if (e.KeyCode == Keys.Left && direction != SnakeDirection.Right)
            {
                direction = SnakeDirection.Left;
            }
            else if (e.KeyCode == Keys.Right && direction != SnakeDirection.Left)
            {
                direction = SnakeDirection.Right;
            }
            else if (e.KeyCode == Keys.Up && direction != SnakeDirection.Down)
            {
                direction = SnakeDirection.Up;
            }
            else if (e.KeyCode == Keys.Down && direction != SnakeDirection.Up)
            {
                direction = SnakeDirection.Down;
            }
            else
            {
                if (e.KeyCode == Keys.Space)
                {
                    StartNewGame();
                }

                return;
            }

            MakeStep();
        }

        private void MakeStep()
        {
            CountTime();
            CheckCollision();
            if (timer1.Enabled)
            {
                ActionSnake();
            }
            RefreshScore();
        }

        private void CountTime()
        {
            var elapsed = DateTime.Now - startTime;
            int hours = elapsed.Hours;
            var minutes = elapsed.Minutes;
            var seconds = elapsed.Seconds;

            lblTimer.Text = (hours > 12 ? hours.ToString() : $"0{hours}")
                            + ":" + (minutes > 9 ? minutes.ToString() : $"0{minutes}")
                            + ":" + (seconds > 9 ? seconds.ToString() : $"0{seconds}");
        }

        private void RefreshScore()
        {
            lblScoreNum.Text = score.ToString();
        }

        private void ActionSnake()
        {
            // Indicates where to move the snake
            Point delta = GetDeltaPoint();

            var nextHead = new Point(snakeHead.X + delta.X, snakeHead.Y + delta.Y);

            if (nextHead == apple)
            {
                EatApple(nextHead);
                score++;
            }
            else
            {
                MoveSnake();
            }
        }

        private Point GetDeltaPoint()
        {
            return direction switch
            {
                SnakeDirection.Left => new Point(-1, 0),
                SnakeDirection.Right => new Point(1, 0),
                SnakeDirection.Up => new Point(0, -1),
                SnakeDirection.Down => new Point(0, 1),
                _ => throw new ArgumentOutOfRangeException("Некорректное направление"),
            };
        }

        private void EatApple(Point nextHead)
        {
            using var gr = Graphics.FromImage(pictureBox1.Image);

            snakeBody.AddLast(snakeHead);
            snakeHead = nextHead;

            gr.FillRectangle(Brushes.Black, snakeHead.X * cellWidth, snakeHead.Y * cellHeight, cellWidth, cellHeight);
            pictureBox1.Invalidate();

            if (!IsStayPlace())
            {
                ShowWin();
            }
            else
            {
                PlaceApple();
                RedrawApple();
            }
        }

        private void ShowWin()
        {
            timer1.Stop();
            lblWin.Visible = true;
        }

        private bool IsStayPlace()
        {
            int snakeLength = snakeBody.Length + SNAKE_HEAD;
            return snakeLength < cols * rows;
        }

        private void MoveSnake()
        {
            Point delta = GetDeltaPoint();

            Point lastPeace = snakeBody.RemoveFirst();

            using var gr = Graphics.FromImage(pictureBox1.Image);
            // Paint over the cell on which the last element of the snake's tail was located
            gr.FillRectangle(Brushes.White, lastPeace.X * cellWidth, lastPeace.Y * cellHeight, cellWidth, cellHeight);
            gr.DrawRectangle(Pens.Black, lastPeace.X * cellWidth, lastPeace.Y * cellHeight, cellWidth, cellHeight);

            snakeBody.AddLast(snakeHead);
            snakeHead = new Point(snakeHead.X + delta.X, snakeHead.Y + delta.Y);

            gr.FillRectangle(Brushes.Black, snakeHead.X * cellWidth, snakeHead.Y * cellHeight, cellWidth, cellHeight);
            pictureBox1.Invalidate();
        }
    }

    enum SnakeDirection
    {
        Left,
        Right,
        Up,
        Down
    }
}