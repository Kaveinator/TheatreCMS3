//counts number of developers on the signin sheet by totalling all <p> elements on page
function devCount()
{
    var devlist = document.getElementsByTagName("P").length;
    document.getElementById("NumPersons").innerHTML = devlist;
}