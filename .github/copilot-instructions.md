If a new property is added to a domain model, make sure to propagate the change wherever necessary: update the DTO, add a migration, update the database, modify the integration tests, adjust the database seeder, and apply changes in any other relevant places.



If I ask you to add a new entity, implement it in the same way as the Patient entity. That means writing all its operations (commands, queries, controller), creating a database seeder, adding a migration, updating the database, writing integration tests, and handling any other necessary tasks. If you face a problem, check how I handled it in other entities or components and follow the same approach.



After completing any work, try to run all the tests without any error and build the project and make sure it builds successfully.



If you encounter any problem, avoid introducing solutions that could cause breaking changes in the project.

If a test fails, inspect the test output using `private readonly ITestOutputHelper _output;` to identify the issue and fix the test. 

If you find any enum property in an entity, configure it so that its value is stored as the enum itself in the database.



## React Application Instruction

I am new to React.js and using TypeScript. If I ask you to develop a feature or make changes (in the frontend or anywhere else), please:

- Keep the code simple, but still follow good coding practices and modern approaches.
- please use **Arrow Function Expression** for function.
- Avoid introducing breaking changes to the project.
- Remember that I don’t know much about React yet, so clarity and simplicity are important.
- Ensure that any new component or UI element is fully **responsive**.
