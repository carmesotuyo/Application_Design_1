using Dominio;
using Logica.Exceptions;
using Logica.Interfaces;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPersona : ILogicaPersona
    {
        private IPersonaRepo _repoPersona;

        public LogicaPersona(IPersonaRepo repoPersona)
        {
            _repoPersona = repoPersona;
        }

        public List<Persona> Personas()
        {
            return _repoPersona.Personas();
        }

        public void AltaPersona(Persona persona, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            _repoPersona.AgregarPersona(persona);
        }

        public void BajaPersona(Persona persona, Usuario admin)
        {
            throw new NotImplementedException();
        }

        public void ModificarPersona(Persona persona, Usuario admin)
        {
            throw new NotImplementedException();
        }

        private void BloquearUsuarioNoAdmin(Usuario admin)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
        }
    }
}
