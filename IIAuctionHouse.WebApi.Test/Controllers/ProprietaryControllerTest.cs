using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using IIAuctionHouse.Controllers;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IIAuctionHouse.WebApi.Test.Controllers
{
    public class ProprietaryControllerTest
    {
        #region Controller Initialization
        // Checks if ProprietaryController has ProprietaryService and is controller base type
        [Fact]
        public void ProprietaryController_HasProprietaryService_IsTypeOfController()
        {
            var service = new Mock<IProprietaryService>();
            var controller = new ProprietaryController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        // Checks if ProprietaryController is null, throws exception
        [Fact]
        public void ProprietaryController_WithNullProprietaryService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new ProprietaryController(null));
        }
        
        // Checks if ProprietaryController is null, throws exception message
        [Fact]
        public void ProprietaryController_WithNullProprietaryService_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Proprietary Controller is not initialized";
            var actual = Assert.Throws<InvalidDataException>(() => new ProprietaryController(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Proprietary Controller uses Api Controller Attribute
        [Fact]
        public void ProprietaryController_UsesApiControllerAttribute()
        {
            var typeInfo = typeof(ProprietaryController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            Assert.NotNull(attribute);
        }
        
        // Checks if ProductController is using Route Attribute
        [Fact]
        public void ProductController_UsesRouteAttribute()
        {
            var typeInfo = typeof(ProprietaryController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute"));
            Assert.NotNull(attribute);
        }
        
        // Checks if ProductController uses Route attribute with Api parameter name route
        [Fact]
        public void ProprietaryController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            var typeInfo = typeof(ProprietaryController).GetTypeInfo();
            var attribute =
                typeInfo.GetCustomAttributes().FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute")) as
                    RouteAttribute;
            Assert.Equal("api/[controller]", attribute.Template);
        }

        #endregion
        
        #region GetAll methods

        // Checks if Controller has GetMethod
        [Fact]
        public void ProprietaryController_HasGetMethod()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        // Checks if method is public
        [Fact]
        public void GetAll_WithNoParam_IsPublic()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if method Returns List in Action Result
        [Fact]
        public void GetAll_WithNoParam_ReturnsListOfProprietaryesInActionResult()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<Proprietary>>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method GetAll calls Service Get once
        [Fact]
        public void GetAll_CallsServiceGetProprietary_Once()
        {
            var mockService = new Mock<IProprietaryService>();
            var controller = new ProprietaryController(mockService.Object);
            controller.GetAll();
            mockService.Verify(s=>s.ReadAll(), Times.Once);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void GetAll_HasHttpAttribute()
        {
            var methodInfo = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => m.Name == "GetAll");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attribute);
        }

        #endregion
        
        #region GetById method

        // Checks if Controller has GetById method
        [Fact]
        public void ProprietaryController_HasGetByIdMethod()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.NotNull(method);
        }

        // Checks if method is public
        [Fact]
        public void GetById_WithNoParam_IsPublic()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if GetById method returns Object in Action Result
        [Fact]
        public void GetById_Id_ReturnsProprietaryInActionResult()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<Proprietary>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void GetById_HasHttpAttribute()
        {
            var methodInfo = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => m.Name == "GetById");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attribute);
        }

        #endregion

        #region Post methods

        // Checks if Controller has Post method
        [Fact]
        public void ProprietaryController_HasPostMethod()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "Post".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        // Checks if method is public
        [Fact]
        public void Post_WithNoParam_IsPublic()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if Post method uses ActionResult
        [Fact]
        public void Post_Body_ReturnsObjectInActionResult()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "Post".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<Proprietary>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void Post_HasHttpAttribute()
        {
            var methodInfo = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => m.Name == "Post");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpPostAttribute");
            Assert.NotNull(attribute);
        }

        #endregion

        #region Delete method

        // Checks if Controller has Delete method
        [Fact]
        public void ProprietaryController_HasDeleteMethod()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "Delete".Equals(m.Name));
            Assert.NotNull(method);
        }

        // Checks if method is public
        [Fact]
        public void Delete_WithNoparam_IsPublic()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "Delete".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if Delete method uses ActionResult
        [Fact]
        public void Delete_Id_ReturnsObjectInActionResult()
        {
            var method = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => "Delete".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<Proprietary>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void Delete_HasHttpAttribute()
        {
            var methodInfo = typeof(ProprietaryController).GetMethods().FirstOrDefault(m => m.Name == "Delete");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpDeleteAttribute");
            Assert.NotNull(attribute);
        }

        #endregion
    }
}