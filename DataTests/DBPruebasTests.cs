using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBPruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaDeClases;

namespace DBPruebas.Tests
{
    [TestClass()]
    public class DBPruebasTests
    {
        DBPrueba dbPruebas = new DBPrueba();


        private const string Nombre = "Alvaro";
        private const string Apellidos = "Lopez";
        private const string Email = "Alv@ubu.es";
        private const string Password = "pass1234";
        private static Usuario usuario = new Usuario(Nombre, Apellidos, Email, Password);

        private const String nombreEntrada = "Entrada";
        private static Entrada entrada = new Entrada(usuario, Password, nombreEntrada);

        private const TipoAcceso acceso = TipoAcceso.Lectura;
        private EntradaLog entradaLog = new EntradaLog(usuario, entrada, acceso);

        [TestMethod()]
        public void NumeroUsuarioTest()
        {
            Assert.IsTrue(dbPruebas.NumeroUsuario() == 2);
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.NumeroUsuario() == 3);
        }

        [TestMethod()]
        public void NumeroEntradasTest()
        {
            Assert.IsTrue(dbPruebas.NumeroEntradas() == 0);
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.NumeroEntradas() == 1);
        }

        [TestMethod()]
        public void NumeroEntradasLogTest()
        {
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 0);
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 1);
        }

        [TestMethod()]
        public void ContieneEntradaEntradaTest()
        {
            Assert.IsFalse(dbPruebas.ContieneEntrada(null));
            Assert.IsFalse(dbPruebas.ContieneEntrada(entrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.ContieneEntrada(entrada));
        }

        [TestMethod()]
        public void ContieneEntradaIdTest()
        {
            Assert.IsFalse(dbPruebas.ContieneEntrada(-1));
            Assert.IsFalse(dbPruebas.ContieneEntrada(entrada.IdEntrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.ContieneEntrada(entrada.IdEntrada));
        }

        [TestMethod()]
        public void ContainsEntradaLogEntradaTest()
        {
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(null));
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(entradaLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.ContainsEntradaLog(entradaLog));
        }

        [TestMethod()]
        public void ContainsEntradaLogIdTest()
        {
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(-1));
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(entradaLog.IdLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.ContainsEntradaLog(entradaLog.IdLog));
        }

        [TestMethod()]
        public void ContainsUsuarioUsuarioTest()
        {
            Assert.IsFalse(dbPruebas.ContainsUsuario(null));
            Assert.IsFalse(dbPruebas.ContainsUsuario(usuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.ContainsUsuario(usuario));
        }

        [TestMethod()]
        public void ContainsUsuarioIdTest()
        {
            Assert.IsFalse(dbPruebas.ContainsUsuario(-1));
            Assert.IsFalse(dbPruebas.ContainsUsuario(usuario.IdUsuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.ContainsUsuario(usuario.IdUsuario));
        }

        [TestMethod()]
        public void ContainsUsuarioEMailTest()
        {
            Assert.IsFalse(dbPruebas.ContainUsuario(null));
            Assert.IsFalse(dbPruebas.ContainUsuario(usuario.EMail));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.ContainUsuario(usuario.EMail));
        }

        [TestMethod()]
        public void LeeEntradaTest()
        {
            Assert.IsNull(dbPruebas.LeeEntrada(-1));
            Assert.IsNull(dbPruebas.LeeEntrada(entrada.IdEntrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.AreEqual(dbPruebas.LeeEntrada(entrada.IdEntrada), entrada);
        }

        [TestMethod()]
        public void LeeEntradaLogTest()
        {
            Assert.IsNull(dbPruebas.LeeEntradaLog(-1));
            Assert.IsNull(dbPruebas.LeeEntradaLog(entradaLog.IdLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.AreEqual(dbPruebas.LeeEntradaLog(entradaLog.IdLog), entradaLog);
        }

        [TestMethod()]
        public void LeeUsuarioIdTest()
        {
            Assert.IsNull(dbPruebas.LeeUsuario(-1));
            Assert.IsNull(dbPruebas.LeeUsuario(usuario.IdUsuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.AreEqual(dbPruebas.LeeUsuario(usuario.IdUsuario), usuario);
        }

        [TestMethod()]
        public void LeeUsuarioEMailTest()
        {
            Assert.IsNull(dbPruebas.LeeUsuario(null));
            Assert.IsNull(dbPruebas.LeeUsuario(Email));
            dbPruebas.InsertarUsuario(usuario);
            Assert.AreEqual(dbPruebas.LeeUsuario(Email), usuario);
        }

        [TestMethod()]
        public void BorrarUsuarioIdTest()
        {
            Assert.IsFalse(dbPruebas.BorrarUsuario(-1));
            Assert.IsFalse(dbPruebas.BorrarUsuario(usuario.IdUsuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.BorrarUsuario(usuario.IdUsuario));
        }

        [TestMethod()]
        public void BorrarUsuarioEMailTest()
        {
            Assert.IsFalse(dbPruebas.BorraUsuario(null));
            Assert.IsFalse(dbPruebas.BorraUsuario(usuario.EMail));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.BorraUsuario(usuario.EMail));
        }

        [TestMethod()]
        public void BorrarUsuarioUsuarioTest()
        {
            string Email2 = "Avg@ubu.es";
            Usuario usuario2 = new Usuario(Nombre, Apellidos, Email2, Password);
            entrada.AddUser(usuario2);

            Assert.IsFalse(dbPruebas.BorrarUsuario(null));
            Assert.IsFalse(dbPruebas.BorrarUsuario(usuario));
            dbPruebas.InsertarEntrada(entrada);
            dbPruebas.InsertarUsuario(usuario);
            dbPruebas.InsertarUsuario(usuario2);
            Assert.IsTrue(dbPruebas.BorrarUsuario(usuario));
            Assert.IsFalse(dbPruebas.ContainsUsuario(usuario));
            Assert.IsFalse(entrada.Usuarios.Contains(usuario));
        }

        [TestMethod()]
        public void BorraEntradaEntradaTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntrada(null));
            Assert.IsFalse(dbPruebas.BorraEntrada(entrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.BorraEntrada(entrada));
        }

        [TestMethod()]
        public void BorraEntradaIdTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntrada(-1));
            Assert.IsFalse(dbPruebas.BorraEntrada(entrada.IdEntrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.BorraEntrada(entrada.IdEntrada));
        }

        [TestMethod()]
        public void BorraEntradaLogEntradaTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntrada(null));
            Assert.IsFalse(dbPruebas.BorraEntradaLog(entradaLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.BorraEntradaLog(entradaLog));
        }

        [TestMethod()]
        public void BorraEntradaLogIdTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntradaLog(-1));
            Assert.IsFalse(dbPruebas.BorraEntradaLog(entradaLog.IdLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.BorraEntradaLog(entradaLog.IdLog));
        }

        [TestMethod()]
        public void InsertarEntradaTest()
        {
            Entrada entrada2 = new Entrada(usuario, null, "nombre");
            Assert.IsFalse(dbPruebas.InsertarEntrada(null));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 0);
            Assert.IsFalse(dbPruebas.InsertarEntrada(entrada2));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 0);
            Assert.IsTrue(dbPruebas.InsertarEntrada(entrada));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 1);
            Assert.IsFalse(dbPruebas.InsertarEntrada(entrada));
            entrada2.IdEntrada = entrada.IdEntrada;
            Assert.IsFalse(dbPruebas.InsertarEntrada(entrada2));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 1);
        }

        [TestMethod()]
        public void InsertarUsuarioTest()
        {
            string Email2 = "Avg@ubu.es";
            Usuario usuario2 = new Usuario(Nombre, Apellidos, Email, Password);
            Usuario usuario3 = new Usuario(Nombre, Apellidos, Email2, Password);
            Usuario usuario4 = new Usuario(null, null, null, null);

            Assert.IsFalse(dbPruebas.InsertarUsuario(null));
            Assert.IsTrue(dbPruebas.NumeroUsuario() == 2);
            Assert.IsTrue(dbPruebas.InsertarUsuario(usuario));
            Assert.IsTrue(dbPruebas.NumeroUsuario() == 3);
            Assert.IsFalse(dbPruebas.InsertarUsuario(usuario));
            Assert.IsFalse(dbPruebas.InsertarUsuario(usuario2));
            Assert.IsFalse(dbPruebas.InsertarUsuario(usuario4));
            Assert.IsTrue(dbPruebas.NumeroUsuario() == 3);
            Assert.IsTrue(dbPruebas.InsertarUsuario(usuario3));
            Assert.IsTrue(dbPruebas.NumeroUsuario() == 4);
        }

        [TestMethod()]
        public void InsertarEntradaLogTest()
        {
            EntradaLog entradaLog2 = new EntradaLog(null, null, TipoAcceso.Escritura);

            Assert.IsFalse(dbPruebas.InsertarEntradaLog(null));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 0);
            Assert.IsTrue(dbPruebas.InsertarEntradaLog(entradaLog));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 1);
            Assert.IsFalse(dbPruebas.InsertarEntradaLog(entradaLog));
            Assert.IsFalse(dbPruebas.InsertarEntradaLog(entradaLog2));
            Assert.IsTrue(dbPruebas.NumeroEntradasLog() == 1);
        }
    }
}