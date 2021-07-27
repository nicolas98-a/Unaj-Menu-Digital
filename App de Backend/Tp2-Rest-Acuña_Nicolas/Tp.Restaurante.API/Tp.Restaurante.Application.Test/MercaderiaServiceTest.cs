using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.Commands;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;
using Tp.Restaurante.Domain.Queries;

namespace Tp.Restaurante.Application.Test
{
    [TestClass]
    public class MercaderiaServiceTest
    {
        private Mock<IGenericsRepository> _repository;
        private Mock<IMercaderiaQuery> _query;

        public MercaderiaServiceTest()
        {
            _repository = new Mock<IGenericsRepository>();
            _query = new Mock<IMercaderiaQuery>();
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            var  mercaderiaId = 1;
            var service = new MercaderiaService(_repository.Object, _query.Object);
            var respuestaEsperada = new ResponseGetMercaderiaById
            {
                MercaderiaId = 1

            };
            
            _query.Setup(x => x.GetById(It.IsAny<string>())).Returns(respuestaEsperada);

            // Act
            var result = service.GetById(mercaderiaId.ToString());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ResponseGetMercaderiaById));
            Assert.AreEqual(respuestaEsperada, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetByIdBeNull()
        {
            // Arrange
            var mercaderiaId = 1;
            var service = new MercaderiaService(_repository.Object, _query.Object);

            // Act
            var result = service.GetById(mercaderiaId.ToString());

            // Assert
           
        }

        [TestMethod]
        public void TestGetMercaderias()
        {
            // Arrange
            var service = new MercaderiaService(_repository.Object, _query.Object);
            List<ResponseGetAllMercaderiaDto> list = new List<ResponseGetAllMercaderiaDto>();
            ResponseGetAllMercaderiaDto mercaderiaDto1 = new ResponseGetAllMercaderiaDto
            {
                MercaderiaId = 1,
                Nombre = "Test1",
                Imagen = "Tests1",
                Ingredientes = "Test1",
                Precio = 100,
                Preparacion = "Test1",
                Tipo = "1"
            };
            ResponseGetAllMercaderiaDto mercaderiaDto2 = new ResponseGetAllMercaderiaDto
            {
                MercaderiaId = 2,
                Nombre = "Test2",
                Imagen = "Tests2",
                Ingredientes = "Test2",
                Precio = 100,
                Preparacion = "Test2",
                Tipo = "2"
            };
            list.Add(mercaderiaDto1);
            list.Add(mercaderiaDto2);

            var tipo = " ";
            _query.Setup(x => x.GetAllMercaderia(It.IsAny<string>())).Returns(list);

            // Act
            var result = service.GetMercaderias(tipo);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<ResponseGetAllMercaderiaDto>));
            Assert.AreEqual(list, result);
        }

        [TestMethod]
        public void TestUpdateMercaderiaSholdReturnTrue()
        {
            // Arrange
            var service = new MercaderiaService(_repository.Object, _query.Object);
            int id = 1;
            MercaderiaDto mercaderiaDto = new MercaderiaDto
            {
                Nombre = "NombreTest",
                TipoMercaderiaId = 1,
                Precio = 100,
                Ingredientes = "IngredientesTest",
                Preparacion = "PreparacionTest",
                Imagen = "ImagenTest"
            };
            Mercaderia mercaderia = new Mercaderia { MercaderiaId = id };
            _repository.Setup(x => x.Exists<Mercaderia>(It.IsAny<int>())).Returns(mercaderia);

            // Act
            var result = service.UpdateMercaderia(id, mercaderiaDto);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestUpdateMercaderiaSholdReturnFalse()
        {
            // Arrange
            var service = new MercaderiaService(_repository.Object, _query.Object);
            int id = 1;
            MercaderiaDto mercaderiaDto = new MercaderiaDto
            {
                Nombre = "NombreTest",
                TipoMercaderiaId = 1,
                Precio = 100,
                Ingredientes = "IngredientesTest",
                Preparacion = "PreparacionTest",
                Imagen = "ImagenTest"
            };

            // Act
            var result = service.UpdateMercaderia(id, mercaderiaDto);

            // Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestDeleteMercaderiaShouldBeTrue()
        {
            // Arrange
            var service = new MercaderiaService(_repository.Object, _query.Object);
            int id = 1;
            Mercaderia mercaderia = new Mercaderia { MercaderiaId = id };
            _repository.Setup(x => x.Exists<Mercaderia>(It.IsAny<int>())).Returns(mercaderia);

            // Act
            var result = service.DeleteMercaderia(id);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestDeleteMercaderiaShouldBeFalse()
        {
            // Arrange
            var service = new MercaderiaService(_repository.Object, _query.Object);
            int id = 1;


            // Act
            var result = service.DeleteMercaderia(id);

            // Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestCreateMercaderia()
        {
            // Arrange
            var service = new MercaderiaService(_repository.Object, _query.Object);
            MercaderiaDto mercaderiaDto = new MercaderiaDto
            {
                Nombre = "NombreTest",
                TipoMercaderiaId = 1,
                Precio = 100,
                Ingredientes = "IngredientesTest",
                Preparacion = "PreparacionTest",
                Imagen = "ImagenTest"
            };
            
            // Act
            var result = service.CreateMercaderia(mercaderiaDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(GenericCreatedResponseDto));
           
        }
    }
}
