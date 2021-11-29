using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorExamination
{
    interface IGameLogic
    {
        string ReturnGuess(string goal, string guess);
        string GenerateSecretNumber();
        bool CheckSecretNumber(string secretNumber, string guess);
    }
}
