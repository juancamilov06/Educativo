using PractidaTDD.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaTDD.Entidades;

namespace PracticaTDD.Test
{

    public class RepositorioClienteMock : IRepositorioCliente
    {
        public bool ConsultarCliente(Cliente informacionCliente)
        {
            return false;
        }

        public bool GuardarInformacionCliente(Cliente informacionCliente)
        {
            return false;
        }
    }
}
