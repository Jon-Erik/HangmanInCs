using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HangmanInCs
{
    class Letter
    {
        public string Character { get; set; }
    }

    public partial class HangmanInCs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            messagelabel.Text = "Press any key to begin";
            gameplaylabel.Text = "Let's get started!";
        }

        private string[] computerOptions = { "VARIABLE", "PROGRAMMING", "APPLICATION", "ASSEMBLY", "INTELLISENSE",
            "CSHARP", "DOCUMENT", "EXCEPTION", "CAMELCASE", "DATABASE", "SCHEMA", "SYSTEM" };

        private int wins = 0;

        private string userGuess = "A";

        private int remainingGuesses = 10;

        private bool gameStarted = false;

        private bool winContent = false;

        //private char[] currentWord = { };
        List<Letter> currentWord = new List<Letter>();

        private string lettersGuessed = "";

        private string computerChoice = "";

        private int remainingLetters = 0;

        private string alreadyGuessed = "You already guessed that letter.";

        private string winMessage = "You win! Press a button to play again.";

        private void GamePlayInfo ()
        {
            gameplaylabel.Text = "<p>Wins: " + wins + "</p>" +
                "<p>Current Word: " + String.Join(" ", currentWord) + "</p>" +
                "<p>Remaining Guesses: " + remainingGuesses + "</p>" +
                "<p>Letters Already Guessed: " + lettersGuessed + "</p>";
        }

        private void GetRandomWord()
        {
            Random randomNum = new Random();
            int randomIndex = randomNum.Next(computerOptions.Length);
            computerChoice = computerOptions[randomIndex];
            
        }

        protected void Button_Click(object sender, EventArgs e)
        {   
            if (gameStarted)
            {
                System.Web.UI.WebControls.Button button = sender as System.Web.UI.WebControls.Button;
                string userGuess = button.ID;
                gameplaylabel.Text = userGuess;
            }
            
        }

        protected void StartResetButton_Click(object sender, EventArgs e)
        {
            GetRandomWord();
            CreateCurrentWordArray();
            remainingLetters = computerChoice.Length;
            gameStarted = true;
            GamePlayInfo();
        }

        private void CreateCurrentWordArray()
        {
            string[] letterArray = computerChoice.Split();
            for (int i = 0; i < letterArray.Length; i++)
            {
                string letter = letterArray[i];
                Letter newLetter = new Letter();
                currentWord.Add(newLetter);
            }
        }

    }
}