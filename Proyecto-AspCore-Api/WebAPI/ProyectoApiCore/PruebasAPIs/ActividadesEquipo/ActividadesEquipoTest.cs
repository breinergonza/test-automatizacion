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
    public class ActividadesEquipoTest
    {
        private DbContextOptions<DbContextDatos> GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<DbContextDatos>()
                .UseInMemoryDatabase("ConexionDatos")
                .Options;
            return options;
        }

        [Fact]
        public void ObtenerActividadesEquipoTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new ActividadesEquipoController(db);

            // Act
            var respuesta = _param.GetActividadEquipo().Result as OkObjectResult;
            
            // Assert
            Assert.IsType<List<ActividadesEquipo>>(respuesta.Value);

        }


        [Fact]
        public void ObtenerUnaActvidadEquipoTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new ActividadesEquipoController(db);
            int idActividadesEquipoConsultar = 1;

            // Act
            var respuesta = _param.GetActividadesEquipo(idActividadesEquipoConsultar).Result as OkObjectResult;

            // Assert
            Assert.IsType<ActividadesEquipo>(respuesta.Value);

        }
    }
}
