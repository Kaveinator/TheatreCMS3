
//---------Rentals------------//
function rentalChange(value) {
    var hideElements = document.getElementsByClassName("to-hide");

    for (i = 0; i < hideElements.length; i++) {
        var listOfClasses = hideElements[i].classList;
        if (!listOfClasses.contains("d-none")) {
            listOfClasses.add("d-none");
        }
    }
    var hiddenElements = document.getElementsByClassName(value);
    for (i = 0; i < hiddenElements.length; i++) {
        hiddenElements[i].classList.remove("d-none");
    }
    document.getElementById("rentalType").value = value
}

if (document.URL.includes("/Rent/Rentals/Edit/")
    || document.URL.includes("/Rent/Rentals/Create")) {
    const dataElement = document.querySelector(".form-horizontal");
    if (dataElement.dataset.type != "") {
        window.onload = rentalChange(dataElement.dataset.type);
    }
}

if (document.URL.includes("/Rent/Rentals/Details/") ||
    document.URL.includes("/Rent/Rentals/Delete/")){
    const dataElement = document.querySelector(".dl-horizontal");
    if (dataElement.dataset.type != "") {
        window.onload = rentalChange(dataElement.dataset.type);
    }
}

function greaterThanLessThan() {
    if (document.getElementById("GreaterThan_LessThan").innerHTML == "&lt;") {
        document.getElementById("GreaterThan_LessThan").innerHTML = "&gt;";
        document.getElementById("greater_less_input").value = ">"
    }
    else {
        document.getElementById("GreaterThan_LessThan").innerHTML = "&lt;";
        document.getElementById("greater_less_input").value = "<"
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


