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
    public class EntradaLogTests
    {
        private const string Nombre = "Alvaro";
        private const string Apellidos = "Lopez";
        private const string Email = "Alv@ubu.es";
        private const string Password = "pass1234";
        private static Usuario usuarioPrueba = new Usuario(Nombre, Apellidos, Email, Password);

        private const string Nombre2 = "Adolfo";
        private const string Apellidos2 = "Vine";
        private const string Email2 = "Adf@ubu.es";
        private const string Password2 = "contra4321";
        private static Usuario usuarioPrueba2 = new Usuario(Nombre2, Apellidos2, Email2, Password2);


        private const String nombreEntrada = "Entrada";
        private const String nombreEntrada2 = "Entrada2";
        private static Entrada entradaPrueba = new Entrada(usuarioPrueba, Password, nombreEntrada);
        private static Entrada entradaPrueba2 = new Entrada(usuarioPrueba2, Password2, nombreEntrada2);

        private const TipoAcceso acceso = TipoAcceso.Lectura;
        private const TipoAcceso acceso2 = TipoAcceso.Escritura;
        private EntradaLog entradaLogPrueba = new EntradaLog(usuarioPrueba, entradaPrueba, acceso);
        private EntradaLog entradaLogPrueba2 = new EntradaLog(usuarioPrueba2, entradaPrueba2, acceso2);

        [TestMethod()]
        public void TestEntradaLogCreada()
        {
            EntradaLog entradaLogPrueba3 = null;
            EntradaLog entradaLogPrueba4 = new EntradaLog(null, null, acceso2);
            Assert.IsNotNull(usuarioPrueba);
            Assert.IsNotNull(usuarioPrueba2);
            Assert.IsNotNull(entradaPrueba);
            Assert.IsNotNull(entradaPrueba2);
            Assert.IsNotNull(entradaLogPrueba);
            Assert.IsNotNull(entradaLogPrueba2);
            Assert.IsNull(entradaLogPrueba3);
            Assert.IsNotNull(entradaLogPrueba4);
            Assert.IsNull(entradaLogPrueba4.Usuario);
            Assert.IsNull(entradaLogPrueba4.Entrada);
            Assert.IsTrue(entradaLogPrueba4.IdLog == -1);
            Assert.IsInstanceOfType(entradaLogPrueba, typeof(EntradaLog));
            Assert.IsInstanceOfType(entradaLogPrueba2, typeof(EntradaLog));
            Assert.IsNotInstanceOfType(entradaLogPrueba3, typeof(EntradaLog));
            Assert.IsInstanceOfType(entradaLogPrueba4, typeof(EntradaLog));
        }

        [TestMethod()]
        public void TestIdDistintas()
        {
            Assert.IsInstanceOfType(entradaLogPrueba.IdLog, typeof(Int16));
            Assert.IsInstanceOfType(entradaLogPrueba2.IdLog, typeof(Int16));
            Assert.IsTrue(entradaLogPrueba.IdLog < entradaLogPrueba2.IdLog);
            Assert.IsTrue((entradaLogPrueba.IdLog + 1) == entradaLogPrueba2.IdLog);
        }

        [TestMethod]
        public void TestFechaCorrecta()
        {
            Assert.IsInstanceOfType(entradaLogPrueba.Fecha, typeof(DateOnly));
            Assert.IsInstanceOfType(entradaLogPrueba2.Fecha, typeof(DateOnly));
            Assert.IsTrue(entradaLogPrueba.Fecha.Month <= 12 && entradaLogPrueba2.Fecha.Month <= 12);
            Assert.IsTrue(entradaLogPrueba.Fecha <= DateOnly.FromDateTime(DateTime.Now) && entradaLogPrueba2.Fecha <= DateOnly.FromDateTime(DateTime.Now));
            Assert.IsTrue(entradaLogPrueba.Fecha.Year >= 2022 && entradaLogPrueba2.Fecha.Year >= 2022);
            Assert.IsTrue(entradaLogPrueba.Fecha.Month <= 12 && entradaLogPrueba2.Fecha.Month <= 12);
            Assert.IsTrue(entradaLogPrueba.Fecha.Month >= 1 && entradaLogPrueba2.Fecha.Month >= 1);
            if (entradaLogPrueba.Fecha.Month == 1 || entradaLogPrueba.Fecha.Month == 3 || entradaLogPrueba.Fecha.Month == 5 || entradaLogPrueba.Fecha.Month == 7
                || entradaLogPrueba.Fecha.Month == 8 || entradaLogPrueba.Fecha.Month == 10 || entradaLogPrueba.Fecha.Month == 12)
            {
                Assert.IsTrue(entradaLogPrueba.Fecha.Day <= 31 && entradaLogPrueba2.Fecha.Month <= 31);
            }
            else if (entradaLogPrueba.Fecha.Month == 4 || entradaLogPrueba.Fecha.Month == 6 || entradaLogPrueba.Fecha.Month == 9 || entradaLogPrueba.Fecha.Month == 10)
            {
                Assert.IsTrue(entradaLogPrueba.Fecha.Day <= 30 && entradaLogPrueba2.Fecha.Month <= 30);
            }
            else if (entradaLogPrueba.Fecha.Month == 2 && ((entradaLogPrueba.Fecha.Year % 4 == 0 && entradaLogPrueba.Fecha.Year % 100 != 0) || entradaLogPrueba.Fecha.Year % 400 == 0))
            {
                Assert.IsTrue(entradaLogPrueba.Fecha.Day <= 29 && entradaLogPrueba2.Fecha.Month <= 29);
            }
            else
            {
                Assert.IsTrue(entradaLogPrueba.Fecha.Day <= 28 && entradaLogPrueba2.Fecha.Month <= 28);
            }

            Assert.IsTrue(entradaLogPrueba.Fecha.Day >= 1 && entradaLogPrueba2.Fecha.Month >= 1);
        }

        [TestMethod()]
        public void TestHoraCorrecta()
        {
            Assert.IsInstanceOfType(entradaLogPrueba.Hora, typeof(TimeOnly));
            Assert.IsInstanceOfType(entradaLogPrueba2.Hora, typeof(TimeOnly));
            if (entradaLogPrueba.Fecha == entradaLogPrueba2.Fecha)
            {
                Assert.IsTrue(entradaLogPrueba.Hora <= entradaLogPrueba2.Hora);
            }
            if (entradaLogPrueba2.Fecha.Equals(DateOnly.FromDateTime(DateTime.Now)))
            {
                Assert.IsTrue(entradaLogPrueba2.Hora <= TimeOnly.FromDateTime(DateTime.Now));
            }
            Assert.IsTrue(entradaLogPrueba.Hora.Hour <= 24 && entradaLogPrueba2.Hora.Hour <= 24);
            Assert.IsTrue(entradaLogPrueba.Hora.Hour >= 0 && entradaLogPrueba2.Hora.Hour >= 0);
            Assert.IsTrue(entradaLogPrueba.Hora.Minute <= 60 && entradaLogPrueba2.Hora.Minute <= 60 && entradaLogPrueba.Hora.Second <= 60 && entradaLogPrueba2.Hora.Second <= 60);
            Assert.IsTrue(entradaLogPrueba.Hora.Minute >= 0 && entradaLogPrueba2.Hora.Minute >= 0 && entradaLogPrueba.Hora.Second >= 0 && entradaLogPrueba2.Hora.Second >= 0);
        }

        [TestMethod()]
        public void TestUsuarioCorrecto()
        {
            EntradaLog entradaLogPrueba3 = new EntradaLog(usuarioPrueba, entradaPrueba, acceso);

            Assert.IsInstanceOfType(entradaLogPrueba.Usuario, typeof(Usuario));
            Assert.IsInstanceOfType(entradaLogPrueba2.Usuario, typeof(Usuario));
            Assert.IsInstanceOfType(entradaLogPrueba3.Usuario, typeof(Usuario));
            Assert.IsNotNull(entradaLogPrueba.Usuario);
            Assert.IsNotNull(entradaLogPrueba2.Usuario);
            Assert.IsNotNull(entradaLogPrueba3.Usuario);
            Assert.IsFalse(entradaLogPrueba.Usuario.Equals(entradaLogPrueba2.Usuario));
            Assert.IsTrue(entradaLogPrueba.Usuario.Equals(entradaLogPrueba3.Usuario));
            Assert.AreEqual(entradaLogPrueba.Usuario, usuarioPrueba);
            Assert.AreEqual(entradaLogPrueba2.Usuario, usuarioPrueba2);
            Assert.AreEqual(entradaLogPrueba3.Usuario, usuarioPrueba);
        }

        [TestMethod()]
        public void TestEntradaCorrecto()
        {
            EntradaLog entradaLogPrueba3 = new EntradaLog(usuarioPrueba, entradaPrueba, acceso);

            Assert.IsInstanceOfType(entradaLogPrueba.Entrada, typeof(Entrada));
            Assert.IsInstanceOfType(entradaLogPrueba2.Entrada, typeof(Entrada));
            Assert.IsInstanceOfType(entradaLogPrueba3.Entrada, typeof(Entrada));
            Assert.IsNotNull(entradaLogPrueba.Entrada);
            Assert.IsNotNull(entradaLogPrueba2.Entrada);
            Assert.IsNotNull(entradaLogPrueba3.Entrada);
            Assert.IsFalse(entradaLogPrueba.Entrada.Equals(entradaLogPrueba2.Entrada));
            Assert.IsTrue(entradaLogPrueba.Entrada.Equals(entradaLogPrueba3.Entrada));
            Assert.AreEqual(entradaLogPrueba.Entrada, entradaPrueba);
            Assert.AreEqual(entradaLogPrueba2.Entrada, entradaPrueba2);
            Assert.AreEqual(entradaLogPrueba3.Entrada, entradaPrueba);
        }

        [TestMethod]
        public void TestTipoAccesoCorrecto()
        {
            EntradaLog entradaLogPrueba3 = new EntradaLog(usuarioPrueba, entradaPrueba, acceso);

            Assert.IsInstanceOfType(entradaLogPrueba.Acceso, typeof(TipoAcceso));
            Assert.IsInstanceOfType(entradaLogPrueba2.Acceso, typeof(TipoAcceso));
            Assert.IsInstanceOfType(entradaLogPrueba3.Acceso, typeof(TipoAcceso));
            Assert.IsNotNull(entradaLogPrueba.Acceso);
            Assert.IsNotNull(entradaLogPrueba2.Acceso);
            Assert.IsNotNull(entradaLogPrueba3.Acceso);
            Assert.IsFalse(entradaLogPrueba.Acceso.Equals(entradaLogPrueba2.Acceso));
            Assert.IsTrue(entradaLogPrueba.Acceso.Equals(entradaLogPrueba3.Acceso));
            Assert.AreEqual(entradaLogPrueba.Acceso, acceso);
            Assert.AreEqual(entradaLogPrueba2.Acceso, acceso2);
            Assert.AreEqual(entradaLogPrueba3.Acceso, acceso);
        }
    }
}
