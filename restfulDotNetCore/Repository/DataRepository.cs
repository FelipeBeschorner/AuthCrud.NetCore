using restfulDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulDotNetCore.Repository
{
    public class DataRepository
    {
        public static List<UserModel> userList = new List<UserModel>() { new UserModel { codigo = 1, nome = "felipe", senha = "123", roles = { new RoleModel { id = 1, role = "DefaultRole" } } } };
        public static List<RoleModel> rolesList = new List<RoleModel>() { 
            new RoleModel { id = 1, role = "DefaultRole"},
            new RoleModel { id = 2, role = "AdministratorRole" },
            new RoleModel { id = 3, role = "ProductionRole" } };
    }
}
