$name = Read-Host 'What do you want to call this migration?'

dotnet ef migrations add $name -s ../CrunchyPeanutButter.Api -p ../CrunchyPeanutButter.Data.Migrations