using NotificationManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotificationManagementSystem.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageDbContext _ctx;

        public MessageRepository(MessageDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            try
            {
                return _ctx.Messages
                           .OrderByDescending(p => p.CreatedOn)
                           .ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Message> GetMessagesByStatus(bool? status)
        {
            if (status == true || status == false) 
            {
                return GetAllMessages().Where(p => p.Status == status);
            }
            return GetAllMessages();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
