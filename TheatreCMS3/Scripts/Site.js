//finds the number of <p> elements in the "PersonList" <div> and updates the count element
function getNumOfDevs() {
    document.getElementById("Count").innerHTML = ((document.getElementById('PersonList')).getElementsByTagName('p')).length;
}