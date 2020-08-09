using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationManagementSystem.Controllers;
using NotificationManagementSystem.Models;
using NotificationManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationServiceUnitTestProject
{
    [TestClass]
    public class TestMessageController
    {

        private readonly IMessageService _messageService;
        private readonly MessageController _messageAPIController;


        public TestMessageController(IMessageService messageService, MessageController messageAPIController)
        {
            _messageService = messageService;
            _messageAPIController = messageAPIController;
        }



        //Test for getting a list of all Messages sent
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            //Get Messages from DB
            var messages = _messageService.GetAllMessages();

            var result = _messageAPIController.Get() as List<Message>;
            Assert.AreEqual(messages.Count, result.Count);
        }                         

    }
}
