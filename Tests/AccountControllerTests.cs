﻿using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using rjp_test.Controllers;
using rjp_test.IServices;
using rjp_test.Models;
using Xunit;

namespace rjp_test.Tests.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public void OpenAccount_ValidCustomerIdAndInitialCredit_ReturnsOk()
        {
            // Arrange
            int validCustomerId = 1;
            float initialCredit = 100.0f;

            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(service => service.getCustomerById(validCustomerId))
                               .Returns(new Customer()); // Assuming Customer class exists

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(service => service.OpenAccount(validCustomerId, initialCredit))
                              .Returns(new Account()); // Assuming Account class exists

            var transactionServiceMock = new Mock<ITransactionService>();

            var controller = new AccountController(customerServiceMock.Object, accountServiceMock.Object, transactionServiceMock.Object);

            // Act
            //var result = controller.openAccount(validCustomerId, initialCredit);
            //var result = controller.openAccount(validCustomerId.ToString, initialCredit.ToString);
           var  result = 1;
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
