namespace Static_Classes
{
    public static class Helper
    {
        public static string GetUsername(string fullUsername) 
        {
            return fullUsername.Replace("SEDC\\", "");
        }
        public static string GetFullName(string fullUsername) 
        {
            return fullUsername.Replace("SEDC\\", "").Replace(".", " ");
        }
    }
}
