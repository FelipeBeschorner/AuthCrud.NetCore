using Microsoft.AspNetCore.Mvc;
using restfulDotNetCore.Models;
using restfulDotNetCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulDotNetCore.Controllers
{
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        public static List<UserModel> userList = DataRepository.userList;
        public static List<RoleModel> rolesList = DataRepository.rolesList;


        [HttpGet]
        public IActionResult buscarTodasRoles()
        {
            try
            {
                return Ok(rolesList);
            }
            catch (Exception e) { throw e; }
        }
        [HttpGet]
        [Route("{Id}")]
        public IActionResult buscarRole(RoleModel role)
        {
            try
            {
                if (role.id != null) return Ok(rolesList.Find(r => r.id == role.id));
                if (role.role != null) return Ok(rolesList.Find(r => r.role == role.role));
                return NotFound("Role não cadastrada.");
            }
            catch (Exception e) { throw e; }
        }

        [HttpPut]
        public IActionResult atualizarRole(RoleModel role)
        {
            try
            {
                if (role.id == null) return BadRequest("Informe um valor válido.");
                if (!rolesList.Exists(r => r.id == role.id)) return NotFound("Role não cadastrada");
                rolesList.ForEach(r => { if (r.id == role.id) r.role = role.role; });
                userList.ForEach(u => u.roles.ForEach(r => { if (r.id == role.id) r = role; }));
                return Ok("Role atulizada com sucesso");
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public IActionResult cadastrarRole(RoleModel role)
        {
            try
            {
                if (role.id == null) return BadRequest("Informe um valor válido.");
                if (rolesList.Exists(r => r.id == role.id)) return BadRequest("Role já cadastrada.");
                rolesList.Add(role);
                return Ok("Role cadastrada com sucesso.");
            }
            catch (Exception e) { throw e; }
        }

        [HttpDelete]
        public IActionResult exluirRole(RoleModel role)
        {
            try
            {
                if (role.id == null) return BadRequest("Informe um valor válido.");
                if (!rolesList.Remove(role)) return NotFound("Role não cadastrada.");
                else userList.ForEach(r => r.roles.Remove(role));
                return Ok("Role excluida.");
            }
            catch (Exception e) { throw e; }
        }
    }
}
