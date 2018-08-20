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
        public char Character { get; set; }
        public bool Guessed { get; set; }
    }

    public partial class HangmanInCs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                messagelabel.Text = "Press any key to begin";
                gameplaylabel.Text = "Let's get started!";
            }           
        }

        private string[] computerOptions = { "VARIABLE", "PROGRAMMING", "APPLICATION", "ASSEMBLY", "INTELLISENSE",
            "CSHARP", "DOCUMENT", "EXCEPTION", "CAMELCASE", "DATABASE", "SCHEMA", "SYSTEM" };

        private int wins = 0;

        private string userGuess = "A";

        private int remainingGuesses = 10;

        public bool gameStarted = true;

        private bool winContent = false;

        private List<Letter> currentWord = new List<Letter>();

        private string lettersGuessed = "";

        private string computerChoice = "test";

        private int remainingLetters = 0;

        private string alreadyGuessed = "You already guessed that letter.";

        private string winMessage = "You win! Press a button to play again.";

        private void DisplayGamePlayInfo ()
        {
            gameplaylabel.Text = "<p>Wins: " + wins + "</p>" +
                "<p>Current Word: " + PrintCurrentWord() + "</p>" +
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
            string displayString = "";
            foreach (Letter letter in currentWord)
            {
                displayString += letter.Character;
            }
            TestLabel.Text = displayString;

            if (gameStarted == true)
            {
                System.Web.UI.WebControls.Button button = sender as System.Web.UI.WebControls.Button;
                string userGuess = button.ID;
                //TestLabel.Text = userGuess;
                /*string displayString = "";

                foreach (Letter letter in currentWord)
                {
                    displayString += letter.Character;
                }

                foreach (Letter letter in currentWord)
                {

                    if (letter.Character.ToString() == userGuess)
                    {
                        letter.Guessed = true;
                        displayString += letter.Character.ToString();
                    }                   
                }
                TestLabel.Text = displayString;  */            
            }
             
            DisplayGamePlayInfo();           
        }

        protected void StartResetButton_Click(object sender, EventArgs e)
        {
            GetRandomWord();
            CreateCurrentWordList();
            remainingLetters = computerChoice.Length;
            DisplayGamePlayInfo();
            ToggleGameStarted();
        }

        protected void ToggleGameStarted()
        {
            if (gameStarted == false)
            {
                gameStarted = true;
            } else
            {
                gameStarted = false;
            }
        }

        private void CreateCurrentWordList()
        {
            char[] letterArray = computerChoice.ToCharArray();
            for (int i = 0; i < letterArray.Length; i++)
            {
                currentWord.Add(new Letter { Character = letterArray[i], Guessed = false });
            }
            /*string displayString = "";
            foreach (Letter letter in currentWord)
            {
                displayString += letter.Character;
            }
            TestLabel.Text = displayString;*/
        }

        private string PrintCurrentWord()
        {
            string printedString = "";
            foreach (Letter letter in currentWord)
            {
                if (letter.Guessed)
                {
                    printedString += letter.Character.ToString() + " ";
                }
                else
                {
                    printedString += "_ ";
                }
            }
            return printedString;
        }
    }
}