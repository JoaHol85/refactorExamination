using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorExamination
{
    class GuessTheNumber1To100 : IGameLogic
    {
        public string ReturnGuess(string goal, string guess)
        {
            int guess2 = int.Parse(guess);
            int goal2 = int.Parse(goal);

            if (guess2 == goal2)
                return "Correct";
            else
                return goal2 < guess2 ? $"Secret number is less than: {guess}" : $"Secret number is greater than: {guess}";
        }

        public string GenerateSecretNumber()
        {
            Random random = new();
            return random.Next(1, 101).ToString();
        }

        public bool CheckSecretNumber(string secretNumber, string guess)
        {
            return secretNumber == guess ? false : true;
        }
    }
}

