//counts number of developers on the signin sheet by totalling all children in name div with <p> element
function devCount() {
    var devlist = document.getElementById("nameList");
    justDevs = devlist.getElementsByTagName("P").length;
    document.getElementById("NumPersons").innerHTML = "Developers listed: " + justDevs;
}