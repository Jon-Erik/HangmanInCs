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
                messagelabel.Text = "Click \"Start or Reset\" button to begin";
                gameplaylabel.Text = "Let's get started!";
                newWordButton.Visible = false;
            }           
        }

        private static string[] computerOptions = { "VARIABLE", "PROGRAMMING", "APPLICATION", "ASSEMBLY", "INTELLISENSE",
            "CSHARP", "DOCUMENT", "EXCEPTION", "CAMELCASE", "DATABASE", "SCHEMA", "SYSTEM" };

        private static int wins = 0;

        private static int remainingGuesses = 10;

        public static bool gameStarted = false;

        public static bool completedWord = false;

        private static List<Letter> currentWord = new List<Letter>();

        private static List<Letter> lettersGuessed = new List<Letter>();

        private static string computerChoice = "";

        private static int remainingLetters = 0;

        private void DisplayGamePlayInfo ()
        {
            if (remainingLetters == 0)
            {
                gameplaylabel.Text = "<p>The word is:</p>" +
                                    "<p>" + PrintCurrentWord() + "</p>" +
                                    "<p>Total wins: " + wins.ToString() + "</p>" +
                                    "<p>Click the \"Get New Word\" button to continue playing</p>";
            } else if (remainingGuesses == 0)
            {
                gameplaylabel.Text = "<p>Game over!</p>" +
                                    "<p>Sorry, you're out of guesses.</p>" +
                                    "<p>Total wins: " + wins.ToString() + "</p>" +
                                    "<p>Press the reset button to play again</p>";
            } else
            {
                gameplaylabel.Text = "<p>Wins: " + wins + "</p>" +
                                "<p>Current Word: " + PrintCurrentWord() + "</p>" +
                                "<p>Remaining Guesses: " + remainingGuesses + "</p>" +
                                "<p>Letters Already Guessed: " + PrintGuessedLetters() + "</p>";
            }           
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
                        }
                    }

                    if (remainingLetters == 0)
                    {
                        wins++;
                        gameStarted = false;
                        messagelabel.Text = "You win!";
                        completedWord = true;
                        newWordButton.Visible = true;
                    }

                    if (correctGuess == false)
                    {
                        messagelabel.Text = "Sorry, incorrect.";
                        remainingGuesses--;
                    }

                    if (remainingGuesses == 0)
                    {
                        gameStarted = false;
                    }

                    lettersGuessed.Add(new Letter { Character = guessedLetter, Guessed = false });
                    DisplayGamePlayInfo();
                } 
            }            
        }

        protected void StartResetButton_Click(object sender, EventArgs e)
        {
            remainingGuesses = 10;
            wins = 0;
            messagelabel.Text = "To start playing, click a letter to make a guess!";
            GetNewWord();
        }

        protected void CreateCurrentWordList()
        {
            char[] letterArray = computerChoice.ToCharArray();
            for (int i = 0; i < letterArray.Length; i++)
            {
                currentWord.Add(new Letter { Character = letterArray[i], Guessed = false });
            }
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
                printedString += letter.Character.ToString().ToLower() + " ";
            }
            return printedString;
        }

        protected void GetNewWord()
        {
            currentWord.Clear();
            lettersGuessed.Clear();
            GetRandomWord();
            CreateCurrentWordList();
            remainingLetters = computerChoice.Length;
            DisplayGamePlayInfo();
            gameStarted = true;
            newWordButton.Visible = false;
        }

        protected void newWordButton_Click(object sender, EventArgs e)
        {
            GetNewWord();
        }
    }
}