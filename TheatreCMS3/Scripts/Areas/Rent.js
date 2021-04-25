
//---------Rentals------------//
function rentalChange(value) {
    var hideElements = document.getElementsByClassName("to-hide");

    for (i = 0; i < hideElements.length; i++) {
        var listOfClasses = hideElements[i].classList;
        if (listOfClasses.contains("d-none")) {
            continue;
        }
        else {
            listOfClasses.add("d-none");
        }
    }
    var hiddenElements = document.getElementsByClassName(value);
    for (i = 0; i < hiddenElements.length; i++) {
        hiddenElements[i].classList.remove("d-none");
    }
    document.getElementById("rentalType").value = value
}

if (document.URL.includes("/Rent/Rentals/Edit/") || document.URL.includes("/Rent/Rentals/Create") ) {
    const dataElement = document.querySelector(".form-horizontal");
    if (dataElement.dataset.type != null) {
        window.onload = rentalChange(dataElement.dataset.type);
    }
    
}


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


