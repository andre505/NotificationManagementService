using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationManagementSystem.Enums;
using NotificationManagementSystem.Models;
using NotificationManagementSystem.Services;

namespace NotificationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                var messages = _messageService.GetAllMessages();
                return StatusCode((int)HttpStatusCode.OK, messages);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody] MessageRequest message)
        {
            MessageResponse response = new MessageResponse();
            try
            {
                if (HasValidationError(message, out List<string> errors)) { return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", errors)); }

                // Send message
                var messageType = message.MessageType;
                var status = false;
                switch (messageType)
                {
                    case MessageType.Email:
                        status = await _messageService.SendEmailAsync(message);
                        break;
                    case MessageType.Sms:
                        status = _messageService.SendSms(message);
                        break;
                    default:
                        return StatusCode((int)HttpStatusCode.BadRequest, string.Format("Please enter a valid message type"));
                }

                // Save Message
                Message Message = new Message
                {
                    MessageType = message.MessageType,
                    Subject = message.Subject,
                    Body = message.Body,
                    From = message.From,
                    To = message.To,
                    SenderName = message.SenderName,
                    Status = status,
                    CreatedOn = DateTime.UtcNow.AddHours(1)

                };

                _messageService.AddMessage(Message);

                // Return delivery status
                if (status)
                {

                    response.status = "success";
                    response.responseCode = "00";
                    response.responseMessage = "Your message was sent successfully";
                    response.TimeStamp = DateTime.UtcNow.AddHours(1).ToString("dd/MMM/yyyy:HH:mm:ss");
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                response.status = "fail";
                response.responseCode = "01";
                response.responseMessage = "An error occurred while trying to send your message";
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                response.status = "success";
                response.responseCode = "02";
                response.responseMessage =  ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }


        [HttpGet("{status}")]
        public IActionResult Get(bool? status)
        {
            try
            {
                var messages = _messageService.GetMessagesByStatus(status);
                return StatusCode((int)HttpStatusCode.OK, messages);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        private bool HasValidationError(MessageRequest message, out List<string> errors)
        {
            errors = new List<string>();
            var messageType = message.MessageType;

            switch (messageType)
            {
                case MessageType.Email:
                    if (!ValidEmail(message.To)) { errors.Add("Please enter a valid email"); }
                    if (!ValidEmail(message.From)) { errors.Add("Please enter a valid email"); }
                    if (string.IsNullOrWhiteSpace(message.Subject)) { errors.Add("Subject cannot be empty"); }
                    break;
                case MessageType.Sms:
                    if (!ValidPhone(message.To)) { errors.Add("Please enter a valid 11 digit phone number. E.g. 07065024754"); }
                    break;
                default:
                    errors.Add("Invalid message type");
                    break;
            }

            return errors.Count > 0 ? true : false;
        }

        private bool ValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
            }

            catch { return false; }
        }

        private bool ValidPhone(string phone)
        {
            try
            {
                if ((phone.Length != 11))
                {
                    return false;

                }
                else
                {
                    return true;
                }
                //return new System.ComponentModel.DataAnnotations.PhoneAttribute().IsValid(phone);
            }

            catch { return false; }
        }
    }
}
