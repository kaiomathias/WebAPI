using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class UsuarioController : ApiController
    {
        private static List<UsuarioModel> listUsuarios = new List<UsuarioModel>();

        [AcceptVerbs("POST")]
        [Route("usuario")]

        public string CadastrarUsuario(UsuarioModel usuario)
        {
            listUsuarios.Add(usuario);

            string sql = "INSERT INTO usuarios (ID, NOME, LOGIN) " + "VALUES (@ID, @NOME, @LOGIN)";

            DBModel.Insert(usuario, sql);

            return "Usuário cadastrado com sucesso: " + usuario.Nome;
        }

        [AcceptVerbs("PUT")]
        [Route("usuario")]
        public string AlterarUsuario(UsuarioModel usuario)
        {
            listUsuarios.Where(n => n.Codigo == usuario.Codigo)
                .Select(s =>
               {
                   s.Nome = usuario.Nome;
                   s.Login = usuario.Login;

                   return s;
               }).ToList();

            return "Usuário Alterado com sucesso" + usuario.Nome;
        }

        [AcceptVerbs("DELETE")]
        [Route("usuario/{codigo}")]
        public string ExcluirUsuario(UsuarioModel usuario, int codigo)
        {


            string sql = "DELETE FROM usuarios WHERE ID=@ID";
            DBModel.Delete(usuario, sql);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("usuario/{codigo}")]
        public UsuarioModel ConsultarUsuarioPorCodigo(int codigo)
        {
            UsuarioModel usuario = listUsuarios.Where(n => n.Codigo == codigo)
                .Select(n => n)
                .FirstOrDefault();

            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("usuario")]
        public List<UsuarioModel> ConsultarUsuarios()
        {
            return listUsuarios;
        }
    }
}
