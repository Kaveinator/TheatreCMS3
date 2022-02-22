window.onload = function devCounter() {
    let list = document.getElementById("PersonList");
    let names = list.getElementsByTagName('p').length;
    document.getElementById("NumPersons").innerHTML = names;
}

