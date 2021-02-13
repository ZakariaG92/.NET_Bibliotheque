const uri = 'api/Books/all';
const uriAllGenres = 'api/Genres/all';
const uriBook = 'api/Books';
let todos = [];

// Recuperer tous les livres
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

// Recuperer tous les genres pour le choix lors de l'ajout d'un nouveau livre
function getGenresForEdit() {
    fetch(uriAllGenres)
        .then(response => response.json())
        // On va remplir la liste <select> pour le POST/PUT des livres 
        // Text = Nom du genre  //  Value = Id du genre (ça va etre utile)
        .then(data => {
            data.forEach(item => {
                var select1 = document.getElementById("edit-Genre");

                    var opt1 = item.Nom;
                    var el1 = document.createElement("option");
                    el1.textContent = opt1;
                    el1.value = item.Id;
                    select1.appendChild(el1);
            })
        })
        .catch(error => console.error('Unable to get items.', error));   
}

// Recuperer tous les genres pour le choix lors de la modification d'un nouveau livre
function getGenresForAdd() {
    fetch(uriAllGenres)
        .then(response => response.json())
        // On va remplir la list <select> pour le POST/PUT des livres 
        // Text = Nom du genre  //  Value = Id du genre (ça va etre utile)
        .then(data => {
            data.forEach(item => {
                //tabGenres.push(item.Nom);
                var select = document.getElementById("selectGenre");

                var opt = item.Nom;
                var el = document.createElement("option");
                el.textContent = opt;
                el.value = item.Id;
                select.appendChild(el);

            })
        })
        .catch(error => console.error('Unable to get items.', error));
}

/*function afficherGenres() {

    tabGenres.forEach(function (item, index, array) {
        console.log(item, index);
    });

    var select = document.getElementById("selectGenre");

    for (var i = 0; i < tabGenres.length; i++) {
        var opt = tabGenres[i];
        var el = document.createElement("option");
        el.textContent = opt;
        el.value = opt;
        select.appendChild(el);
    }
}*/


// Ajouter un livre
function addItem() {

    const addIdTextbox = document.getElementById('Id');
    const addTitleTextbox = document.getElementById('Title');
    const addContenuTextbox = document.getElementById('Contenu');
    const addPrixTextbox = document.getElementById('Prix');
    const addGenreTextbox = document.getElementById('selectGenre');


    // On va recupérer les choix multiples de Genres
    let GenreChoix = []
    for (var i = 0; i < addGenreTextbox.options.length; i++) {
        if (addGenreTextbox.options[i].selected) {
            let result = {};
            result["id"] = addGenreTextbox.options[i].value;
            result["Nom"] = addGenreTextbox.options[i].text.trim();
            GenreChoix.push(result);
        }
    }

    /*GenreChoix.forEach(function (item, index, array) {
        console.log(item, index);
    });*/

    const item = {

        id: Number(addIdTextbox.value.trim()),
        title: addTitleTextbox.value.trim(),
        contenu: addContenuTextbox.value.trim(),
        prix: Number(addPrixTextbox.value.trim()),
        Genre: GenreChoix
    };

    fetch(uriBook, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
        })
        .catch(error => console.error('Unable to add item.', error));

    console.log(JSON.stringify(item));
     alert('Votre livre a bien ete ajoute !');
     window.location.href = 'liste-livres.html';

}

// Supprimer un livre
function deleteItem(id) {

    var result = confirm("Etes-vous sur de vouloir supprimer ce livre ?");

    if (result) {
        fetch(`${uriBook}/${id}`, {
            method: 'DELETE'
        })
            .then(() => getItems())
            .catch(error => console.error('Unable to delete item.', error));
        alert('Le livre a bien ete supprime !');
    }
}

// details du livre
function displayDetail(id) {

    const item = todos.find(item => item.Id === id);

    // On passe les params en URL
    window.location.href = 'details-livre.html?id=' + item.Id + '&title=' + item.Title + '&contenu=' + item.Contenu + '&prix=' + item.Prix + '&genre=' + item.Genre[0].Nom;

}

// Modifier un livre
function displayEditForm(id) {

    /*todos.forEach(function (item, index, array) {
        console.log(item, index);
    });*/

    const item = todos.find(item => item.Id === id);

    // On passe les params en URL
    window.location.href = 'modifier-livre.html?id=' + item.Id + '&title=' + item.Title + '&contenu=' + item.Contenu + '&prix=' + item.Prix + '&genre=' + item.Genre[0].Nom;

}

// Modifier un livre -suite-
function updateItem() {

    const itemId = document.getElementById('edit-id').value;
    const addTitleTextbox = document.getElementById('edit-title').value;
    const addContenuTextbox = document.getElementById('edit-contenu').value;
    const addPrixTextbox = document.getElementById('edit-prix').value;
    const addGenreTextbox = document.getElementById('edit-Genre');

    const item = {
        id: parseInt(itemId, 10),
        title: addTitleTextbox.trim(),
        contenu: addContenuTextbox.trim(),
        prix: addPrixTextbox.trim(),
        Genre: [{ "Id": Number(addGenreTextbox.value.trim()), "Nom": addGenreTextbox.options[addGenreTextbox.selectedIndex].text.trim() }]
    };

    fetch(`${uriBook}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));
    console.log(JSON.stringify(item));

    alert('Votre livre a bien ete modifie !');
    window.location.href = 'liste-livres.html';

    return false;
}

// Pour le formulaire de la modification
 function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

// Pour compter le nombre des livres
function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'livres' : 'livres';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

// Pour l'affichage des livres dans le tableau
function _displayItems(data) {

    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {

        let editButton = button.cloneNode(false);
        editButton.setAttribute('onclick', `displayEditForm(${item.Id})`);
        editButton.classList.add('btn', 'btn-warning');
        editButton.innerHTML = '<i class="fa fa-edit"></i>';

        let deleteButton = button.cloneNode(false);
        deleteButton.setAttribute('onclick', `deleteItem(${item.Id})`);
        deleteButton.classList.add('btn', 'btn-danger');
        deleteButton.innerHTML = '<i class="fa fa-trash"></i>';

        let detailButton = button.cloneNode(false);
        detailButton.setAttribute('onclick', `displayDetail(${item.Id})`);
        detailButton.classList.add('btn', 'btn-primary');
        detailButton.innerHTML = '<i class="material-icons">&#xE417;</i>';

        let tr = tBody.insertRow();

        let td2 = tr.insertCell(0);
        let textNode = document.createTextNode(item.Id);
        td2.setAttribute("scope", "row");
        td2.appendChild(textNode);

        let td3 = tr.insertCell(1);
        let textNodeTitle = document.createTextNode(item.Title);
        td3.appendChild(textNodeTitle);

        let td4 = tr.insertCell(2);
        //let textNodeContenu = document.createTextNode(item.Contenu);
        var div = document.createElement("div");
        div.textContent = item.Contenu;
        div.classList.add("divforcontenu");
        td4.appendChild(div);

        let td5 = tr.insertCell(3);
        let textNodePrix = document.createTextNode(item.Prix);
        td5.appendChild(textNodePrix);

        let td6 = tr.insertCell(4);
        let textNodeGenre = document.createTextNode(item.Genre[0].Nom);
        td6.appendChild(textNodeGenre);

        let td9 = tr.insertCell(5);
        td9.appendChild(detailButton);

        let td7 = tr.insertCell(6);
        td7.appendChild(editButton);

        let td8 = tr.insertCell(7);
        td8.appendChild(deleteButton);

    });

    todos = data;
}