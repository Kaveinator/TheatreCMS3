$(document).ready(function () {
    //grab all paragraph elements in the dev-names div
    var n = $(".dev-names p");
    //write in badge
    if (n.length > 0) {

        $("#NumPersons").text(n.length);
    }
    

   
});

//used for debugging
//$(window).on("load", function () {
//    console.log("window loaded");
//});



// Rental History Create
var Counter = 0;
function checkLink() {
    Counter += 1;
    if (Counter % 2 == 0) {
        document.getElementById("control-label col-md-2").innerHTML = "Notes"
    }
    else {
        document.getElementById("control-label col-md-2").innerHTML = "Damages"
    }
}