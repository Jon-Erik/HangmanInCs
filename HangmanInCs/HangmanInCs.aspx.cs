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
                messagelabel.Text = "Press Start/reset button to begin";
                gameplaylabel.Text = "Let's get started!";
            }           
        }

        private string[] computerOptions = { "VARIABLE", "PROGRAMMING", "APPLICATION", "ASSEMBLY", "INTELLISENSE",
            "CSHARP", "DOCUMENT", "EXCEPTION", "CAMELCASE", "DATABASE", "SCHEMA", "SYSTEM" };

        private static int wins = 0;

        private static int remainingGuesses = 10;

        public static bool gameStarted = false;

        public static bool completedWord = false;

        private static List<Letter> currentWord = new List<Letter>();

        private static List<Letter> lettersGuessed = new List<Letter>();

        private string computerChoice = "test";

        private static int remainingLetters = 0;

        private string winMessage = "<p>The word is:<p>" +
                                    "<p>" + PrintCurrentWord() + "<p>" +
                                    "<p>Total wins: " + wins.ToString() + "<p>" +
                                    "<p>Press a button to play again<p>";

        private void DisplayGamePlayInfo ()
        {
            gameplaylabel.Text = "<p>Wins: " + wins + "</p>" +
                "<p>Current Word: " + PrintCurrentWord() + "</p>" +
                "<p>Remaining Guesses: " + remainingGuesses + "</p>" +
                "<p>Letters Already Guessed: " + PrintGuessedLetters() + "</p>";
        }

        private void GetRandomWord()
        {
            Random randomNum = new Random();
            int randomIndex = randomNum.Next(computerOptions.Length);
            computerChoice = computerOptions[randomIndex];            
        }

        protected void Button_Click(object sender, EventArgs e)
        {           

            if (gameStarted == true)
            {
                System.Web.UI.WebControls.Button button = sender as System.Web.UI.WebControls.Button;
                string userGuess = button.ID;

                char guessedLetter = userGuess[0];
                bool correctGuess = false;
                bool alreadyGuessed = false;

                for (int i = 0; i < lettersGuessed.Count; i++)
                {
                    if (lettersGuessed[i].Character == guessedLetter)
                    {
                        alreadyGuessed = true;
                        messagelabel.Text = "You already guessed that letter.";
                    }
                }                

                if (alreadyGuessed == false)
                {
                    foreach (Letter letter in currentWord)
                    {
                        if (letter.Character == guessedLetter)
                        {
                            letter.Guessed = true;
                            correctGuess = true;
                            messagelabel.Text = "Correct Guess!";
                            remainingLetters--;

                            if (remainingLetters == 0)
                            {
                                wins++;
                                letter.Guessed = true;
                                gameStarted = false;
                                messagelabel.Text = "You win! Press a button to play again!";
                                completedWord = true;
                            }
                        }
                    }

                    if (correctGuess == false)
                    {
                        messagelabel.Text = "Sorry, incorrect.";
                        remainingGuesses--;
                    }

                    lettersGuessed.Add(new Letter { Character = guessedLetter, Guessed = false });
                    DisplayGamePlayInfo();

                    if (completedWord == true)
                    {
                        gameplaylabel.Text = winMessage;
                    }
                } 
            }            
        }

        protected void StartResetButton_Click(object sender, EventArgs e)
        {
            currentWord.Clear();
            lettersGuessed.Clear();
            wins = 0;
            remainingGuesses = 10;

            GetRandomWord();
            CreateCurrentWordList();
            remainingLetters = computerChoice.Length;
            DisplayGamePlayInfo();
            ToggleGameStarted();
            messagelabel.Text = "To start playing, click a letter to make a guess!";
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

        protected void CreateCurrentWordList()
        {
            char[] letterArray = computerChoice.ToCharArray();
            for (int i = 0; i < letterArray.Length; i++)
            {
                currentWord.Add(new Letter { Character = letterArray[i], Guessed = false });
            }
            string displayString = PrintCurrentWord();
            TestLabel.Text = displayString;
        }

        protected static string PrintCurrentWord()
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

        protected string PrintGuessedLetters()
        {
            string printedString = "";
            foreach (Letter letter in lettersGuessed)
            {
                printedString += letter.Character.ToString().ToLower();
            }
            return printedString;
        }

        protected void testbutton_Click(object sender, EventArgs e)
        {
            string displayString = PrintCurrentWord();
            TestLabel.Text = displayString;
        }
    }
}