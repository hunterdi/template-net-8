Remove-Migration -p RPGApi -c ApplicationContextDB -Force
Add-Migration AddEntityFileMigration -p RPGApi -c ApplicationContextDB -o Migrations/Postgres
Update-Database -Context ApplicationContextDB



https://medium.com/@oasiegbulam/enhancing-class-to-record-mapping-in-c-with-automapper-exploring-forctorparam-and-constructusing-e5f9cf91aab1
