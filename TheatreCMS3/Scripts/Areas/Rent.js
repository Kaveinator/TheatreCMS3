
//---------Rentals------------//

// Handles changing form to different types on create, edit, and details pages
function rentalChange(value) {
    //all potential elements to hide
    var hideElements = document.getElementsByClassName("to-hide"); 

    //reset all to 'hidden'
    for (i = 0; i < hideElements.length; i++) {
        var listOfClasses = hideElements[i].classList;
        if (!listOfClasses.contains("d-none")) {
            listOfClasses.add("d-none");
        }
    }

    //show only elements that are needed for the model
    var hiddenElements = document.getElementsByClassName(value);
    for (i = 0; i < hiddenElements.length; i++) {
        hiddenElements[i].classList.remove("d-none");
    }

    //changes value on last element (hidden)
    document.getElementById("rentalType").value = value
}

// call above function for edit and create pages onload, if needed.
if (document.URL.includes("/Rent/Rentals/Edit/")
    || document.URL.includes("/Rent/Rentals/Create")) {
    const dataElement = document.querySelector(".form-horizontal");
    if (dataElement.dataset.type != "") {
        window.onload = rentalChange(dataElement.dataset.type);
    }
}

// call above function for details and delete pages onload.
if (document.URL.includes("/Rent/Rentals/Details/") ||
    document.URL.includes("/Rent/Rentals/Delete/")){
    const dataElement = document.querySelector(".dl-horizontal");
    if (dataElement.dataset.type != "") {
        window.onload = rentalChange(dataElement.dataset.type);
    }
}

// Switch greater-than and less-than sign on index page.
function greaterThanLessThanClick() {
    if (document.getElementById("greater_less_input").value == "less") {
        document.getElementById("GreaterThan_LessThan").classList.remove('fa-chevron-left');
        document.getElementById("GreaterThan_LessThan").classList.add('fa-chevron-right');
        document.getElementById("greater_less_input").value = "greater"
    }
    else {
        document.getElementById("GreaterThan_LessThan").classList.remove('fa-chevron-right');
        document.getElementById("GreaterThan_LessThan").classList.add('fa-chevron-left');
        document.getElementById("greater_less_input").value = "less"
    }
}

//add greater than or less than sign to page. Default is less-than on view.
function gTLTLoad(value) {
    if (value == "less") {
        document.getElementById("GreaterThan_LessThan").classList.add('fa-chevron-left');
    }
    else if (value == "greater") {
        document.getElementById("GreaterThan_LessThan").classList.add('fa-chevron-right');
    }
}

//call above function onload
if (document.URL.includes("/Rent/Rentals")) {
    window.onload = gTLTLoad(document.getElementById("greater_less_input").value);
}

//-----Rental Name Search-----//

function searchCards() {
    var input = $("#rental_name_search").val().toLowerCase();
    $(".card").each(function () {
        var title = $(this).find(".card-title").text();
        if (title.toLowerCase().includes(input)) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    });
}


$("#name_search_clear").click(function () {
    $("#rental_name_search").val("");
    searchCards();
});


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


