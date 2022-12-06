//jQuery | Get and display total number of developers

//Gets the total number of p elements within the 'home-signin-container' class
var count_elements = $('.home-signin--container p').length;

//Updates the text of the element with 'NumPersons' id
$("#NumPersons").text(count_elements);