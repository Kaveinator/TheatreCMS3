function showRental() {
    alert("showRental function hit");
    $(".rental-create--rentalequipmentformcomponent").hide();     //$ = select("element" or ".classname" or "#idname")  .hide() = built in function to hide selected($) element
    $(".rental-create--rentalroomformcomponent").hide();
}

function showRentalEquipment() {
    alert("showRentalEquipment function hit");
    $(".rental-create--rentalroomformcomponent").hide();
    
}

function showRentalRoom() {
    alert("showRentalRoom function hit");
    $(".rental-create--rentalequipmentformcomponent").hide();
}

function changeRentalHeading() {
    alert("changeRentalHeading hit");
    var rentalHeading = "Rental";
    var location = document.getElementsById("rental-create--formheading");
    location.innerHTML = "string";
    /*document.getElementsByClassName("rental-create--formheading").innerHTML = rentalHeading;*/
}