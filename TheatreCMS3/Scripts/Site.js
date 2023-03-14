function totalUsers() {
    var nameList = document.getElementById("PersonList");
    var numberOfNames = nameList.children.length;
    document.getElementById("NumPersons").innerHTML = numberOfNames;
}
window.onload = totalUsers();