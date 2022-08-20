# ayo

## To begin running application.


1. From the root folder run docker-compose -f docker-compose.yaml up -d
2. navigate to the build-database directory
3. execute build.ps1 from powershell / powershell core
4. execute migrate.ps1 

The api will run by default on localhost:8000

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


![image](https://user-images.githubusercontent.com/14750396/185745301-d2aebcf0-cdc3-450c-9bb1-ab03d799b0a2.png)

## Unsupported conversions will throw invalid operation exception by design.

![image](https://user-images.githubusercontent.com/14750396/185745505-a9bcdfba-2c84-40cd-8243-82c7e73f658e.png)

