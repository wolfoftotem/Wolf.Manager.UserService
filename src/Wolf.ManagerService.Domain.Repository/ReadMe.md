dotnet ef migrations add init --startup-project ../Wolf.ManagerService

dotnet ef database update --startup-project ../Wolf.ManagerService
