using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorExamination
{
    public class FileDatabase : IDAL
    {
        public List<PlayerData> GetHighscore()
        {
			StreamReader input = new StreamReader("result.txt");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) is not null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);

				PlayerData current = results.FirstOrDefault(x => x.Name == name);

				if (current is null)
					results.Add(new(name, guesses));
				else
					current.Update(guesses);
			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average())); //Metod?
            input.Close();
			return results;

		}

		public void SaveHighscore(string name, int nGuess)
        {
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(name + "#&#" + nGuess);
			output.Close();
		}
    }
}
