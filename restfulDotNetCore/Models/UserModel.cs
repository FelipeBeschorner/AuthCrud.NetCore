using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace restfulDotNetCore.Models
{
    public class UserModel
    {
        public int codigo { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public List<RoleModel> roles { get; set; } = new List<RoleModel>();



    }
}
