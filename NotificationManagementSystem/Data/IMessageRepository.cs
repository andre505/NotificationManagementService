using NotificationManagementSystem.Models;
using System.Collections.Generic;

namespace NotificationManagementSystem.Data
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessages();
        IEnumerable<Message> GetMessagesByStatus(bool? status);
        bool SaveAll();
        void AddEntity(object model);
    }
}
