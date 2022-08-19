# ayo
Ayo repository

To begin running application.


navigate to the build-database directory

step-1. run docker-compose -f docker-compose.yaml up -d
step-2. in powershell/pwsh run build.ps1
step-3  while in powershell run migrate.ps1

optional-clean.ps1 to remove schema changes applied ( will have to run step 3 again)

To shut down environment run docker-compose down, this will remove  all containers and you will have to run step 1, 2,3 again, to
get the environment restored.

