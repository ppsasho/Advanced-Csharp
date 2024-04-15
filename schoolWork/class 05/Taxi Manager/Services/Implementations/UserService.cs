using DataAcess;
using Models.Enum;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        
        public void LogOut()
        {
            CurrentSession.User = null;
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string firstName, string lastName, string username, string password, RoleEnum role)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string firstName, string lastName, string username, string password, string licenseNumber, DateTime licenseExpiryDate)
        {
            throw new NotImplementedException();
        }

        public void LogIn(string username, string password)
        {
            var loginUser = Storage.Users.GetAll().FirstOrDefault(x => x.Username.Equals(username))
                 ?? throw new Exception("Nonexistent user.");

            if (!loginUser.CheckPassword(password)) throw new Exception("Wrong password!");

            CurrentSession.User = loginUser;
        }
    }
    

}
