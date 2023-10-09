# Task_Unis

## Database Requests

This implementation performs GET and POST requests from a given URL.
- GetUnis (GET) returns the written database with information derived from the URL. Data are deserialized (from jSON format) to acceptable for our purposes data format.
- GetUniName (GET) returns all the universities, which contain the requested term. A term must be provided (Required).
- PostCountry (POST) returns all the Universities, which are located in the requested country.
- PostUnis (POST) adds a new University instance with the information that are being given.

## Database

For the database, we employ MariaDB, pulled from the DockerHub (latest).
The database can be initiated with the following command:
```
docker run -dp 3306:3306 --network todo-app --network-alias mariadb -v uni-data:/var/lib/maria -e MYSQL_ROOT_PASSWORD=mypass -e MYSQL_DATABASE=Universities mariad
```
In case you decide to change the password, you must change it accordingly in the appsettings.json file.
You may gain access to the database with the following command:
```
docker ps
```
Which will return the < containerID > which is everytime differentiated, and then:
```
docker exec -it <containerID> mariadb -p
```
You may see additional information by utilizing queries after entering the database:
```
use Universities;
```
