using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UsuarioModel
    {
        private static int codigo = 1;
        private string nome;
        private string login;

        public UsuarioModel()
        {
            codigo++;
        }

        public UsuarioModel(string nome, string login)
        {
            
            this.Nome = nome;
            this.Login = login;
            this.Codigo = codigo;

        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            private set
            {
                codigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        
    }
    
}