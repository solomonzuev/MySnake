namespace MySnakeUI
{
    public partial class Form1 : Form
    {
        private const int cols = 10;
        private const int rows = 10;

        private int cellWidth, cellHeight;
        private int score, bestScore = 0;
        private DateTime startTime;

        private Point snakeHead;
        private List<Point> snakeBody;
        private SnakeDirection direction;

        private Random rand = new Random();

        private Point apple;

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
            PlaceApple();
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
            snakeBody = new List<Point>()
            {
                new Point(0, 0),
                new Point(1, 0),
            };
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
                // Выбираем новую точку для яблока, которая не занята змейкой
                ap = new Point(rand.Next(0, cols), rand.Next(0, rows));
            } while (snakeBody.Contains(ap) || snakeHead == ap);

            apple = ap;
        }

        private void RedrawApple()
        {
            using var gr = Graphics.FromImage(pictureBox1.Image);

            int cellMiddleY = cellHeight * apple.Y;
            int cellMiddleX = cellWidth * apple.X;
            // Отрисовываем новое яблоко
            gr.FillEllipse(Brushes.Red, cellMiddleX, cellMiddleY, cellWidth, cellHeight);
        }

        private void RedrawGrid()
        {
            using var gr = Graphics.FromImage(pictureBox1.Image);
            gr.Clear(Color.White);

            // Рисуем вертикальные линии
            for (int i = 1; i < cols; i++)
            {
                gr.DrawLine(Pens.Black, cellWidth * i, 0, cellWidth * i, pictureBox1.Height);
            }

            // Рисуем горизонтальные линии
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

            // Предугадываем выход за границы поля или столкновение со своим хвостом
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
            // Не разрешаем движение змейки в обратном направлении
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
                RedrawGrid();
                RedrawApple();
                ActionSnake();
                RedrawSnake();
            }
            RedrawScore();
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

        private void RedrawScore()
        {
            lblScoreNum.Text = score.ToString();
        }

        private void ActionSnake()
        {
            // Указывает, куда нужно подвинуть змейку
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
            snakeBody.Add(snakeHead);
            snakeHead = nextHead;

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
            int snakeLength = snakeBody.Count + 1; // количество элементов змейки + голова
            return snakeLength < cols * rows;
        }

        private void MoveSnake()
        {
            // Указывает, куда нужно подвинуть змейку
            Point delta = GetDeltaPoint();

            // Перемещаем голову
            snakeHead.X += delta.X;
            snakeHead.Y += delta.Y;

            // Все, кроме последнего элемента туловища двигаются на место впередистоящей клетки
            for (int i = 0; i < snakeBody.Count - 1; i++)
            {
                var next = snakeBody[i + 1];
                snakeBody[i] = new Point(next.X, next.Y);
            }

            // Последний элемент теперь будет находится на координате, на которой раньше была голова
            snakeBody[^1] = new Point(snakeHead.X - delta.X, snakeHead.Y - delta.Y);
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