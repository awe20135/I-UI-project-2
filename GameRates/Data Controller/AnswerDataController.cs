using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameRates.Data_Controller
{
    public static class AnswerDataController
    {
        public class SavingDataStruct
        {
            private string wordResult;
            private float crispResult;
            private string gameName;

            public string GameName { get => gameName; set => gameName = value; }
            public string WordResult { get => wordResult; set => wordResult = value; }
            public float CrispResult { get => crispResult; set => crispResult = value; }
        }

        private static readonly string answerFileName = "answers.csv";

        public static void SaveAnswerIntoFile(SavingDataStruct data)
        {
            int index = 0;
            string current = "";
            if (File.Exists(answerFileName))
            {
                current = File.ReadAllText(answerFileName);

                List<string> currentLines = new List<string>(current.Split('\n'));

                if (currentLines[currentLines.Count - 1].Equals(""))
                    currentLines.RemoveAt(currentLines.Count - 1);

                index = int.Parse(currentLines[currentLines.Count - 1].Split(';')[0]);
                current += "\n";
            }
            else
                current = "ID;Game;Word Result;CrispResult;\n";

            current += $"{++index};{data.GameName};{data.WordResult};{data.CrispResult};";
            File.WriteAllText(answerFileName, current);
        }

        public static SavingDataStruct[] LoadAnwerFromFile()
        {
            if (!File.Exists(answerFileName))
                throw new Exception("Data not found");

            string[] current = File.ReadAllText(answerFileName).Split('\n');
            List<SavingDataStruct> loadedData = new List<SavingDataStruct>(current.Length);

            for (int i = 1; i < current.Length; i++)
            {
                string[] devidedLine = current[i].Split(';');
                string gameName = devidedLine[1];
                string wordResult = devidedLine[2];
                float crispResult = float.Parse(devidedLine[3]);

                loadedData.Add(new SavingDataStruct { GameName = gameName, WordResult = wordResult, CrispResult = crispResult });
            }

            return loadedData.ToArray();
        }
    }
}
