
# ProChess

## Onion Architecture / Clean Architecture

Onion Architecture is based on the inversion of control principle. 
Onion Architecture is comprised of multiple concentric layers interfacing each other towards 
the core that represents the domain. The architecture does not depend on the data layer as in 
classic multi-tier architectures, but on the actual domain models.

### Domain Layer

At the center part of the Onion Architecture, the domain layer exists; this layer represents 
the business and behavior objects. The idea is to have all of your domain objects at this core. 
It holds all application domain objects. Besides the domain objects, you also could have domain interfaces. 
These domain entities don’t have any dependencies. Domain objects are also flat as they should be, without 
any heavy code or dependencies.

### Repository Layer

This layer creates an abstraction between the domain entities and business logic of an application. 
In this layer, we typically add interfaces that provide object saving and retrieving behavior typically 
by involving a database. This layer consists of the data access pattern, which is a more loosely coupled 
approach to data access. We also create a generic repository, and add queries to retrieve data from the source, 
map the data from data source to a business entity, and persist changes in the business entity to the data source.

### Services Layer

The Service layer holds interfaces with common operations, such as Add, Save, Edit, and Delete. 
Also, this layer is used to communicate between the UI layer and the repository layer. 
The Service layer also could hold business logic for an entity. In this layer, service interfaces are 
kept separate from its implementation, keeping loose coupling and separation of concerns in mind.

### UI / Web API Layer

It’s the outer-most layer, and keeps peripheral concerns like UI and tests. For a Web application, 
it represents the Web API or Unit Test project. This layer has an implementation of the dependency 
injection principle so that the application builds a loosely coupled structure and can communicate to the 
internal layer via interfaces.

### Benefits of Onion Architecture

- Better sustainability over time with simplified indexing
- Reduce dependencies within your platform
- Loose coupling between layers
- Flexible infrastructure enabling free range use of data
- Removes the need for common or shared documents/projects
- Data Access and UI layers are reduced in size and complexity
