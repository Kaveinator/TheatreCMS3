


function switchVisible() {
    if (document.getElementById('non-expired')) {

        if (document.getElementById('non-expired').style.display == 'none') {
            document.getElementById('non-expired').style.display = 'block';
            document.getElementById('expired').style.display = 'none';
            document.getElementById('Button1').value = "Expired Rentals";
        }
        else {
            document.getElementById('non-expired').style.display = 'none';
            document.getElementById('expired').style.display = 'block';
            document.getElementById('Button1').value = "Current Rentals";
        }
    }
}


$(document).ready(function DevCount () {  //naming function that counts contributing developers that have signed in
    
    var numPersons = $('#PersonList').find('p').length;   //variable created identifying every entry with a "p" tag within the list of sign ins

    $('#countDevs').text(numPersons);    //count and print the number of "p" tags found.
});






    
    
  

   