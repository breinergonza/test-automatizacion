using System;
using System.Collections.Generic;
using ActividadClase.Controllers;
using Datos.Contexto;
using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace PruebasAPIs
{
    public class ProyectosTest
    {
        private DbContextOptions<DbContextDatos> GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<DbContextDatos>()
                .UseInMemoryDatabase("ConexionDatos")
                .Options;
            return options;
        }

        [Fact]
        public void ObtenerProyectosTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new ProyectosController(db);

            // Act
            var respuesta = _param.GetProyecto().Result as OkObjectResult;
            
            // Assert
            Assert.IsType<List<Proyectos>>(respuesta.Value);

        }


        [Fact]
        public void ObtenerUnProyectosTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new ProyectosController(db);
            int idProyectosConsultar = 1;

            // Act
            var respuesta = _param.GetProyectos(idProyectosConsultar).Result as OkObjectResult;

            // Assert
            Assert.IsType<Proyectos>(respuesta.Value);

        }
    }
}
