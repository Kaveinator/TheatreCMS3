//-----Rental History-----//
var rentHistoryCheckBox = document.querySelector('.check-box');
var rentHistoryNotesLabel = document.querySelector('.rentalHistory-notes-label');

window.onload = isDamaged();
function isDamaged() {
    if (rentHistoryCheckBox.checked) {
        rentHistoryNotesLabel.innerHTML = "Damages Incurred";
    }
    else {
        rentHistoryNotesLabel.innerHTML = "Notes";
    }
    console.log("isDamaged() event fired");
}

