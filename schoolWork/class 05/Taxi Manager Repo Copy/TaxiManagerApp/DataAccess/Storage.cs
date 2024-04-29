using Models;
using Models.Enums;

namespace DataAccess
{
    //Static Database with multiple StorageSets that represent Tables/Collection per type (StaticDb)
    public class Storage
    {
        public StorageSet<User> Users { get; set; }
        //{
        //    Items = new List<User>() { new User(1, "Admin", "Admin", "admin", "admin123", RoleEnum.Admin) }
        //};

        public StorageSet<Car> Cars { get; set; }
        Storage()
        {
            Users = new StorageSet<User>();
            Cars = new StorageSet<Car>();

            if(!Users.GetAll().Any())
            {
                Users.Add(new User(0, "Admin", "Admin", "admin", "admin321", RoleEnum.Admin));
            }
        }

        //static Storage()
        //{
        //    Users = new StorageSet<User>();
        //    Cars = new StorageSet<Car>();
        //}
    }
    //Storage:
    //{
    //Users: {
    //Items: []
    //Add()
    //},
    //Cars: {
    //Items: []
    //Add()
    //}
    //}
}
