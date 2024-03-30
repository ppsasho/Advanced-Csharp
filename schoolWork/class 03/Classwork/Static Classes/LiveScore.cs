using System.Security.Cryptography;

namespace Static_Classes
{
    public class LiveScore
    {
        public string Name { get; set; }
        public List<string> Form { get; set; }

        public LiveScore(string name, List<string> form)
        {
            Name = name;
            Form = form;
        }

        public void AddWin() 
        {
            Form.Add("W");
        }
        public void AddLoss()
        {
            Form.Add("L");
        }

        public void AddDraw()
        {
            Form.Add("D");
        }

        public static int GetPoints(LiveScore team)
        {
            int points = 0;

            foreach (var result in team.Form)
            {
                if (result == "W") points += 3;
                else if (result == "L") points += 1;
            }

            return points;
        }
    }
}
