using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restfulDotNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using restfulDotNetCore.Services;
using restfulDotNetCore.Repository;
using restfulDotNetCore.Bussines;

namespace restfulDotNetCore.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public static List<UserModel> userList = DataRepository.userList;
        public static List<RoleModel> rolesList = DataRepository.rolesList;
        [HttpPost]
        public async Task<ActionResult<dynamic>> autenticarUsuario(UserModel user) {
            if (string.IsNullOrEmpty(user.nome)) return BadRequest("Usuário não informado.");
            if (!userList.Exists(r => r.nome == user.nome)) return BadRequest("Usuario não cadastrado.");
            UserBussines activeUser = new UserBussines(userList.Find(r => r.nome  == user.nome));
            if (!activeUser.autenticar(user.senha)) return BadRequest("Senha Incorreta.");
            var token = TokenService.GenerateToken(activeUser);
            return Ok(new
            {
                user = User,
                token = token
            });
        }

    }
}
