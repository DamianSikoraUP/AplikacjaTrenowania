Opis instalacji

![image](https://github.com/user-attachments/assets/621ecfbe-e26e-4115-b077-8d8c5666a0b2)
![image](https://github.com/user-attachments/assets/839b4596-5f64-48ca-aff4-52492a18291a)
![image](https://github.com/user-attachments/assets/47f4d26e-8507-4981-9255-78e4b05daaa2)
![image](https://github.com/user-attachments/assets/a30b8a44-de72-421a-8c59-64a011086b21)
![image](https://github.com/user-attachments/assets/0e3b25c0-6b6c-4028-8b49-b9cd03ad60fd)
![image](https://github.com/user-attachments/assets/3da52bdc-d9b4-4191-ada6-1e68112bf7cb)
![image](https://github.com/user-attachments/assets/ce955320-9bb4-44ce-bc8a-23bef01df450)
![image](https://github.com/user-attachments/assets/2cac0f05-79d4-435b-9e48-17e82d4dc31a)
![image](https://github.com/user-attachments/assets/a5d7667f-c395-4595-a667-cc7a5d00a640)
Add-Migration Migracja
Update-Database

Wymagania:
SQL Server Developer Edition
SQL Server Management Studio 20
Visual studio 2022
Opracowywanie zawartości dla platformy ASP.NET
Programowanie aplikacji klasycznych dla platformy .NET
.NET 8.0
Microsoft.Asp.NetCore.Identity.EntityFrameworkCore 8.0.11
Microsoft.AspNetCore.Identity.UI 8.0.11
Microsoft.EntityFrameworkCore 8.0.11
Microsot.EntityFrameworkCore.Design 8.0.11
Microsoft.EntityFrameworkCore.SqlServer 8.0.11
Microsoft.EntityFrameworkCore.Tools 8.0.11
Microsoft.VisualStudio.Web.CodeGeneration.Design 8.0.7

Łańcuch połączenia z bazą
"ApplicationDBContextConnection": "Server=Server name;Database=AplikacjaTrenowania;Trusted_Connection=True;TrustServerCertificate=True;"
Server name należy zamienić na wartość Server name z aplikacji SQL Server Management Studio

Użytkownicy testowi
user@user.com
zaq1@WSX
admin@admin.com
zaq1@WSX

Opis działania aplikacji z punktu widzenia użytkownika:
Użytkownik może stworzyć konto i się na nie zalogować. Użytkownik ma możliwość wejścia w zakładkę Trening, w której pokazuje mu się opcja dodania trenowanego przez siebie ćwiczenia wraz z liczbą powtórzeń oraz kilogramami. Ćwiczenia te zapisują się na jego koncie wraz z datą i godziną.
Użytkownik może usunąć ćwiczenie, może również je edytować oraz wyświetlić jego detale, czyli wcześniej wspomnianą ilość powtórzeń oraz kilogramy. Administrator dodatkowo ma dostęp do zakładki Dodaj Kategorię. Po naciśnięciu jej ma możliwość dodać nową kategorię ćwiczeń, którą on lub
użytkownik będzie mógł następnie użyć do zapisania swojego treningu.
