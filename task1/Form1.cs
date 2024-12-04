namespace Task1
{
    public partial class Form1 : Form
    {
        private int attempts;
        private int min;
        private int max;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            attempts = 0;
            min = 1;
            max = 100;

            var result = MessageBox.Show(
                "Think of a number between 1 and 100 and click OK when you're ready.",
                "Start the game",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                PlayGame();
            }
            else
            {
                Close();
            }
        }

        private void PlayGame()
        {
            while (true)
            {
                int guess = (min + max) / 2;
                attempts++;

                var guessResult = MessageBox.Show(
                    $"Your number {guess}?",
                    "Guessing",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (guessResult == DialogResult.Yes)
                {
                    MessageBox.Show(
                        $"I guessed your number in {attempts} attempt(s)!",
                        "Victory",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var playAgain = MessageBox.Show(
                        "Want to play again?",
                        "New game",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (playAgain == DialogResult.Yes)
                    {
                        StartNewGame();
                    }
                    else
                    {
                        Close();
                    }
                    break;
                }

                var hintResult = MessageBox.Show(
                    $"Number is greater than {guess}?",
                    "Tip",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hintResult == DialogResult.Yes)
                {
                    min = guess + 1;
                }
                else
                {
                    max = guess - 1;
                }

                if (min > max)
                {
                    MessageBox.Show(
                        "It looks like you gave incorrect answers. The game is over.",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StartNewGame();
                    break;
                }
            }
        }
    }
}
