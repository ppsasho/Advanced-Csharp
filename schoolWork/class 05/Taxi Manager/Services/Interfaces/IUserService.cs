﻿using DataAcess;
using Models;
using Models.Enum;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Login();
        void LogOut();
        void CreateUser(string firstName, string lastName,string username, string password, RoleEnum role);
        void CreateUser(string firstName, string lastName, string username, string password, string licenseNumber, DateTime licenseExpiryDate);
    }
}
