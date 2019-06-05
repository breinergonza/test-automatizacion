using System.Collections.Generic;
using ActividadClase.Controllers;
using Datos.Contexto;
using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace PruebasAPIs
{
    public class EquiposTest
    {
        private DbContextOptions<DbContextDatos> GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<DbContextDatos>()
                .UseInMemoryDatabase("ConexionDatos")
                .Options;
            return options;
        }

        [Fact]
        public void ObtenerEquiposTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new EquiposController(db);

            // Act
            var respuesta = _param.GetEquipo().Result as OkObjectResult;
            
            // Assert
            Assert.IsType<List<Equipos>>(respuesta.Value);

        }


        [Fact]
        public void ObtenerUnEquiposTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new EquiposController(db);
            int idEquiposConsultar = 1;

            // Act
            var respuesta = _param.GetEquipos(idEquiposConsultar).Result as OkObjectResult;

            // Assert
            Assert.IsType<Equipos>(respuesta.Value);

        }
    }
}
