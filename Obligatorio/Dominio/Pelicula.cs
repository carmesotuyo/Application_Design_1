﻿using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pelicula
    {
        private string _nombre;
        private Genero _generoPrincipal;
        private List<Genero> _generosSecundarios;
        private string _descripcion;
        private bool _esApta;

        public Pelicula()
        {
            _generosSecundarios = new List<Genero>();
        }

        public string Nombre { get => _nombre; set
            {
                if (value.Length == 0)
                {
                    throw new DatoVacioException();
                }
                _nombre = value;
            }
        }

        public Genero GeneroPrincipal { get => _generoPrincipal; set
            {
                chequearSiEsVacio(value);
                _generoPrincipal = value;
            } 
        }


        public List<Genero> GenerosSecundarios { get => _generosSecundarios; set
            {
                _generosSecundarios = value;
            } 
        }

        public void agregarGeneroSecundario(Genero genero)
        {
            chequearSiEsVacio(genero);
            GenerosSecundarios.Add(genero);
        }

        private static void chequearSiEsVacio(Genero genero)
        {
            if (genero == null)
            {
                throw new DatoVacioException();
            }
        }

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool EsApta { get => _esApta; set => _esApta = value; }
    }
}
