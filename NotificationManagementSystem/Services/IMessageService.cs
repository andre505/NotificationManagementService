using NotificationManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationManagementSystem.Services
{
    public interface IMessageService
    {
        Task<bool> SendEmailAsync(MessageRequest message);
        bool SendSms(MessageRequest message);
        List<Message> GetAllMessages();
        List<Message> GetMessagesByStatus(bool? status);
        void AddMessage(Message message);
    }
}
