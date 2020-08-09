# <div align="center">NOTIFICATION MANAGEMENT SERVICE</div>

A simple notification services that sends emails and text messages while saving the status of requests 

Platform: Microsoft .NET Core 3.1.

# How to Run

  - Download and Install Visual Studio (Visual Studio Community 2019 Recommended.)
  - Run Visual Studio.
  - Select 'Clone or Checkout Code'.
  - Enter the .git url for Notification Management Service => (https://github.com/andre505/NotificationManagementService.git)
  - Click clone.
  - In the package manager console, run 'package reinstall' to reinstall all packages.
  - Run App.

### Technologies Used

    C#
    WebAPI Core
    Entity Framework Core
    Swagger UI

### Key Features Implemented
    1. SMS Delivery
    2. Email Delivery
    3. REST API
    4. SQL Database
    5. Unit Testing

### Endpoints
  - https://localhost:44384/api/message: Request Type: GET => Returns an array of all messages sent.
  - https://localhost:44384/api/message : Request Type: POST => Initiates a new message request. Parameters values differ depending on message type. E.g. 'messageType' field accepts 0 for Email and 1 for SMS.
  - https://localhost:44384/api/Message/{status} Request Type: GET => Returns a list of failed or successful requests as indicated in the 'status' parameter.


### Documentation

  - To test the endpoints using Swagger UI, the service can be accessed at http://notificationsvc-001-site1.gtempurl.com/swagger/index.html.

   - The link above contains a detailed documentation but find below sample requests and response to lend perspective.

   
  Sample Email Request
  -   {
        "to": "anthony.odu@hotmail.com",
        "from": "tonidavis01@gmail.com",
        "senderName": "Anthony Odu",
        "subject": "Test Email",
        "body": "Anthony's Notification Management Service: This is a test email. Thank you",
        "messageType": 0
      }

  Sample SMS Message Request
   -  {
        "to": "07065024754",
        "from": "Anthony Odu",
        "senderName": "",
        "subject": "",
        "body": "Anthony's Notification Management Service: This is a test message. Thank you",
        "messageType": 1
      }

  Sample Response
   -  {
        "status": "success",
        "responseCode": "00",
        "responseMessage": "Your message was sent successfully"
      }

### Error Handling

Every request with a status of 200 returns the following fields: 'status', 'responseCode' and 'responseMessage';

Error Codes:
- 00 indicates a successful request
- 01 or 02 indicates a failed request with 02 caused by an exception.


### Key Response Parameters Explained

  - MessageType of 0 represents an email message.
  - MessageType of 1 represents an sms messsage.

  In the responses for request reports (which returns an array of requests made):
  - Status of true represents a successful request.
  - Status of false represents a failed request.

### Constraints
  - To run this solution locally, replace the current appsettings.json file with with the appsettings.json file provided in the email as secret keys for both the SMS and Email providers have been removed for security. 


