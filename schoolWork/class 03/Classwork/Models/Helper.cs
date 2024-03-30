namespace Models
{
    public static class Helper
    {
        public static string GetStats(FootballPlayer player) 
        {
            return $"For this footballer: {player.FullName}\n Mark:9.63 ";
        }
        public static string GetStats(FootballPlayer player, int mark) 
        {
            return $"For this footballer: {player.FullName}\n Mark:{mark} ";
        }
        public static string GetStats(BasketballPlayer player) 
        {
            return $"For this basketballer: {player.FullName}\n Mark: 9.8";
        }
        public static string GetStats(BasketballPlayer player, int mark) 
        {
            return $"For this basketballer: {player.FullName}\n Mark:{mark}";
        }
    }
}
