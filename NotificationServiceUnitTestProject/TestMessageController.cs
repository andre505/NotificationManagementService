using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationManagementSystem.Controllers;
using NotificationManagementSystem.Models;
using NotificationManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NotificationManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NotificationServiceUnitTestProject
{
    [TestClass]
    public class TestMessageController
    {

        private readonly MessageDbContext _dbContext;
        private readonly IMessageRepository _messageRepository;


        public TestMessageController()
        {

            _dbContext = new InMemoryDbContextFactory().GetMessagesDbContext();
            _messageRepository = new MessageRepository(_dbContext);
        }

        [TestMethod]
        public void GetAllMessages_ShouldReturnAllMessages()
        {

            var articleId = 5;
            var messages = new List<Message>
            {
            new Message { Id = 25, Body="Test Body 1", CreatedOn = DateTime.UtcNow, From = "tonidavis01@gmail.com", To = "tony.odu91@gmail.com", MessageType = 0, SenderName = "Anthony Odu", Status = true, Subject = "Test SUbject 1" },
            new Message { Id = 26, Body="Test Body 2", CreatedOn = DateTime.UtcNow, From = "tonidavis01@gmail.com", To = "tony.odu91@gmail.com", MessageType = 0, SenderName = "Anthony Odu", Status = true, Subject = "Test SUbject 2" }
            };
            _dbContext.Messages.AddRange(messages);
            _dbContext.SaveChanges();

            var actual = _messageRepository.GetAllMessages();
            Assert.IsNotNull(actual);
        }


        public class InMemoryDbContextFactory
        {
            public MessageDbContext GetMessagesDbContext()
            {
                var options = new DbContextOptionsBuilder<MessageDbContext>()
                                .UseInMemoryDatabase(databaseName: "InMemoryMessageDatabase")
                                .Options;
                var dbContext = new MessageDbContext(options);

                return dbContext;
            }
        }


    }
}
