//returns number of people Signed in
//function signInList() {
//    var divList = document.getElementById("PersonList");
//    var names = divList.getElementsByTagName("p").length;
//    document.getElementById("NumPersons").innerHTML = names; 
//}

//Jquery version returning number of people signed in
function signInList() {
    var divList = $("#PersonList p");
    $("#NumPersons").html(divList.length);
}
signInList();