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
        private List<Perfil> _listaPerfiles;

        //Hacer el constructor de Users
        //(si primero instancio la clase y luego pasa algo que no se llega a completar sus datos, queda en memoria innecesaria?)

        private static void ChequearEmailValido(string value)
        //validar mail con split@ sin campos vacios y el otro que contenga .com
        {
            value.Trim();
            string[] validacion = value.Split('@');
            bool tieneUsuarioMail = false;
            bool tieneDominio = false;

            if (validacion.Length == 2)
            {
                tieneUsuarioMail = validacion[0].Length > 0;
                tieneDominio = validacion[1].Contains(".com");
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

    }
}
