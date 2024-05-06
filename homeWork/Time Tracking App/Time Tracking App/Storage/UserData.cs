namespace Storage
{
    public class UserData
    {
        public DataSet Users { get; set; }
        public UserData() 
        {
            Users = new DataSet();
        }

    }
}
