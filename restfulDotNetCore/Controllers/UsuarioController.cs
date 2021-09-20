using Microsoft.AspNetCore.Mvc;
using restfulDotNetCore.Bussines;
using restfulDotNetCore.Models;
using restfulDotNetCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulDotNetCore.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public static List<UserModel> userList = DataRepository.userList;
        public static List<RoleModel> rolesList = DataRepository.rolesList;
        UserBussines userBussines = new UserBussines();


        [HttpGet]
        public IActionResult buscarTodosUsuarios()
        {
            try
            {
                return Ok(userList);
            }
            catch (Exception e) { throw e; }
        }


        [HttpGet]
        [Route("{Codigo}")]
        public IActionResult buscarUsuario( UserModel usuario)
        {
            try
            {
                var activeUser = userList.Find(r => r.codigo == usuario.codigo);
                if (activeUser != null) return Ok(activeUser);
                else return NotFound("Usuario não cadastrado.");
            }
            catch (Exception e) { throw e; }
        }

        

        [HttpPut]
        public IActionResult atualizarUsuario(UserModel usuario)
        {
            try
            {
                if (usuario.codigo == null) return BadRequest("Informe o código do usuário.");
                var activeUser = userList.Find(r => r.codigo == usuario.codigo);
                if (activeUser == null) return NotFound("Usuário não cadastrado.");
                if (usuario.nome != null) activeUser.nome = usuario.nome; 
                if(usuario.senha != null) userBussines.alterarSenha(usuario.senha); 
                if(usuario.roles != null) activeUser.roles = usuario.roles; 
                return Ok("Alteração realizada com sucesso.");

                
            }
            catch (Exception e) { throw e; }
        }


        [HttpPost]
        public IActionResult cadastrarUsuario(UserModel usuario)
        {
            try
            {
                if (usuario.codigo == null) return BadRequest("Informe o código do usuário");
                if (userList.Exists(r => r.codigo == usuario.codigo)) throw new Exception("Usuario já cadastrado.");
                userList.Add(usuario);
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        public IActionResult exluirUsuario(UserModel usuario)
        {
            try
            {
                if (!userList.Exists(r => r.codigo == usuario.codigo)) throw new Exception("Usuario não cadastrado.");
                if (userList.Remove(userList.Find(r => r.codigo == usuario.codigo))) return Ok("Usuário excluido.");
                throw new Exception("Ocorreu algum erro na execução.");
            }
            catch (Exception e) { throw e; }
        }
    }
}
