


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



function toggleCheck() {

    let damages = document.getElementById("damage-label");
    let notes = document.getElementById("notes-label");
    if (damages.hidden === true) {
        damages.hidden = false;
        notes.hidden = true;
    } else {
        damages.hidden = true;
        notes.hidden = false;
    }
}



if (document.getElementById("check").checked === true) {
    document.getElementById("damage-label").hidden = false;
    document.getElementById("notes-label").hidden = true;
} else {
    document.getElementById("damage-label").hidden = true;
    document.getElementById("notes-label").hidden = false;
}




    
    
  

   