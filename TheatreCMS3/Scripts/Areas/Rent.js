

//-----Rental History-----//
var rentHistoryCheckBox = document.querySelector('.check-box');
var rentHistoryNotesLabel = document.querySelector('.rentalHistory-notes-label');



function isDamaged() {
    if (rentHistoryCheckBox.checked) {
        rentHistoryNotesLabel.innerHTML = "Damages Incurred";
        
    }
    else {
        rentHistoryNotesLabel.innerHTML = "Notes";
        
    }
}

if (document.getElementById("rightPage") !== null) {
    window.onload = isDamaged();
}


