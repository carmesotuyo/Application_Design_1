using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaPersona
    {
        void AltaPersona(Persona persona, Usuario admin);
        void BajaPersona(Persona persona, Usuario admin);
        void ModificarPersona(Persona persona, Usuario admin);
        List<Persona> Personas();
    }
}
