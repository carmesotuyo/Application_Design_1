using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPersonaRepo
    {
        void AgregarPersona(Persona persona);
        void EliminarPersona(Persona persona);
        void ModificarPersona(Persona persona);
        bool EstaPersona(Persona persona);
        List<Persona> Personas();
    }
}
