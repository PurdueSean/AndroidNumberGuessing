using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PGIPNumberGuessingGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private readonly Random RandomNumber = new Random();
        private int SecretNumber;        
        public int NumberGuess = 0;
        
        void OnSubmitButtonClicked(Object sender, EventArgs e)
        {
            int i = int.Parse(Guess.Text);

            if (i > SecretNumber)
            {
                GuessHint.Text = "Try a lower number.";
                NumberGuess++;
            }
            else if (i < SecretNumber)
            {
                GuessHint.Text = "Try a higher number.";
                NumberGuess++;
            }
            else if (i == SecretNumber)
            {
                NumberGuess++;
                GuessHint.Text = "Congratulations you got the right number!\nThe secret number was " + SecretNumber + ".\nIt took you " + NumberGuess + " guesses.";
                SubmitGuess.IsVisible = false;
                NewGame.IsVisible = true;
                QuestionMarks.Text = SecretNumber.ToString();
                NumberGuess = 0;
            }
        }

        void OnNewGameButtonClicked(Object sender, EventArgs e)
        {
            SecretNumber = RandomNumber.Next(1, 100);
            NewGame.IsVisible = false;
            SubmitGuess.IsVisible = true;            
            GuessHint.IsVisible = true;
            GuessHint.Text = "A new secret number has been selected.";
            QuestionMarks.Text = "??";
        }        
    }
}