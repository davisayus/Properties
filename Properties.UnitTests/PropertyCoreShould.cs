using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Properties.Core.Core.V1;
using Properties.Core.Core.V1.Mapping;
using Properties.Entities.Dtos;
using Properties.Entities.Entities;
using Properties.UnitTests.RepositoryTests;
using System;
using Xunit;

namespace Properties.UnitTests
{
    public class PropertyCoreShould
    {
        private readonly PropertyCore _propertyCore;

        public PropertyCoreShould()
        {
            var mockLogger = new Mock<ILogger<Property>>();
            ILogger<Property> logger = mockLogger.Object;

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            PropertyRepositoryTest repositoryTest = new PropertyRepositoryTest();
            _propertyCore = new PropertyCore(repositoryTest, logger, mapper);

        }

        [Fact]
        public async void SuccessAddAsync()
        {
            //Arrange: Definir las variables que vamos necesitar para probar el metodo de la clase
            PropertyCreateDto property = new PropertyCreateDto() 
            {
                IdType =1,
                IdOwner =1,
                Name ="White House",
                Description = "House of 120m2 3 rooms 2 bathrooms, a large balcony, integral kitchen",
                Area = 120,
                Address = "Street 24 avenue little River",
                City ="Miami",
                State ="FL",
                ZipCode = "33147",
                Year = 2015,
                MainImage = new FormFile(System.IO.Stream.Null, 0, 0,"",""),
                Price = 35000,
                CodeInternal ="1234",
                Status = "A"
            };

            //Act: Ejecuto el metodo que deseo testear y almaceno el valor en una variable 
            var result = await _propertyCore.AddAsync(property, @"C:\Davis\Personal\Willow\Challenge\Properties\Properties.WebAPI\PropertyImages");

            //Assert: Realiza la comparacion o validacion del resultado
            Assert.False(result.HasError);
        }
    }
}
