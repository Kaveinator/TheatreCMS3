//Can't figure out why this jQuery does not work. Have tried multiple iterations with classes, ids, and elements

//$("#NumPersons").load(function () {
//    $("p.home-signin--container").length
//});


document.getElementById("NumPersons").innerHTML = document.querySelectorAll('p').length;