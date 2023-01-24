/*using javascript
var count = document.getElementById("PersonList");
var count1 = document.getElementsByTagName("p");
document.getElementById("NumPersons").innerHTML = count1.length;
*/

/* using jquery */
var count = $("#PersonList p");
document.getElementById("NumPersons").innerHTML = count.length;