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
    /// <summary>
    /// Clase para probar los metodos de DBPrueba
    /// </summary>
    [TestClass()]
    public class DBPruebasTests
    {
        /// <summary>
        /// Inicializalizamos la base de datos
        /// </summary>
        DBPrueba dbPruebas = new DBPrueba();

        /// <summary>
        /// Atributos para generar usuario
        /// </summary>
        private const string Nombre = "Alvaro";
        private const string Apellidos = "Lopez";
        private const string Email = "Alv@ubu.es";
        private const string Password = "pass1234";
        /// <summary>
        /// Inicializamos el usuario
        /// </summary>
        private static Usuario usuario = new Usuario(Nombre, Apellidos, Email, Password);

        private const String nombreEntrada = "Entrada";
        private static Entrada entrada = new Entrada(usuario, Password, nombreEntrada);

        private const TipoAcceso acceso = TipoAcceso.Lectura;
        private EntradaLog entradaLog = new EntradaLog(usuario, entrada, acceso);

        /// <summary>
        /// Comprueba el numero de usuarios en la base de datos
        /// </summary>
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
        /// <summary>
        /// Comprueba si contiene una entrada
        /// </summary>
        [TestMethod()]
        public void ContieneEntradaEntradaTest()
        {
            Assert.IsFalse(dbPruebas.ContieneEntrada(null));
            Assert.IsFalse(dbPruebas.ContieneEntrada(entrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.ContieneEntrada(entrada));
        }
        /// <summary>
        /// Comprueba si contiene una entrada usando la id
        /// </summary>
        [TestMethod()]
        public void ContieneEntradaIdTest()
        {
            Assert.IsFalse(dbPruebas.ContieneEntrada(-1));
            Assert.IsFalse(dbPruebas.ContieneEntrada(entrada.IdEntrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.ContieneEntrada(entrada.IdEntrada));
        }
        /// <summary>
        /// Comprueba su contiene la entrada log 
        /// </summary>
        [TestMethod()]
        public void ContainsEntradaLogEntradaTest()
        {
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(null));
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(entradaLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.ContainsEntradaLog(entradaLog));
        }
        /// <summary>
        /// Comprueba si contiene la entradalog usando el id
        /// </summary>
        [TestMethod()]
        public void ContainsEntradaLogIdTest()
        {
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(-1));
            Assert.IsFalse(dbPruebas.ContainsEntradaLog(entradaLog.IdLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.ContainsEntradaLog(entradaLog.IdLog));
        }
        /// <summary>
        /// Compureba si contiene un usuario 
        /// </summary>
        [TestMethod()]
        public void ContainsUsuarioUsuarioTest()
        {
            Assert.IsFalse(dbPruebas.ContainsUsuario(null));
            Assert.IsFalse(dbPruebas.ContainsUsuario(usuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.ContainsUsuario(usuario));
        }
        /// <summary>
        /// Comprueba si contiene un usuario usando el id 
        /// </summary>
        [TestMethod()]
        public void ContainsUsuarioIdTest()
        {
            Assert.IsFalse(dbPruebas.ContainsUsuario(-1));
            Assert.IsFalse(dbPruebas.ContainsUsuario(usuario.IdUsuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.ContainsUsuario(usuario.IdUsuario));
        }
        /// <summary>
        /// Comprueba si contiene el usuario usando el email
        /// </summary>
        [TestMethod()]
        public void ContainsUsuarioEMailTest()
        {
            Assert.IsFalse(dbPruebas.ContainUsuario(null));
            Assert.IsFalse(dbPruebas.ContainUsuario(usuario.EMail));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.ContainUsuario(usuario.EMail));
        }
        /// <summary>
        /// Lee la entrada usando la id
        /// </summary>
        [TestMethod()]
        public void LeeEntradaTest()
        {
            Assert.IsNull(dbPruebas.LeeEntrada(-1));
            Assert.IsNull(dbPruebas.LeeEntrada(entrada.IdEntrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.AreEqual(dbPruebas.LeeEntrada(entrada.IdEntrada), entrada);
        }
        /// <summary>
        /// Comprueba que lea la entradalog usando el id
        /// </summary>
        [TestMethod()]
        public void LeeEntradaLogTest()
        {
            Assert.IsNull(dbPruebas.LeeEntradaLog(-1));
            Assert.IsNull(dbPruebas.LeeEntradaLog(entradaLog.IdLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.AreEqual(dbPruebas.LeeEntradaLog(entradaLog.IdLog), entradaLog);
        }
        /// <summary>
        /// Comrpueba que lea el usuario usando el id
        /// </summary>
        [TestMethod()]
        public void LeeUsuarioIdTest()
        {
            Assert.IsNull(dbPruebas.LeeUsuario(-1));
            Assert.IsNull(dbPruebas.LeeUsuario(usuario.IdUsuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.AreEqual(dbPruebas.LeeUsuario(usuario.IdUsuario), usuario);
        }
        /// <summary>
        /// Comrpueba que lea el usuario usando el email
        /// </summary>

        [TestMethod()]
        public void LeeUsuarioEMailTest()
        {
            Assert.IsNull(dbPruebas.LeeUsuario(null));
            Assert.IsNull(dbPruebas.LeeUsuario(Email));
            dbPruebas.InsertarUsuario(usuario);
            Assert.AreEqual(dbPruebas.LeeUsuario(Email), usuario);
        }
        /// <summary>
        /// Comrpueba que se borra el usuario usando el id
        /// </summary>
        [TestMethod()]
        public void BorrarUsuarioIdTest()
        {
            Assert.IsFalse(dbPruebas.BorrarUsuario(-1));
            Assert.IsFalse(dbPruebas.BorrarUsuario(usuario.IdUsuario));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.BorrarUsuario(usuario.IdUsuario));
        }
        /// <summary>
        /// Comrpueba que se borra el usuario usando el email
        /// </summary>
        [TestMethod()]
        public void BorrarUsuarioEMailTest()
        {
            Assert.IsFalse(dbPruebas.BorraUsuario(null));
            Assert.IsFalse(dbPruebas.BorraUsuario(usuario.EMail));
            dbPruebas.InsertarUsuario(usuario);
            Assert.IsTrue(dbPruebas.BorraUsuario(usuario.EMail));
        }
        /// <summary>
        /// Comrpueba que se borra el usuario 
        /// </summary>
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
        /// <summary>
        /// Comrpueba que se borra la entrada
        /// </summary>
        [TestMethod()]
        public void BorraEntradaEntradaTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntrada(null));
            Assert.IsFalse(dbPruebas.BorraEntrada(entrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.BorraEntrada(entrada));
        }
        /// <summary>
        /// Comprueba que se borra la entrada usando id
        /// </summary>
        [TestMethod()]
        public void BorraEntradaIdTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntrada(-1));
            Assert.IsFalse(dbPruebas.BorraEntrada(entrada.IdEntrada));
            dbPruebas.InsertarEntrada(entrada);
            Assert.IsTrue(dbPruebas.BorraEntrada(entrada.IdEntrada));
        }
        /// <summary>
        /// Comprueba que se borra la entrada log
        /// </summary>
        [TestMethod()]
        public void BorraEntradaLogEntradaTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntrada(null));
            Assert.IsFalse(dbPruebas.BorraEntradaLog(entradaLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.BorraEntradaLog(entradaLog));
        }
        /// <summary>
        /// Comprueba que se borra la entradaLog usando id
        /// </summary>
        [TestMethod()]
        public void BorraEntradaLogIdTest()
        {
            Assert.IsFalse(dbPruebas.BorraEntradaLog(-1));
            Assert.IsFalse(dbPruebas.BorraEntradaLog(entradaLog.IdLog));
            dbPruebas.InsertarEntradaLog(entradaLog);
            Assert.IsTrue(dbPruebas.BorraEntradaLog(entradaLog.IdLog));
        }
        /// <summary>
        /// Comprueba que se inserta la entrada 
        /// </summary>
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
        /// <summary>
        /// Comprueba que se inserta el usuario 
        /// </summary>
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
        /// <summary>
        /// Comprueba que se inserta la entrada log
        /// </summary>
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