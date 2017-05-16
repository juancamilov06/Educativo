using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaTDD.Entidades;

namespace PractidaTDD.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public bool ConsultarCliente(Cliente informacionCliente)
        {
            return true;
            //Codigo para guardar la informacion
        }

        public bool GuardarInformacionCliente(Cliente informacionCliente)
        {
            //Codigo para guardar la informacion
            return false;
        }
    }
}
