# aws-user-management README.md

# AWS User Management Microservice

This project is a microservice for user management, designed to handle user authentication, registration, and profile updates. It utilizes AWS services such as S3 for profile picture storage and AuroraDB for user data management.

## Features

- User registration and login
- Profile management (update bio, name, and profile picture)
- Secure storage of profile pictures in AWS S3
- User data management using AuroraDB

## Project Structure

- **src/UserManagementService**: Contains the main application code.
  - **Controllers**: Handles HTTP requests and responses.
    - `AuthController.cs`: Manages user authentication.
    - `UserController.cs`: Manages user profile updates.
  - **Models**: Defines the data structures used in the application.
    - `User.cs`: Represents the user entity.
  - **Services**: Contains business logic and interactions with external services.
    - `AuthService.cs`: Handles authentication logic.
    - `UserService.cs`: Manages user profile updates.
    - `S3Service.cs`: Interacts with AWS S3 for profile picture storage.
  - **Data**: Contains database context and configurations.
    - `AuroraDbContext.cs`: Manages database interactions with AuroraDB.
  - `Program.cs`: Entry point of the application.
  - `appsettings.json`: Configuration settings for the application.
  - `UserManagementService.csproj`: Project file specifying dependencies and settings.

- **src/Shared/DTOs**: Contains Data Transfer Objects (DTOs) for request and response payloads.
  - `LoginRequest.cs`: Structure for login requests.
  - `RegisterRequest.cs`: Structure for registration requests.
  - `UpdateProfileRequest.cs`: Structure for profile update requests.
  - `UserResponse.cs`: Structure for user response payloads.

- **infrastructure/cloudformation**: Contains CloudFormation templates for infrastructure setup.
  - `aurora-db.yaml`: Template for setting up the AuroraDB instance.
  - `s3-bucket.yaml`: Template for creating the S3 bucket.

- **infrastructure/README.md**: Documentation for the infrastructure setup.

- **scripts/deploy.sh**: Shell script for deploying the application and infrastructure to AWS.

## Setup Instructions

1. Clone the repository.
2. Configure your AWS credentials and database connection settings in `appsettings.json`.
3. Deploy the infrastructure using the CloudFormation templates.
4. Run the application locally or deploy it to AWS.

## Usage

- Use the AuthController for user login and registration.
- Use the UserController for updating user profiles.
- Profile pictures can be uploaded and retrieved from the configured S3 bucket.

## License

This project is licensed under the MIT License.