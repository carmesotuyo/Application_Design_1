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
    public class LogicaPapel : ILogicaPapel
    {
        private IPapelRepo _repo; 
        public LogicaPapel(IPapelRepo papelRepo)
        {
            _repo = papelRepo;
        }

        public void AsociarActorPelicula(Papel papel, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            _repo.AgregarPapel(papel);
        }

        public void DesasociarActorPelicula(Papel papel, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            VerificarQueExiste(papel);
            _repo.EliminarPapel(papel);
        }

        private void BloquearUsuarioNoAdmin(Usuario admin)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
        }

        private void VerificarQueExiste(Papel papel)
        {
            if (!_repo.ExistePapel(papel))
            {
                throw new PapelInexistenteException();
            }
        }

        public List<Papel> Papeles()
        {
            return _repo.Papeles();
        }
    }
}
