changeDamagedToNotes();
hasBeenChecked();



function changeDamagedToNotes() {
    var checkbox = document.getElementById("RentalDamaged")
    if (checkbox.checked == true) {
        console.log("Checkbox is checked.." + checkbox.checked);
        document.getElementById("damages-incurred").style.display = 'flex';
        document.getElementById("notes").style.display = 'none';
    }
    else {
        console.log("Checkbox is not checked..");
        document.getElementById("damages-incurred").style.display = 'none';
        document.getElementById("notes").style.display = 'flex';
    }
}

function hasBeenChecked() {
    var checkbox = document.getElementsByClassName('check-box')




    let textVar = document.getElementById('item-notes').checked;
    console.log(textVar);
    if (document.getElementsByClassName('check-box').checked) {
        textVar.style.color = 'grey';
    } else {
        textVar.style.color = 'black';
    }
}

