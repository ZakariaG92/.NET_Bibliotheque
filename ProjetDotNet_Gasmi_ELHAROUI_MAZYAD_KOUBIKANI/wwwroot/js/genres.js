const uriGetGenres = 'api/Genres/all';
const uriGenres1 = 'api/Genres';
let todosGenres = [];

// Recuperer tous les genres
function getGenres() {
    fetch(uriGetGenres)
        .then(response => response.json())
        .then(data => _displayGenres(data))
        .catch(error => console.error('Unable to get items.', error));
}

// Ajouter un genre
function addGenre() {

    const addIdGenre = document.getElementById('IdGenre');
    const addNomGenre = document.getElementById('nomGenre');

    const item = {
        id: Number(addIdGenre.value.trim()),
        nom: addNomGenre.value.trim(),
    };

    fetch(uriGenres1, {
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
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
    console.log(JSON.stringify(item));
    alert('Votre genre a bien ete ajoute !');
    window.location.href = 'liste-genres.html';

}

// Supprimer un genre
function deleteItem(id) {
    fetch(`${uriGenres1}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getGenres())
        .catch(error => console.error('Unable to delete item.', error));
    alert('Le genre a bien ete supprime !');
    window.location.href = 'liste-genres.html';
}


// Modifier un genre
function displayEditForm(id) {

    const item = todosGenres.find(item => item.Id === id);

    // On passe les params en URL
    window.location.href = 'modifier-genre.html?id=' + item.Id + '&nom=' + item.Nom;

}

// Modifier un genre -suite-
function updateGenre() {

    const genreId = document.getElementById('edit-idGenre').value;
    const addNomGenre = document.getElementById('edit-nom').value;

    const item = {
        id: parseInt(genreId, 10),
        nom: addNomGenre.trim(),
    };

    fetch(`${uriGenres1}/${genreId}`, {
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

    alert('Le genre a bien ete modifie !');
    window.location.href = 'liste-genres.html';

    return false;

}

// Afficher les genres dans le tableau
function _displayGenres(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {

        let editButton = button.cloneNode(false);
        editButton.setAttribute('onclick', `displayEditForm(${item.Id})`);
        editButton.classList.add('btn', 'btn-success');
        editButton.innerHTML = '<i class="fa fa-edit"></i>';

        let deleteButton = button.cloneNode(false);
        deleteButton.setAttribute('onclick', `deleteItem(${item.Id})`);
        deleteButton.classList.add('btn', 'btn-danger');
        deleteButton.innerHTML = '<i class="fa fa-trash"></i>';

        let tr = tBody.insertRow();

        let td2 = tr.insertCell(0);
        let textNode = document.createTextNode(item.Id);
        td2.setAttribute("scope", "row");
        td2.appendChild(textNode);

        let td3 = tr.insertCell(1);
        let textNodeTitle = document.createTextNode(item.Nom);
        td3.appendChild(textNodeTitle);

        let td7 = tr.insertCell(2);
        td7.appendChild(editButton);

        let td8 = tr.insertCell(3);
        td8.appendChild(deleteButton);

    });

    todosGenres = data;
}