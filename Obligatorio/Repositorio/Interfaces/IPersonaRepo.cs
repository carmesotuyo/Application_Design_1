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
        void AsociarDirector(Persona director, Pelicula pelicula);
        void DesasociarDirector(Persona director, Pelicula pelicula);
        List<Persona> Personas();
    }
}
