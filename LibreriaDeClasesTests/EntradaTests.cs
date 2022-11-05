using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibreriaDeClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases.Tests
{
    [TestClass()]
    public class EntradaTests
    {
        private const string nombre = "Alvaro";
        private const string apellidos = "Lopez";
        private const string email = "Alv@ubu.es";
        private const string password = "pass1234";
        private static Usuario usuarioPrueba = new Usuario(nombre, apellidos, email, password);

        private const string nombre2 = "Adolfo";
        private const string apellidos2 = "Vine";
        private const string email2 = "Adf@ubu.es";
        private const string password2 = "contra4321";
        private static Usuario usuarioPrueba2 = new Usuario(nombre2, apellidos2, email2, password2);

        private const String nombreEntrada = "Entrada";
        private const String nombreEntrada2 = "Entrada2";
        private Entrada entradaPrueba = new Entrada(usuarioPrueba, password, nombreEntrada);
        private Entrada entradaPrueba2 = new Entrada(usuarioPrueba2, password2, nombreEntrada2);

        [TestMethod()]
        public void TestEntradaCreada()
        {
            Entrada entradaPrueba3 = null;
            Entrada entradaPrueba4 = new Entrada(null, null, null);
            Assert.IsNotNull(usuarioPrueba);
            Assert.IsNotNull(usuarioPrueba2);
            Assert.IsNotNull(entradaPrueba);
            Assert.IsNotNull(entradaPrueba2);
            Assert.IsNull(entradaPrueba3);
            Assert.IsNotNull(entradaPrueba4);
            Assert.IsNull(entradaPrueba4.Usuario);
            Assert.IsNull(entradaPrueba4.Contrasenya);
            Assert.IsNull(entradaPrueba4.NombreEntrada);
            Assert.IsInstanceOfType(entradaPrueba, typeof(Entrada));
            Assert.IsInstanceOfType(entradaPrueba2, typeof(Entrada));
            Assert.IsNotInstanceOfType(entradaPrueba3, typeof(Entrada));
            Assert.IsInstanceOfType(entradaPrueba4, typeof(Entrada));
        }

        [TestMethod()]
        public void TestIdDistintas()
        {
            Assert.IsInstanceOfType(entradaPrueba.IdEntrada, typeof(Int16));
            Assert.IsInstanceOfType(entradaPrueba2.IdEntrada, typeof(Int16));
            Assert.IsTrue(entradaPrueba.IdEntrada < entradaPrueba2.IdEntrada);
            Assert.IsTrue((entradaPrueba.IdEntrada + 1) == entradaPrueba2.IdEntrada);
        }

        [TestMethod()]
        public void TestNombreEntradaCorrecto()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, "@");

            Assert.IsNull(entradaPrueba3.NombreEntrada);
            Assert.IsNotNull(entradaPrueba.NombreEntrada);
            Assert.IsNotNull(entradaPrueba2.NombreEntrada);
            Assert.IsInstanceOfType(entradaPrueba.NombreEntrada, typeof(String));
            Assert.IsInstanceOfType(entradaPrueba2.NombreEntrada, typeof(String));
            Assert.IsFalse(entradaPrueba.NombreEntrada.Equals(entradaPrueba2.NombreEntrada));
            Assert.AreEqual(entradaPrueba.NombreEntrada, nombreEntrada);
            Assert.AreEqual(entradaPrueba2.NombreEntrada, nombreEntrada2);
        }

        [TestMethod()]
        public void TestDescripcionCorrecta()
        {
            Assert.IsNotNull(entradaPrueba.Descripcion);
            Assert.IsNotNull(entradaPrueba2.Descripcion);
            Assert.IsInstanceOfType(entradaPrueba.Descripcion, typeof(String));
            Assert.IsInstanceOfType(entradaPrueba2.Descripcion, typeof(String));
            Assert.IsTrue(entradaPrueba.Descripcion.Equals(entradaPrueba2.Descripcion));
            Assert.AreEqual(entradaPrueba.Descripcion, "");
            Assert.AreEqual(entradaPrueba2.Descripcion, "");
        }

        [TestMethod()]
        public void TestUsuarioCorrecto()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);

            Assert.IsInstanceOfType(entradaPrueba.Usuario, typeof(Usuario));
            Assert.IsInstanceOfType(entradaPrueba2.Usuario, typeof(Usuario));
            Assert.IsInstanceOfType(entradaPrueba3.Usuario, typeof(Usuario));
            Assert.IsNotNull(entradaPrueba.Usuario);
            Assert.IsNotNull(entradaPrueba2.Usuario);
            Assert.IsNotNull(entradaPrueba3.Usuario);
            Assert.IsFalse(entradaPrueba.Usuario.Equals(entradaPrueba2.Usuario));
            Assert.IsTrue(entradaPrueba.Usuario.Equals(entradaPrueba3.Usuario));
            Assert.AreEqual(entradaPrueba.Usuario, usuarioPrueba);
            Assert.AreEqual(entradaPrueba2.Usuario, usuarioPrueba2);
            Assert.AreEqual(entradaPrueba3.Usuario, usuarioPrueba);
        }

        [TestMethod()]
        public void TestContrasenyaCorrecta()
        {
            Entrada entradaPruebaMal1 = new Entrada(usuarioPrueba, "1234567", nombreEntrada);
            Entrada entradaPruebaMal2 = new Entrada(usuarioPrueba, "12345678", nombreEntrada);
            Entrada entradaPruebaMal3 = new Entrada(usuarioPrueba, "abcdefghi", nombreEntrada);

            Assert.IsNull(entradaPruebaMal1.Contrasenya);
            Assert.IsNull(entradaPruebaMal2.Contrasenya);
            Assert.IsNull(entradaPruebaMal3.Contrasenya);
            Assert.IsFalse(entradaPrueba.Contrasenya.Equals(password));
            Assert.IsNotNull(entradaPrueba.Contrasenya);
            Assert.IsInstanceOfType(entradaPrueba.Contrasenya, typeof(String));
            Assert.AreEqual(entradaPrueba.Contrasenya, entradaPrueba.Encriptar(password));
            Assert.AreEqual(entradaPrueba2.Contrasenya, entradaPrueba.Encriptar(password2));
        }

        [TestMethod()]
        public void TestListaUsuariosCorrecta()
        {
            Assert.IsInstanceOfType(entradaPrueba.Usuarios, typeof(List<Usuario>));
            Assert.IsInstanceOfType(entradaPrueba2.Usuarios, typeof(List<Usuario>));
            Assert.IsNotNull(entradaPrueba.Usuarios);
            Assert.IsNotNull(entradaPrueba2.Usuarios);
            Assert.IsFalse(entradaPrueba.Usuarios.Equals(entradaPrueba2.Usuarios));
            Assert.IsTrue(entradaPrueba.Usuarios.Contains(usuarioPrueba));
            Assert.IsTrue(entradaPrueba2.Usuarios.Contains(usuarioPrueba2));
            Assert.IsTrue(entradaPrueba.Usuarios.Count == 1);
            Assert.IsTrue(entradaPrueba2.Usuarios.Count == 1);
        }

        [TestMethod()]
        public void TestaddUser()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            Usuario usuarioPrueba3 = null;

            Assert.IsTrue(entradaPrueba.Usuarios.Contains(usuarioPrueba));
            Assert.IsTrue(entradaPrueba2.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            entradaPrueba3.AddUser(usuarioPrueba2);
            entradaPrueba3.AddUser(usuarioPrueba3);
            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 2);
        }

        [TestMethod()]
        public void TestDescripcionNueva()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            entradaPrueba3.DescripcionNueva("prueba");

            Assert.IsTrue(entradaPrueba3.Descripcion == "prueba");
            Assert.IsTrue(entradaPrueba3.Descripcion != "");
            Assert.IsFalse(entradaPrueba3.Descripcion.Equals(entradaPrueba.Descripcion));
            entradaPrueba3.DescripcionNueva("saludos");

            Assert.IsTrue(entradaPrueba3.Descripcion == "saludos");
            Assert.IsTrue(entradaPrueba3.Descripcion != "prueba");
        }

        [TestMethod()]
        public void TestDeleteUser()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            Usuario usuarioPrueba3 = null;
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 1);
            entradaPrueba3.AddUser(usuarioPrueba2);
            entradaPrueba3.AddUser(usuarioPrueba3);
            usuarioPrueba.Gestor = true;

            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba));
            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 2);

            entradaPrueba3.DeleteUser(usuarioPrueba);
            entradaPrueba3.DeleteUser(usuarioPrueba2);
            entradaPrueba3.DeleteUser(usuarioPrueba3);
            Assert.IsFalse(entradaPrueba3.DeleteUser(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 1);

        }
    }
}