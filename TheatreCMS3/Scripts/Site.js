//counts the number of developer names and displays them next to the title using a bootstrap badge | targeted classes from signin.cshtml
$(document).ready(function () {  //runs when page dom is ready for JS
    var numberOfDevelopers = $('#PersonList p').length;
    $('#NumPersons').text(numberOfDevelopers);
});