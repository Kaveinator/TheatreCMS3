////On the SignIn page, use JavaScript and / or jQuery to count the
////number of names and display them next to the title.Use a Bootstrap
////badge to style the number.


//Creating a function.
function numOfDevs() {
    //Assigning the contents of PersonList to a variable: 'orange'.
    var orange = document.getElementById("PersonList");

    //Collecting .length(total) # of tags from 'orange' and giving it to: 'apple'.
    var apple = orange.getElementsByTagName('p').length;

    //Saying that NumPersons is equal to 'apple' (passing the data to it).
    document.getElementById("NumPersons").innerHTML = apple;
}
numOfDevs(); //Calling the function.