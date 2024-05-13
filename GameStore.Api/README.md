## Setting Connection string
``` powershell
$password = "[Enter Password]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost;Database=gameStore;Uid=root;Pwd=$password;TrustServerCertificate=True"