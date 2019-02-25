ColorsViewer solution consists of 4 projects:

1) ColorsViewer.DataAccess is DAL
2) ColorsViewer.Services is service layer
3) ColorsViewer.Tests contains unit tests
4) ColorsViewer is MVC projects

Predefined color scheme is stored in SQLite and accessed with EF6. File with database is located in the Data folder of MVC project. There are 20 colors and items in database file initially.
All requests to data access and service layers are made with Linq2EF.
Autofac is used as IOC for DI.
Colors are loaded asynchronously using vanilla js (ES5).
Colors sorting is implemented in the GetColors action.
NUnit and Moq are used for unit tests.

