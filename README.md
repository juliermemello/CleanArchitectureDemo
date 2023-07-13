# Clean Architecture Demo

## A Quick Introduction to Clean Architecture

In the context of ASP.NET Core, the clean architecture is implemented by organizing the application code into multiple layers which can contain one or more projects each with a specific responsibility. These layers typically include:

### Domain Layer

This layer is the backbone of the clean architecture and all other projects defined in other layers should depend on this layer. This layer is highly abstracted and it contains domain entities, events, value objects, aggregates, etc.

### Application Layer

The application business rules and use cases are available in this layer. Mostly it defines interfaces that are implemented by the outer layers. This layer contains business services, DTOs, mappers, validators, etc.

### Infrastructure Layer

This layer contains the implementation of the interfaces defined in the Application layer. This layer is responsible for implementing the technical aspects of the system, such as data access, logging, and security, etc. It can have multiple projects using different third party libraries or frameworks.

### Presentation Layer

This layer is responsible for presenting some user interface and handling user interaction with the system. It includes the views, controllers, and other web components.

## Setting Up Clean Architecture Project

To this study, we will use the concept of a contact agenda, something simple and easy to represent the necessary techniques to achieve the desired objectives.

For this study, we will use MS Visual Studio 2022 and it will have the following structure:

- Core
-- CleanArchitectureDemo.Application
-- CleanArchitectureDemo.Domain
- Infrastructure
-- CleanArchitectureDemo.Infrastructure
-- CleanArchitectureDemo.Persistence
- Presentation
-- CleanArchitectureDemo.WebAPI
- Shared
-- CleanArchitectureDemo.Shared
