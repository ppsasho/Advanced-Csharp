namespace Models
{
    public static class CurrentSession
    {
        public static User? User { get; set; }

        public static void Set(User user)
        {
            User = user;
        }
        public static void Remove()
        {
            User = null;
        }
    }
}
