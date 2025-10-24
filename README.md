## Domain Driven Design (DDD) Approach

This project follows Domain Driven Design (DDD) principles:

- **Bounded Contexts**: The backend is organized around the User Management domain.
- **Entities & Value Objects**: Business logic is encapsulated in the `Models` folder.
- **Repositories**: Data access logic is separated in the `Data` folder.
- **Domain Services**: Business operations are implemented in the `Services` folder.
- **DTOs**: Data Transfer Objects are used for communication between layers.

This structure ensures a clear separation of concerns and aligns the codebase with business concepts.