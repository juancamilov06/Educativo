using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractidaTDD.Repositorio
{
    using PracticaTDD.Entidades;
    public interface IRepositorioCliente
    {
        bool GuardarInformacionCliente(Cliente informacionCliente);
        bool ConsultarCliente(Cliente informacionCliente);
    }
}
