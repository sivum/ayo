# ayo

## To begin running application.


1. From the root folder run docker-compose -f docker-compose.yaml up -d
2. navigate to the build-database directory
3. execute build.ps1 from powershell / powershell core
4. execute migrate.ps1 

## Supported convesrions from the api

| souce | target|description|
| ----- | ----- |-----------|
| c     | f     | celcius to fahrenheit|
| f     | c     |fahrenheit to celcius to fahrenheit|
| mm     | in     |millimeters to inches|
| in     | mm     |inches to millimeters|
| in     | cm     |inches to centimeters|
| cm     | in     |centimeters to inches|
| ft     | m     |feet  to meters|
| m     | ft     |meters  to feet|
| km     | mi     |kilometers  to miles|
| mi     | km     |miles to kilometers|