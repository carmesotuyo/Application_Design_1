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
            ChequearQueNoEsteYaAgregada(persona);
            _repoPersona.AgregarPersona(persona);
        }

        private void ChequearQueNoEsteYaAgregada(Persona persona)
        {
            if (_repoPersona.EstaPersona(persona))
            {
                throw new PersonaExistenteException();
            }
        }

        public void BajaPersona(Persona persona, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            ChequearQueExiste(persona);
            _repoPersona.EliminarPersona(persona);
        }

        private void ChequearQueExiste(Persona persona)
        {
            if (!_repoPersona.EstaPersona(persona))
            {
                throw new PersonaInexistenteException();
            }
        }

        public void ModificarPersona(Persona persona, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            ChequearQueExiste(persona);
            _repoPersona.ModificarPersona(persona);
        }

        private void BloquearUsuarioNoAdmin(Usuario admin)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
        }

        public void AsociarDirector(Persona director, Pelicula pelicula, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            ChequearQueExiste(director);
            _repoPersona.AsociarDirector(director, pelicula);
        }

        public void DesasociarDirector(Persona director, Pelicula pelicula, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            _repoPersona.DesasociarDirector(director, pelicula);
        }
    }
}
