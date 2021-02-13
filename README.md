# .NET TP

## Créateur

  ##### Jassim EL HAROUI 
  ##### Zakaria GASMI 
  ##### Hassan MAZYAD
  ##### Janssen KOUBIKANI

## But

Construire un service d’une bibliothèque en ligne avec son client Windows

## Base de données

Atlas MongoDb en ligne (Tout est déjà configuré pour la communication avec la BD)

  * Une liste de livres accessibles à la lecture

  * Une liste de genres permettant de caractériser les livres

  * Un livre contient au minimum :

        o Un titre

        o Un contenu

        o Un prix

        o Des genres

  * Exemple JSON d'un livre avec un seul genre

       ```json
       {"Id":1,"Title":"FluconazoleE","Contenu":"nonummy ultricies ...","Prix":19,"Genre":[{"Id":6,"Nom":"Science"}]}
       ```
        
  * Exemple JSON d'un livre avec plusieurs genres

       ```json
       {"Id":1500,"Title":"FluconazoleE","Contenu":"nsenectus et ...","Prix":19,"Genre":[{"Id":6,"Nom":"Science"},{"Id":2,"Nom":"Biographie"}]}
       ```

## API

API REST mis à disposition pour permettre à des clients externes de consulter la librairie

### Lister les livres

#### Request

       ```bash
       GET https://localhost:5001/api/Books/all
       ```

#### Response

       ```json
       {"Id":1,"Title":"FluconazoleE","Contenu":"nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna,","Prix":19,"Genre":[{"Id":6,"Nom":"Science"}]},{"Id":2,"Title":"Lorazepam","Contenu":"vehicula. Pellentesque tinc_idunt tempus risus. Donec egestas. Duis ac","Prix":1163,"Genre":[{"Id":5,"Nom":"M\u00E9dicale"}]}....
       ```

### Récupérer un livre précis avec son contenu (soit en utilisant son ID, soit son Titre)

#### Request

  * Par ID

       ```bash
       GET https://localhost:5001/api/Books/id/1
       ```

  * Par titre

       ```bash
       GET https://localhost:5001/api/Books/titles/FluconazoleE
       ```

#### Response

  * Par ID

       ```json
       {"Id":1,"Title":"FluconazoleE","Contenu":"nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna,","Prix":19,"Genre":[{"Id":6,"Nom":"Science"}]}
       ```

  * Par titre

       ```json
       {"Id":1,"Title":"FluconazoleE","Contenu":"nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna,","Prix":19,"Genre":[{"Id":6,"Nom":"Science"}]},{"Id":1000,"Title":"FluconazoleE","Contenu":"nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna,","Prix":19,"Genre":[{"Id":6,"Nom":"Science"}]},{"Id":1500,"Title":"FluconazoleE","Contenu":"nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna,","Prix":19,"Genre":[{"Id":6,"Nom":"Science"},{"Id":2,"Nom":"Biographie"}]}
       ```

## Administration

  * Interface web **affiche la liste des livres** et permet de **CONSULTER LES DETAILS** d'un livre, **MODIFIER**, **AJOUTER** ou **SUPPRIMER** un livre disponible dans la bibliothèque

  * Interface web **affiche la liste des genres** et permet de **CONSULTER LES DETAILS** d'un genre, **MODIFIER**, **AJOUTER** ou **SUPPRIMER** un genre


