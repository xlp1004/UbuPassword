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

        /// <summary>
        /// Test sobre creacion de entradas
        /// </summary>
        [TestMethod()]
        public void TestEntradaCreada()
        {
            Entrada entradaPrueba3 = null;
            Entrada entradaPrueba4 = new Entrada(null, null, null);
            Assert.IsNotNull(usuarioPrueba);
            Assert.IsNotNull(usuarioPrueba2);
            Assert.IsNotNull(entradaPrueba);                                    //Entradas validas
            Assert.IsNotNull(entradaPrueba2);
            Assert.IsInstanceOfType(entradaPrueba, typeof(Entrada));
            Assert.IsInstanceOfType(entradaPrueba2, typeof(Entrada));
            Assert.IsNotNull(entradaPrueba4);                                   //entrada valida con datos null
            Assert.IsInstanceOfType(entradaPrueba4, typeof(Entrada));
            Assert.IsNull(entradaPrueba4.Usuario);
            Assert.IsNull(entradaPrueba4.Contrasenya);
            Assert.IsNull(entradaPrueba4.NombreEntrada);
            Assert.IsTrue(entradaPrueba4.IdEntrada == -1);
            Assert.IsNull(entradaPrueba3);                                      //entrada no validas
            Assert.IsNotInstanceOfType(entradaPrueba3, typeof(Entrada));
        }

        /// <summary>
        /// Test sobre las id de las entradas
        /// </summary>
        [TestMethod()]
        public void TestIdDistintas()
        {
            Assert.IsInstanceOfType(entradaPrueba.IdEntrada, typeof(Int16));            //Las id son de tipo int
            Assert.IsInstanceOfType(entradaPrueba2.IdEntrada, typeof(Int16));
            Assert.IsTrue(entradaPrueba.IdEntrada < entradaPrueba2.IdEntrada);          //Las id son conjuntas
            Assert.IsTrue((entradaPrueba.IdEntrada + 1) == entradaPrueba2.IdEntrada);
        }

        /// <summary>
        /// Test sobre la valided del nombre de las entradas
        /// </summary>
        [TestMethod()]
        public void TestNombreEntradaCorrecto()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, "@");
            Entrada entradaPrueba4 = new Entrada(usuarioPrueba, password, null);


            Assert.IsNull(entradaPrueba3.NombreEntrada);                                            //Nombre de entrada no validos
            Assert.IsNull(entradaPrueba4.NombreEntrada);
            Assert.IsNotNull(entradaPrueba.NombreEntrada);                                          //Nombres de entradas validos
            Assert.IsNotNull(entradaPrueba2.NombreEntrada);
            Assert.IsInstanceOfType(entradaPrueba.NombreEntrada, typeof(String));
            Assert.IsInstanceOfType(entradaPrueba2.NombreEntrada, typeof(String));
            Assert.IsFalse(entradaPrueba.NombreEntrada.Equals(entradaPrueba2.NombreEntrada));
            Assert.AreEqual(entradaPrueba.NombreEntrada, nombreEntrada);
            Assert.AreEqual(entradaPrueba2.NombreEntrada, nombreEntrada2);
        }

        /// <summary>
        /// Test sobre la descripcion de las entradas
        /// </summary>
        [TestMethod()]
        public void TestDescripcionCorrecta()
        {
            Entrada entradaPrueba4 = new Entrada(usuarioPrueba, password, null);

            Assert.AreEqual(entradaPrueba4.Descripcion, "");                                    //Descripcion entrada no valida
            Assert.IsNotNull(entradaPrueba.Descripcion);                                        //Descripciones de entradas validas
            Assert.IsNotNull(entradaPrueba2.Descripcion);
            Assert.IsInstanceOfType(entradaPrueba.Descripcion, typeof(String));
            Assert.IsInstanceOfType(entradaPrueba2.Descripcion, typeof(String));
            Assert.IsFalse(entradaPrueba.Descripcion.Equals(entradaPrueba2.Descripcion));
            Assert.AreEqual(entradaPrueba.Descripcion, nombreEntrada);
            Assert.AreEqual(entradaPrueba2.Descripcion, nombreEntrada2);
        }

        /// <summary>
        /// Test sobre el usuario de la entrada
        /// </summary>
        [TestMethod()]
        public void TestUsuarioCorrecto()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            Entrada entradaPrueba4 = new Entrada(null, password, nombreEntrada);

            Assert.IsNull(entradaPrueba4.Usuario);                                          //Usuario de entrada no valida
            Assert.IsInstanceOfType(entradaPrueba.Usuario, typeof(Usuario));                //Usuario de entradas validas
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

        /// <summary>
        /// Test sobre la contrasenya de la entrada
        /// </summary>
        [TestMethod()]
        public void TestContrasenyaCorrecta()
        {
            Entrada entradaPruebaMal1 = new Entrada(usuarioPrueba, "1234567", nombreEntrada);
            Entrada entradaPruebaMal2 = new Entrada(usuarioPrueba, "12345678", nombreEntrada);
            Entrada entradaPruebaMal3 = new Entrada(usuarioPrueba, "abcdefghi", nombreEntrada);
            Entrada entradaPruebaMal4 = new Entrada(usuarioPrueba, null, nombreEntrada);

            Assert.IsNull(entradaPruebaMal1.Contrasenya);                                       //Contrasenyas de usuarios no validos
            Assert.IsNull(entradaPruebaMal2.Contrasenya);
            Assert.IsNull(entradaPruebaMal3.Contrasenya);
            Assert.IsNull(entradaPruebaMal4.Contrasenya);
            Assert.IsFalse(entradaPrueba.Contrasenya.Equals(password));                         //La contraseña encriptada difiere de la original
            Assert.IsNotNull(entradaPrueba.Contrasenya);                                        //Contrasenyas de usuarios validos
            Assert.IsInstanceOfType(entradaPrueba.Contrasenya, typeof(String));
            Assert.AreEqual(entradaPrueba.Contrasenya, entradaPrueba.Encriptar(password));
            Assert.AreEqual(entradaPrueba2.Contrasenya, entradaPrueba.Encriptar(password2));
        }

        /// <summary>
        /// Test sobre la lista de usuarios de la entrada
        /// </summary>
        [TestMethod()]
        public void TestListaUsuariosCorrecta()
        {
            Entrada entradaPrueba4 = new Entrada(null, password, nombreEntrada);
            Assert.IsNull(entradaPrueba4.Usuarios);                                         //Lista si no hay usuarios validos

            Assert.IsInstanceOfType(entradaPrueba.Usuarios, typeof(List<Usuario>));
            Assert.IsInstanceOfType(entradaPrueba2.Usuarios, typeof(List<Usuario>));
            Assert.IsNotNull(entradaPrueba.Usuarios);                                       //Las lista de usuarios contienen al usuario principal
            Assert.IsNotNull(entradaPrueba2.Usuarios);
            Assert.IsFalse(entradaPrueba.Usuarios.Equals(entradaPrueba2.Usuarios));
            Assert.IsTrue(entradaPrueba.Usuarios.Contains(usuarioPrueba));
            Assert.IsTrue(entradaPrueba2.Usuarios.Contains(usuarioPrueba2));
            Assert.IsTrue(entradaPrueba.Usuarios.Count == 1);
            Assert.IsTrue(entradaPrueba2.Usuarios.Count == 1);
        }

        /// <summary>
        /// Test del metodo para añadir usuarios a la lista
        /// </summary>
        [TestMethod()]
        public void TestaddUser()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            Usuario usuarioPrueba3 = null;

            Assert.IsTrue(entradaPrueba.Usuarios.Contains(usuarioPrueba));                  //Lista de usuarios por defecto
            Assert.IsTrue(entradaPrueba2.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            entradaPrueba3.AddUser(usuarioPrueba2);
            entradaPrueba3.AddUser(usuarioPrueba3);                                         //Añadir un usuario null
            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));                //Añadir un usuario distinto correctamente
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 2);                              //Contiene 2 usuarios (usuario 1 y 2)
            entradaPrueba3.AddUser(usuarioPrueba2);                                         //Añadir un usuario ya existente en la lista
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 2);                              //Contiene 2 usuarios (usuario 1 y 2)
        }

        /// <summary>
        /// Test sobre el metodo de cambiar la descripcion de la entrada
        /// </summary>
        [TestMethod()]
        public void TestDescripcionNueva()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            Assert.IsTrue(entradaPrueba3.Descripcion == nombreEntrada);                         
            entradaPrueba3.DescripcionNueva("prueba");                                          //Cambia la descripcion

            Assert.IsTrue(entradaPrueba3.Descripcion == "prueba");                              //Comprueba que es una nueva descripcion
            Assert.IsTrue(entradaPrueba3.Descripcion != nombreEntrada);
            Assert.IsFalse(entradaPrueba3.Descripcion.Equals(entradaPrueba.Descripcion));
            entradaPrueba3.DescripcionNueva("saludos");

            Assert.IsTrue(entradaPrueba3.Descripcion == "saludos");                             //Comprueba que la descripcion a cambiado otra vez
            Assert.IsTrue(entradaPrueba3.Descripcion != "prueba");
        }

        /// <summary>
        /// Test sobre el metodo de borrar un usuario de la lista de usuarios
        /// </summary>
        [TestMethod()]
        public void TestDeleteUser()
        {
            Entrada entradaPrueba3 = new Entrada(usuarioPrueba, password, nombreEntrada);
            Usuario usuarioPrueba3 = null;

            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 1);                          //Por defecto la lista solo tiene 1 usuario
            entradaPrueba3.AddUser(usuarioPrueba2);
            entradaPrueba3.AddUser(usuarioPrueba3);
            usuarioPrueba.Gestor = true;

            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba));             //Contiene a usuario 1 y 2
            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 2);

            Assert.IsFalse(entradaPrueba3.DeleteUser(usuarioPrueba));                   //Si es gestor, no se puede eliminar al usuario
            entradaPrueba3.DeleteUser(usuarioPrueba2);                                  //El usuario 2 se elimina correctamente
            Assert.IsFalse(entradaPrueba3.DeleteUser(usuarioPrueba3));                  //No se puede eliminar usuario null de la lista

            Assert.IsTrue(entradaPrueba3.Usuarios.Contains(usuarioPrueba));             //Solo contiene a usuario 1 en la lista
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba2));
            Assert.IsFalse(entradaPrueba3.Usuarios.Contains(usuarioPrueba3));
            Assert.IsTrue(entradaPrueba3.Usuarios.Count == 1);
        }

        /// <summary>
        /// Test del metodo ToString
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            Entrada entradaPrueba3 = new Entrada(null, null, null);
            Assert.AreEqual(entradaPrueba.ToString(), entradaPrueba.NombreEntrada);
            Assert.AreEqual(entradaPrueba3.ToString(), "null");

        }
    }
}