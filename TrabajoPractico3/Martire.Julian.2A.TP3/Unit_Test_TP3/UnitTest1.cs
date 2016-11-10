using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace Unit_Test_TP3
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valida que el dni del ARGENTINO sea entre 1 y 90.000.000
        /// </summary>
        [TestMethod]
        public void ValidarDocumentoArgentino()
        {
            Random random = new Random();
            int dniNuevo = random.Next(1, 90000000);

            Alumno a1 = new Alumno(1990, "Jorge", "Lopez", dniNuevo.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);

            Assert.AreEqual(a1.DNI, dniNuevo);
        }
        /// <summary>
        /// Valida que el dni del EXTRANJERO sea entre 90.000.000 y 100.000.000
        /// </summary>
        [TestMethod]
        public void ValidarDocumentoExtranjero()
        {
            Random random = new Random();
            int dniNuevo = random.Next(90000000,100000000);

            Alumno a1 = new Alumno(1990, "Jorge", "Lopez", dniNuevo.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit);

            Assert.AreEqual(a1.DNI, dniNuevo);
        }
        /// <summary>
        /// Valida que el GIMNASIO este Instanciado
        /// </summary>
        [TestMethod]
        public void GimnasioNoInstanciado()
        {
            Gimnasio g1 = new Gimnasio();

            Assert.AreNotEqual(null, g1.Instructores);
            Assert.AreNotEqual(null, g1.Alumnos);

            Assert.IsNotNull(g1);
        }
        /// <summary>
        /// Valida que el ALUMNO esta instanciado
        /// </summary>
        [TestMethod]
        public void AlumnoNoInstanciado()
        {
            Alumno a1 = new Alumno(1990, "Jorge", "Lopez", "40916958", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);

            Assert.AreNotEqual(null, a1.Nombre);
            Assert.AreNotEqual(null, a1.Apellido);
            Assert.AreNotEqual(null, a1.DNI);
            Assert.AreNotEqual(null, a1.Nacionalidad);

            Assert.IsNotNull(a1);
        }
        /// <summary>
        /// Valida que el ALUMNO no se repita.
        /// </summary>
        [TestMethod]
        public void AlumnoRepetido()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Jorge", "Lopez", "40916958", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);
                Alumno a2 = new Alumno(2, "Jorge", "Lopez", "40916958", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);

                Gimnasio gimnasioPrueba = new Gimnasio();

                gimnasioPrueba += a1;
                gimnasioPrueba += a2;

                Assert.Fail("Alumno repetido");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Valida que el INSTRUCTOR esta instanciado
        /// </summary>
        [TestMethod]
        public void InstructorNoInstanciado()
        {
            Instructor i = new Instructor(1990, "Jorge", "Lopez", "40916958", Persona.ENacionalidad.Argentino);

            Assert.AreNotEqual(null, i.Nombre);
            Assert.AreNotEqual(null, i.Apellido);
            Assert.AreNotEqual(null, i.DNI);
            Assert.AreNotEqual(null, i.Nacionalidad);

            Assert.IsNotNull(i);
        }
        
    }
}
