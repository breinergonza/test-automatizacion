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
    public class IntegrantesTest
    {
        private DbContextOptions<DbContextDatos> GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<DbContextDatos>()
                .UseInMemoryDatabase("ConexionDatos")
                .Options;
            return options;
        }

        [Fact]
        public void ObtenerIntegrantesTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new IntegrantesController(db);

            // Act
            var respuesta = _param.GetIntegrantes().Result as OkObjectResult;
            
            // Assert
            Assert.IsType<List<Integrantes>>(respuesta.Value);

        }


        [Fact]
        public void ObtenerUnIntegrantesTest()
        {
            // Arrange
            var db = new DbContextDatos(GetInMemoryRepository());
            var _param = new IntegrantesController(db);
            int idIntegranteConsultar = 1;

            // Act
            var respuesta = _param.GetIntegrante(idIntegranteConsultar).Result as OkObjectResult;

            // Assert
            Assert.IsType<Integrantes>(respuesta.Value);

        }
    }
}
