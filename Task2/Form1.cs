namespace Task2
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<MouseButtons, int> clickCounts;

        public Form1()
        {
            InitializeComponent();
            clickCounts = new Dictionary<MouseButtons, int>
            {
                { MouseButtons.Left, 0 },
                { MouseButtons.Middle, 0 },
                { MouseButtons.Right, 0 }
            };
            RefreshTitle();
        }

        private void RefreshTitle()
        {
            Text = $"Leftists: {clickCounts[MouseButtons.Left]} | Middle: {clickCounts[MouseButtons.Middle]} | Right: {clickCounts[MouseButtons.Right]}";
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (clickCounts.ContainsKey(e.Button))
            {
                clickCounts[e.Button]++;
            }

            RefreshTitle();
        }
    }
}