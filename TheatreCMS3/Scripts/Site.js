


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

function changeDamagedToNotes() {
    var checkbox = document.getElementById("RentalDamaged")
    if (checkbox.checked == true) {
        console.log("Checkbox is checked.." + checkbox.checked);
        document.getElementById("damages-incurred").style.display = 'flex';
        document.getElementById("notes").style.display = 'none';
    } else {
        console.log("Checkbox is not checked..");
        document.getElementById("damages-incurred").style.display = 'none';
        document.getElementById("notes").style.display = 'flex';
    }
}





    
    
  

   