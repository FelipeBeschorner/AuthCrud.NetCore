using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using restfulDotNetCore.Models;

namespace restfulDotNetCore.Bussines
{
    public class UserBussines : UserModel
    {
        public UserBussines() {}
        public UserBussines(UserModel user)
        {
            this.codigo = user.codigo;
            this.nome = user.nome;
            user.roles.ForEach(r => this.roles.Add(r));

            var encodedValue = Encoding.UTF8.GetBytes(user.senha);
            var encryptedPassword = MD5.Create().ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            this.senha = sb.ToString();

        }
        public bool autenticar(string senha)
        {
            var encryptedPassword = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(senha));

            var sb = new StringBuilder();
            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return this.senha == sb.ToString();
        }
        public string alterarSenha(string novaSenha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(novaSenha);
            var encryptedPassword = MD5.Create().ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            this.senha = sb.ToString();

            return "Senha Alterada com sucesso";
        }
    }
}
