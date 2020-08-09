# <div align="center">NOTIFICATION MANAGEMENT SERVICE</div>

A simple notification services that sends emails and text messages while saving the status of requests 

Platform: Microsoft .NET Core 3.1.

# How to Run

  - Download and Install Visual Studio (Visual Studio Community 2019 Recommended.)
  - Run Visual Studio.
  - Select 'Clone or Checkout Code'.
  - Enter the .git url for Notification Management Service => (https://github.com/andre505/NotificationManagementService.git)
  - Click clone.
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
  - https://localhost:44384/api/message : Request Type: POST => Makes a new message request.
  - https://localhost:44384/api/Message/{status} Request Type: GET => Returns a list of failed or successful requests as indicated in the 'status' parameter.


    To test the endpoints using Swagger UI, the service can be accessed at http://notificationsvc-001-site1.gtempurl.com/swagger/index.html.


### Key Things to Note with API Response
  - Status of true represents a successful request.
  - Status of false represents a failed request.
  - MessageType of 0 represents an email message.
  - MessageType of 1 represents an sms messsage.

### Constraints
  - Since the test account created with the SMS provider is a trial account, SMS messages will only be delivered to registered phone numbers. To test the SMS functionality, please contact me on 07065024754 to supply me with a valid phone number to be whitelisted.


