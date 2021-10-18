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