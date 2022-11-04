function showRental() {
    /*alert("showRental function hit");*/
    $(".rental-create--rentalequipmentformcomponent").hide();     //$ = select("element" or ".classname" or "#idname")  .hide() = built in function to hide selected($) element
    $(".rental-create--rentalroomformcomponent").hide();
}

function showRentalEquipment() {
    /*alert("showRentalEquipment function hit");*/   //test alerts to display when functions are hit
    $(".rental-create--rentalroomformcomponent").hide();
    
}

function showRentalRoom() {
    /*alert("showRentalRoom function hit");*/
    $(".rental-create--rentalequipmentformcomponent").hide();
}


//Functions to change h4 at top of Form to match selected dropdown item
function changeRentalHeading1() {
    /*alert("changeRentalHeading hit");*/
    var location = document.getElementById("rental-create--formheading");
    location.innerHTML = "Rental";
   /* document.getElementsByIdName("rental-create--formheading").innerHTML = rentalHeading;*  <--OLD WAY DOESNT WORK*/
}

function changeRentalHeading2() {
    var location = document.getElementById("rental-create--formheading");
    location.innerHTML = "Rental Equipment";
}

function changeRentalHeading3() {
    var location = document.getElementById("rental-create--formheading");
    location.innerHTML = "Rental Room";
}