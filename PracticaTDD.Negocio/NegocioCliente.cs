using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaTDD.Negocio
{
    using Entidades;
    using Entidades.Enumerados;
    using PractidaTDD.Repositorio;
    using System.Text.RegularExpressions;
    using Transversal.Excepciones;

    public class NegocioCliente
    {
        private Cliente cliente;
        private IRepositorioCliente repositorioCliente;

        public NegocioCliente(Cliente informacionCliente) 
        {
            cliente = informacionCliente;
            repositorioCliente = new RepositorioCliente();
        }

        public NegocioCliente(Cliente informacionCliente, IRepositorioCliente repositorioClienteMock)
        {
            cliente = informacionCliente;
            this.repositorioCliente = repositorioClienteMock;
        }

        public bool ValidarCamposRequeridos()
        {
            return !string.IsNullOrWhiteSpace(cliente.Nombres) &&
                cliente.TipoDocumento != TiposDocumento.Ninguno;

        }

        public bool ValidarFormatoCorreoElectronico()
        {
            Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = reg.Match(cliente.Correo);
            return match.Success;
        }

        public bool GuardarInformacion()
        {
            if (!ValidarCamposRequeridos() || !ValidarFormatoCorreoElectronico())
            {
                return false;
            }

            if (repositorioCliente.ConsultarCliente(cliente) == false)
            {
                return repositorioCliente.GuardarInformacionCliente(cliente);
            }

            return false;
        }

        public bool GuardarInformacionAdicional()
        {
            if (!ValidarCamposRequeridos() || !ValidarFormatoCorreoElectronico())
            {
                return false;
            }

            if (repositorioCliente.ConsultarCliente(cliente) == false)
            {
                return repositorioCliente.GuardarInformacionCliente(cliente);
            }

            throw new NegocioExcepcion("No se puede guardar la informacion");
        }
    }
}
