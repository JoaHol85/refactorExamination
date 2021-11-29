using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorExamination
{
    class ConsoleUI : IUserInterface
    {
        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string s)
        {
            Console.WriteLine(s);
        }

        public void PrintHighscore(List<PlayerData> playerData)
        {
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in playerData)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
