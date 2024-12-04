namespace Task3
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer moveTimer;
        private Point movementSpeed;

        public Form1()
        {
            InitializeComponent();
            moveTimer = CreateMoveTimer();
            movementSpeed = new Point(5, 5);
        }

        private System.Windows.Forms.Timer CreateMoveTimer()
        {
            var timer = new System.Windows.Forms.Timer { Interval = 1 };
            timer.Tick += (sender, e) => UpdateWindowPosition();
            return timer;
        }

        private void UpdateWindowPosition()
        {
            Rectangle workArea = Screen.PrimaryScreen.WorkingArea;

            if (Bounds.Left + movementSpeed.X < workArea.Left || Bounds.Right + movementSpeed.X > workArea.Right)
            {
                movementSpeed.X = -movementSpeed.X;
            }

            if (Bounds.Top + movementSpeed.Y < workArea.Top || Bounds.Bottom + movementSpeed.Y > workArea.Bottom)
            {
                movementSpeed.Y = -movementSpeed.Y;
            }

            Location = new Point(Location.X + movementSpeed.X, Location.Y + movementSpeed.Y);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BeginMovement();
                    break;

                case Keys.Escape:
                    ToggleTimerState();
                    break;
            }
        }

        private void BeginMovement()
        {
            SetBounds(0, 0, 400, 400);

            if (!moveTimer.Enabled)
            {
                moveTimer.Start();
            }
        }

        private void ToggleTimerState()
        {
            if (moveTimer.Enabled)
            {
                moveTimer.Stop();
            }
            else
            {
                moveTimer.Start();
            }
        }
    }
}