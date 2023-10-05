changeDamagedToNotes();
damageSymbol();

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

function damageSymbol() {
    var checkbox = document.getElementsByClassName("check-box")
    if (checkbox.checked == true) {
        console.log("test1");
        document.getElementById("checkmark").style.display = 'flex';
        document.getElementById("xmark").style.display = 'none';
    } else {
        console.log("test2");
        document.getElementById("checkmark").style.display = 'none';
        document.getElementById("xmark").style.display = 'flex';
    }
}