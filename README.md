# .NET TP

## Créateur

  ##### Jassim EL HAROUI 
  ##### Zakaria GASMI 
  ##### Hassan MAZYAD
  ##### Janssen KOUBIKANI

## But

Construire un service d’une bibliothèque en ligne avec son client Windows

## Fonctionnalités

### Base de données

Atlas MongoDb en ligne (Tout est déjà configuré pour la communication avec la BD)

  * Une liste de livres accessibles à la lecture

  * Une liste de genres permettant de caractériser les livres

  * Un livre contient au minimum :

        o Un titre

        o Un contenu

        o Un prix

        o Des genres

  * Exemple JSON d'un livre avec un seul genre

        ;;;
        {"Id":1,"Title":"FluconazoleE","Contenu":"nonummy ultricies ...","Prix":19,"Genre":[{"Id":6,"Nom":"Science"}]}
        ;;;
  
  * Exemple JSON d'un livre avec plusieurs genres

        ;;;
  {"Id":1500,"Title":"FluconazoleE","Contenu":"nsenectus et ...","Prix":19,"Genre":[{"Id":6,"Nom":"Science"},{"Id":2,"Nom":"Biographie"}]}
          ;;;


