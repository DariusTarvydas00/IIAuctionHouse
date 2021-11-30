using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using IIAuctionHouse.Controllers;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IIAuctionHouse.WebApi.Test.Controllers
{
    public class AccDetailsControllerTest
    {
        #region Controller Initialization
        // Checks if AccDetailsService has AccDetailsService and is controller base type
        [Fact]
        public void AccDetailsService_HasAddressService_IsTypeOfController()
        {
            var service = new Mock<IAccDetailsService>();
            var controller = new AccDetailsController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        // Checks if AccDetailsService is null, throws exception
        [Fact]
        public void AccDetailsService_WithNullAddressService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AccDetailsService(null));
        }
        
        // Checks if AccDetailsService is null, throws exception message
        [Fact]
        public void AccDetailsService_WithNullAddressService_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "AccDetails Controller is not initialized";
            var actual = Assert.Throws<InvalidDataException>(() => new AccDetailsController(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Address Controller uses Api Controller Attribute
        [Fact]
        public void AccDetailsService_UsesApiControllerAttribute()
        {
            var typeInfo = typeof(AccDetailsController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            Assert.NotNull(attribute);
        }
        
        // Checks if ProductController is using Route Attribute
        [Fact]
        public void ProductController_UsesRouteAttribute()
        {
            var typeInfo = typeof(AccDetailsController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute"));
            Assert.NotNull(attribute);
        }
        
        // Checks if ProductController uses Route attribute with Api parameter name route
        [Fact]
        public void AccDetailsService_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            var typeInfo = typeof(AccDetailsController).GetTypeInfo();
            var attribute =
                typeInfo.GetCustomAttributes().FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute")) as
                    RouteAttribute;
            Assert.Equal("api/[controller]", attribute.Template);
        }

        #endregion
        
        #region GetAll methods

        // Checks if Controller has GetMethod
        [Fact]
        public void AccDetailsService_HasGetMethod()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        // Checks if method is public
        [Fact]
        public void GetAll_WithNoParam_IsPublic()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if method Returns List in Action Result
        [Fact]
        public void GetAll_WithNoParam_ReturnsListOfAddressesInActionResult()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<AccDetails>>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method GetAll calls Service Get once
        [Fact]
        public void GetAll_CallsServiceGetAddress_Once()
        {
            var mockService = new Mock<IAccDetailsService>();
            var controller = new AccDetailsController(mockService.Object);
            controller.GetAll();
            mockService.Verify(s=>s.ReadAll(), Times.Once);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void GetAll_HasHttpAttribute()
        {
            var methodInfo = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => m.Name == "GetAll");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attribute);
        }

        #endregion
        
        #region GetById method

        // Checks if Controller has GetById method
        [Fact]
        public void AccDetailsService_HasGetByIdMethod()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.NotNull(method);
        }

        // Checks if method is public
        [Fact]
        public void GetById_WithNoParam_IsPublic()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if GetById method returns Object in Action Result
        [Fact]
        public void GetById_Id_ReturnsAddressInActionResult()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<AccDetails>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void GetById_HasHttpAttribute()
        {
            var methodInfo = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => m.Name == "GetById");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attribute);
        }

        #endregion

        #region Post methods

        // Checks if Controller has Post method
        [Fact]
        public void AccDetailsService_HasPostMethod()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "Post".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        // Checks if method is public
        [Fact]
        public void Post_WithNoParam_IsPublic()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if Post method uses ActionResult
        [Fact]
        public void Post_Body_ReturnsObjectInActionResult()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "Post".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<AccDetails>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void Post_HasHttpAttribute()
        {
            var methodInfo = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => m.Name == "Post");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpPostAttribute");
            Assert.NotNull(attribute);
        }

        #endregion

        #region Delete method

        // Checks if Controller has Delete method
        [Fact]
        public void AccDetailsService_HasDeleteMethod()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "Delete".Equals(m.Name));
            Assert.NotNull(method);
        }

        // Checks if method is public
        [Fact]
        public void Delete_WithNoparam_IsPublic()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "Delete".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        // Checks if Delete method uses ActionResult
        [Fact]
        public void Delete_Id_ReturnsObjectInActionResult()
        {
            var method = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => "Delete".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<AccDetails>).FullName, method.ReturnType.FullName);
        }
        
        // Checks if method has Http Attribute
        [Fact]
        public void Delete_HasHttpAttribute()
        {
            var methodInfo = typeof(AccDetailsController).GetMethods().FirstOrDefault(m => m.Name == "Delete");
            var attribute =
                methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpDeleteAttribute");
            Assert.NotNull(attribute);
        }

        #endregion
        
    }
}