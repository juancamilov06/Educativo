using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaTDD.Test
{
    using Entidades;
    using Entidades.Enumerados;
    using Moq;
    using Negocio;
    using PractidaTDD.Repositorio;
    using Transversal.Excepciones;

    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void SiTodosLosCamposTienenDatosSePuedeGuardarLaInformacion()
        {
            //Arange
            Cliente cliente = new Cliente();
            cliente.Nombres = "Alberto Chanci";
            cliente.TipoDocumento = TiposDocumento.Cedula;
            cliente.NumeroDocumento = "999999999";
            cliente.Celular = "310000000";
            cliente.Correo = "albertochanci@gmail";
            cliente.Genero = Generos.Masculino;

            NegocioCliente negocio = new NegocioCliente(cliente);

            //Act
            bool resupesta = negocio.ValidarCamposRequeridos();

            //Assert
            Assert.IsTrue(resupesta);
        }

        [TestMethod]
        public void ElCorreoElectronicoDebeTenerUnFormatoValido()
        {
            //Arrange
            Cliente cliente = new Cliente();
            cliente.Correo = "albertochanci@gmail.com";
            NegocioCliente negocio = new NegocioCliente(cliente);

            //Act
            bool resultado = negocio.ValidarFormatoCorreoElectronico();

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CuandoLaInformacionNoEsValidaNoSePuedeGuardar()
        {
            //Arange
            Cliente cliente = new Cliente();
            cliente.Nombres = "Alberto Chanci";
            cliente.TipoDocumento = TiposDocumento.Cedula;
            cliente.NumeroDocumento = "999999999";
            cliente.Celular = "310000000";
            cliente.Correo = "albertochanci@gmail";
            cliente.Genero = Generos.Masculino;

            NegocioCliente negocio = new NegocioCliente(cliente);

            //Act
            bool resultado = negocio.GuardarInformacion();

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void CuandoFallaLaBaseDeDatosNoGuardaInformacion()
        {
            //Arange
            Cliente cliente = new Cliente();
            cliente.Nombres = "Alberto Chanci";
            cliente.TipoDocumento = TiposDocumento.Cedula;
            cliente.NumeroDocumento = "999999999";
            cliente.Celular = "310000000";
            cliente.Correo = "albertochanci@gmail";
            cliente.Genero = Generos.Masculino;
            RepositorioClienteMock repositorioMock = new RepositorioClienteMock();
            NegocioCliente negocio = new NegocioCliente(cliente, repositorioMock);

            //Act
            bool resultado = negocio.GuardarInformacion();

            //Assert
            Assert.IsFalse(resultado);
        }


        [TestMethod]
        public void SiElNoExisteSePuedeGuardarLaInformacion()
        {
            //Arange
            Cliente cliente = new Cliente();
            cliente.Nombres = "Alberto Chanci";
            cliente.TipoDocumento = TiposDocumento.Cedula;
            cliente.NumeroDocumento = "999999999";
            cliente.Celular = "310000000";
            cliente.Correo = "albertochanci@gmail.com";
            cliente.Genero = Generos.Masculino;

            RepositorioClienteMock2 repositorioMock = new RepositorioClienteMock2();
            NegocioCliente negocio = new NegocioCliente(cliente, repositorioMock);

            //Act
            bool resultado = negocio.GuardarInformacion();

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CuandoFallaLaBaseDeDatosNoGuardaInformacion2()
        {
            //Arange
            Cliente cliente = new Cliente();
            cliente.Nombres = "Alberto Chanci";
            cliente.TipoDocumento = TiposDocumento.Cedula;
            cliente.NumeroDocumento = "999999999";
            cliente.Celular = "310000000";
            cliente.Correo = "albertochanci@gmail.com";
            cliente.Genero = Generos.Masculino;
            Mock<IRepositorioCliente> repositorioMock = new Mock<IRepositorioCliente>();
            repositorioMock.Setup(x => x.ConsultarCliente(cliente)).Returns(true);
            repositorioMock.Setup(y => y.GuardarInformacionCliente(cliente)).Returns(false);
            NegocioCliente negocio = new NegocioCliente(cliente, repositorioMock.Object);

            //Act
            bool resultado = negocio.GuardarInformacion();

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(NegocioExcepcion))]
        public void CuandoFallaGuardarInformacionRetornaExcepcion()
        {
            //Arange
            Cliente cliente = new Cliente();
            cliente.Nombres = "Alberto Chanci";
            cliente.TipoDocumento = TiposDocumento.Cedula;
            cliente.NumeroDocumento = "999999999";
            cliente.Celular = "310000000";
            cliente.Correo = "albertochanci@gmail.com";
            cliente.Genero = Generos.Masculino;
            Mock<IRepositorioCliente> repositorioMock = new Mock<IRepositorioCliente>();
            repositorioMock.Setup(x => x.ConsultarCliente(cliente)).Returns(true);
            repositorioMock.Setup(y => y.GuardarInformacionCliente(cliente)).Returns(false);
            NegocioCliente negocio = new NegocioCliente(cliente, repositorioMock.Object);

            //Act
            bool resultado = negocio.GuardarInformacionAdicional();

        }


    }
}