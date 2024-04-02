namespace Task_2
{
    public static class NewVehicleFeatures
    {
        public static string Drive(this Vehicle car)
        {
            return "Driving.";
        }
        public static string Wheelie(this Vehicle bike)
        {
            return "Driving on one wheel.";
        }

        public static string Sail(this Vehicle boat)
        {
            return "Sailing.";
        }
        public static string Fly(this Vehicle airplane)
        {
            return "Flying.";
        }
    }
}
