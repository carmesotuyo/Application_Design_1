using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Exceptions;

namespace Dominio
{
    public class Usuario
    {
        private string _nombreUsuario;
        private string _email;
        private string _clave;
        private string _confirmarClave;
        private List<Perfil> _listaPerfiles;
        private bool _esAdmin;

        public Usuario() {
            _listaPerfiles = new List<Perfil>();
            _esAdmin = false;
        }
        private static void ChequearEmailValido(string value)
        {
            value.Trim();
            string[] validacion = value.Split('@');
            bool tieneUsuarioMail = false;
            bool tieneDominio = false;

            if (validacion.Length == 2)
            {
                tieneUsuarioMail = validacion[0].Length > 0;
                tieneDominio = validacion[1].EndsWith(".com");
            }

            if (!tieneUsuarioMail || !tieneDominio)
            {
                throw new EmailInvalidoException();
            }

        }
        private static void ChequearClaveValida(string value)
        {
            if (value.Length < 10 || value.Length > 30)
            {
                throw new ClaveInvalidaException();
            }
        }

        private static void ChequearNombreValido(string value)
        {
            if (value.Length < 10 || value.Length > 20)
            {
                throw new NombreUsuarioException();
            }
        }

        public string Nombre
        {
            get => _nombreUsuario;
            set
            {
                ChequearNombreValido(value);
                _nombreUsuario = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                ChequearEmailValido(value);
                _email = value;
            }
        }

        public string Clave
        {
            get => _clave;
            set
            {
                ChequearClaveValida(value);
                _clave = value;
            }
        }

        public string ConfirmarClave
        {
            get => _confirmarClave;
            set
            {
                ChequearConfirmacionClave(value);
                _confirmarClave = value;
            }
        }

        private void ChequearConfirmacionClave(string confirmacionClave)
        {
            if (!confirmacionClave.Equals(_clave))
            {
                throw new ClaveNoCoincideException();
            }
        }

       // public List<Perfil> Perfiles { get => _listaPerfiles; }

        public bool EsAdministrador { get => _esAdmin; set => _esAdmin = value; }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(Object obj)
        {
            bool ret = obj != null && obj.GetType() == this.GetType();
            if (ret)
            {
                Usuario usuario = (Usuario) obj;
                ret = usuario.Nombre == this.Nombre && usuario.Email == this.Email;
            }
            return ret;
        }
    }
}
