# CodeEdu

Aplikacja do zarządzania kursami.

## Wersja demo

https://codeedu-web.azurewebsites.net/

## Technologie

* .NET 7
* Angular 14
* Angular Materials
* xUnit

## Wymagania do uruchomienia

* .NET 7
* Nodej.js (min. v14.15)

## Przed uruchomieniem

1. Uzupełnić appsettings w projekcie CodeEdu.Web

Appsettings dla bazy demo
```json
"ConnectionStrings": {
        "CoursesContext": "server=146.59.3.245;user=CodeEdu;password=T&0Zn%5mwJ5Q;database=CodeEdu"
},
"MySql": {
  "Version": {
    "Major": 8,
    "Minor": 0,
    "Patch": 29
  }
}
```
2. Zainstalować paczki javascriptowe. W folderze **CodeEdu.Web/ClientApp** wykonać komendę
```
npm install
```
3. Jeżeli baza jest nie aktualna, uruchomić migrację.

Jeżeli nie masz jeszcze EF Core Tools, zainstalować komendą:
```
dotnet tool install --global dotnet-ef
```
W folderze **CodeEdu.Web** wykonać komendę
```
dotnet ef database update -p ../CodeEdu.Courses.Infrastructure
```
