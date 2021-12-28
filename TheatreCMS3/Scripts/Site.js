function NumDevs() {
    var num = document.getElementById("names").childElementCount;
    document.getElementById("NumPersons").innerHTML = num;
}
NumDevs();