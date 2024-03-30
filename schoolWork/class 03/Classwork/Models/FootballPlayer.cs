namespace Models
{
    public class FootballPlayer : User
    {
        public string StrongerFoot {  get; set; }
        public FootballPlayer(int id, string firstName, string lastName, string userName, string password, string strongerFoot) : base(id, firstName, lastName, userName, password)
        {
            StrongerFoot = strongerFoot;
        }
        public override string GetData()
        {
            return base.GetData() + $"\nStronger foot: {StrongerFoot}";
        }
    }
}
