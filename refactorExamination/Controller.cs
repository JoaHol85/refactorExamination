using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorExamination
{
    class Controller
    {
        private readonly IDAL _DAL;
        private readonly IUserInterface _uI;
        private readonly IGameLogic _game;

        private bool PracticeMode { get; set; }
        private string SecretNumber { get; set; }

        public Controller(IDAL dal, IUserInterface ui, IGameLogic game)
        {
            _DAL = dal;
            _uI = ui;
            _game = game;
        }



        public void Run()
        {
			bool playOn = true;
			_uI.Output("Enter your user name:");
			string name = _uI.Input();

			while (playOn)
            {
                _uI.ClearScreen();
                SecretNumber = _game.GenerateSecretNumber();

                PracticeModeOnOff(SecretNumber);

                _uI.Output("New game:");
                int nGuess = GameLoop();
                _DAL.SaveHighscore(name, nGuess);
                _uI.PrintHighscore(_DAL.GetHighscore());
                _uI.Output("Correct, it took " + nGuess + " guesses\nContinue?");// Gör metod nedanför? Continue with another game?
                string answer = _uI.Input();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }


        }

        private int GameLoop()
        {
            int nGuess = 0;
            string guess = "", bbcc = "";

            while (_game.CheckSecretNumber(SecretNumber, guess))
            {
                nGuess++;
                guess = _uI.Input();
                _uI.Output(guess);
                bbcc = _game.ReturnGuess(SecretNumber, guess);
                _uI.Output(bbcc);
            }
            return nGuess;
        }

        private void PracticeModeOnOff(string goal)
        {
            _uI.Output("For practiceMode, type: p");
            PracticeMode = _uI.Input() == "p" ? true : false;
            if (PracticeMode)
            {
                _uI.ClearScreen();
                _uI.Output("Practice, number is: " + goal); // Gör Metod?! fusk metod? val?
            }
            else
                _uI.ClearScreen();
        }
    }
}
