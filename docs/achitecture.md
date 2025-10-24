## Architecture Overview

### Backend (.NET Core API)

- **Presentation Layer**: `Controllers/` handle HTTP requests and responses.
- **Application Layer**: `Services/` contain business logic and coordinate domain operations.
- **Domain Layer**: `Models/` define Entities and Value Objects representing core business concepts.
- **Data Access Layer**: `Data/` contains Repositories for database interaction.
- **DTOs**: `DTOs/` are used for data transfer between layers.

### Infrastructure

- **CloudFormation Templates**: `infrastructure/cloudformation/` defines AWS resources (Aurora DB, S3, etc).
- **Deployment Scripts**: `scripts/deploy.sh` automates infrastructure deployment.

### Frontend (React)

- **API Layer**: `src/api/userApi.js` handles communication with the backend.
- **Components**: `src/components/` contains UI components (e.g., `LoginForm.js`).
- **App Structure**: `App.js` and `index.js` bootstrap the React application.

### DDD Mapping

- **Entities/Value Objects**: `src/UserManagementService/Models/`
- **Repositories**: `src/UserManagementService/Data/`
- **Domain Services**: `src/UserManagementService/Services/`
- **DTOs**: `src/UserManagementService/DTOs/`