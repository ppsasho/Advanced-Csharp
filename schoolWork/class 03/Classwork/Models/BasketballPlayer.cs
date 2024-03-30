namespace Models
{
    public class BasketballPlayer : User
    {
        public int Height { get; set; }
        public BasketballPlayer(int id, string firstName, string lastName, string userName, string password, int height) : base(id, firstName, lastName, userName, password)
        {
            Height = height;
        }

        public override string GetData()
        {
            return base.GetData() + $"\n{FullName} : {Height}";
        }


    }
}
