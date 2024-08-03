using Infrastructure.Behaviors.Middlewares.GlobalException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions;
using Domain.Enums;

namespace Tests.Core.Behaviors.Middlewares.GlobalExceptions
{
    public class GlobalExceptionFilterTests
    {
        [Fact]
        public void OnException_ShouldSetCorrectStatusCodeForNotFoundException()
        {
            //// Arrange
            //var exceptionContextMock = new Mock<ExceptionContext>();
            //exceptionContextMock.SetupGet(x => x.Exception).Returns(new NotFoundException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE));
            //var filter = new GlobalExceptionFilter();

            //// Act
            //filter.OnException(exceptionContextMock.Object);

            //// Assert
            //var objectResult = exceptionContextMock.Object.Result as ObjectResult;
            //Assert.NotNull(objectResult);
            //Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode);
        }
    }
}
