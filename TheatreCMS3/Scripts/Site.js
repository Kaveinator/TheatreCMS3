const personList = document.getElementById("PersonList");   //gets the person list
const numPersons = personList.getElementsByTagName("p").length; //gets all of 'p' elements within'personList' and gets the length of the reutned HTML collection. 

const numPersonsElem = document.getElementById("NumPersons");  //finds element with id 'NumPersons' and updates the innerHTML with the count of people 
numPersonsElem.innerHTML = numPersons;


