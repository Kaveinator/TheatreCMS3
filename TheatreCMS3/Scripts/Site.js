$(document).ready(function () {
    //grab all paragraph elements in the dev-names div
    var n = $(".dev-names p");
    //write in badge
    $("span").text(n.length);
    

   
});

//used for debugging
//$(window).on("load", function () {
//    console.log("window loaded");
//});