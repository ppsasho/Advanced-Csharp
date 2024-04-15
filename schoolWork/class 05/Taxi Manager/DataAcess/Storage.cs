using Models;
using Models.Enum;

namespace DataAcess
{
    //Static Database with multiple StorageSets that represent Tables/Collection per type (StaticDb)
    public static class Storage
    {
        public static StorageSet<User> Users { get; private set; } = new StorageSet<User>() 
        { Items = new List<User>() { new(0, "Sasho", "Popovski", "ppsasho", RoleEnum.Admin, "ppsasho1") } };
        public static StorageSet<Car> Cars { get; private set; } = new StorageSet<Car>();

        //static Storage()
        //{
        //    Users = new StorageSet<User>();
        //    Cars = new StorageSet<Car>();
        //}
    }
}
