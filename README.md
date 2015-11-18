# MSTMiniProjekt
## First Steps
- Copy from "vorlage" the .vs/ directory in the git directory
- Create a sqldb in the windows command line with the command: sqllocaldb create "MSTMiniProjekt"
- open the "AutoReservation.Database Create Script.sql" file in visual studio and run it
- write "(localdb)\MSTMiniProjekt" in the Servername fieldand click connect

## 1.3 Arbeitspakete
#### Paket 1: Data Access Layer und Business Layer (KW 47/48)
- Implementieren Sie den DAL mit dem Entity Framework.
- Implementieren Sie den Business-Layer mit den CRUD-Operationen. Die UpdateOperationen sollen Optimistic-Concurrency unterstützen.
- Schreiben Sie die geforderten Unit-Tests für den Business-Layer.

#### Paket 2: Service Layer (KW 48/49)
- Definieren Sie das Service-Interface mit den DTO’s.
- Implementieren Sie die Service-Operationen. Der Service-Layer ist auch verantwortlich
für das Konvertieren der DTO‘s in Entities resp. Entities in DTO’s sowie für das
Umsetzen der Fault-Exceptions.
- Schreiben Sie die geforderten Unit-Tests für das Service-Interface.

#### Paket 3: User-Interface (KW 50/51)
- Vervollständigen Sie das User-Interface inklusive Factory.
- Schreiben Sie die geforderten Unit-Tests für die View-Models.
