using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorExamination
{
    interface IUserInterface
    {
        public void Output(string s);
        public string Input();
        void PrintHighscore(List<PlayerData> playerData);
        void ClearScreen();
    }
}
