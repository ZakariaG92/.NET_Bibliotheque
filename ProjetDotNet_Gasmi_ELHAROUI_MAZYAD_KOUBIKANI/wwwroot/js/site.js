const uri = 'api/Books/all';
const uriAllGenres = 'api/Genres/all';
const uriPost = 'api/Books';
const uriDelete = 'api/Books';
let todos = [];
let tabGenres = [];

// Recuperer tous les livres
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

// Recuperer tous les genres
function getGenres() {
    fetch(uriAllGenres)
        .then(response => response.json())
        // On va remplir la list <select> pour le POST/PUT des livres 
        // Text = Nom du genre  //  Value = Id du genre (ça va etre utile)
        .then(data => {
            data.forEach(item => {
                //tabGenres.push(item.Nom);
                var select = document.getElementById("selectGenre");
                var select1 = document.getElementById("edit-Genre");

                    var opt = item.Nom;
                    var el = document.createElement("option");
                    el.textContent = opt;
                    el.value = item.Id;
                    select.appendChild(el);

                    var opt1 = item.Nom;
                    var el1 = document.createElement("option");
                    el1.textContent = opt1;
                    el1.value = item.Id;
                    select1.appendChild(el1);
            })
            /*tabGenres.forEach(function (item, index, array) {
            console.log(item, index);
            });*/
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
    //const addNameTextbox = document.getElementById('add-name');
    const addIdTextbox = document.getElementById('Id');
    const addTitleTextbox = document.getElementById('Title');
    const addContenuTextbox = document.getElementById('Contenu');
    const addPrixTextbox = document.getElementById('Prix');
    const addGenreTextbox = document.getElementById('selectGenre');


    const item = {
        //name: addNameTextbox.value.trim()
        id: Number(addIdTextbox.value.trim()),
        title: addTitleTextbox.value.trim(),
        contenu: addContenuTextbox.value.trim(),
        prix: Number(addPrixTextbox.value.trim()),
        Genre: [{ "Id": Number(addGenreTextbox.value.trim()), "Nom": addGenreTextbox.options[addGenreTextbox.selectedIndex].text.trim() }]
    };
    //item.tabGenres = []

    fetch(uriPost, {
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
}


// Supprimer un livre
function deleteItem(id) {
    fetch(`${uriDelete}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {

    todos.forEach(function (item, index, array) {
        console.log(item, index);
    });

    const item = todos.find(item => item.Id === id);
  
    document.getElementById('edit-id').value = item.Id;
    document.getElementById('edit-title').value = item.Title;
    document.getElementById('edit-contenu').value = item.Contenu;
    document.getElementById('edit-prix').value = item.Prix;
    document.getElementById('edit-Genre').text = item.Genre[0].Nom;
    /*const genreTextbox = document.getElementById('edit-Genre').value;
    genreTextbox.options[genreTextbox.selectedIndex].text = item.Genre[0].Nom;*/
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    //const itemId = document.getElementById('edit-id').value;
    const itemId = document.getElementById('edit-id').value;
    const addTitleTextbox = document.getElementById('edit-title').value;
    const addContenuTextbox = document.getElementById('edit-contenu').value;
    const addPrixTextbox = document.getElementById('edit-prix').value;
    const addGenreTextbox = document.getElementById('edit-Genre').value;

    const item = {
        id: parseInt(itemId, 10),
        /*isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()*/
        //id: itemId.value.trim(),
        title: addTitleTextbox.trim(),
        contenu: addContenuTextbox.trim(),
        prix: addPrixTextbox.trim(),
        Genre: [{ "Id": Number(addGenreTextbox.value.trim()), "Nom": addGenreTextbox.options[addGenreTextbox.selectedIndex].text.trim() }]
    };

    fetch(`${uriDelete}/${itemId}`, {
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

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.Id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.Id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.Id);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        let textNodeTitle = document.createTextNode(item.Title);
        td3.appendChild(textNodeTitle);

        let td4 = tr.insertCell(3);
        let textNodeContenu = document.createTextNode(item.Contenu);
        td4.appendChild(textNodeContenu);

        let td5 = tr.insertCell(4);
        let textNodePrix = document.createTextNode(item.Prix);
        td5.appendChild(textNodePrix);

        let td6 = tr.insertCell(5);
        let textNodeGenre = document.createTextNode(item.Genre[0].Nom);
        td6.appendChild(textNodeGenre);

        let td7 = tr.insertCell(6);
        td7.appendChild(editButton);

        let td8 = tr.insertCell(7);
        td8.appendChild(deleteButton);

    });

    todos = data;
}