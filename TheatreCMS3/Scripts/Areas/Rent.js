console.log("HelloWorld");

$(function () {
    $("#RentalType").change(function () {
        var selectedType = $(this).val();
        $(".rentalEquipmentContainer, .rentalRoomContainer").hide();
        if (selectedType === "RentalEquipment") {
            $(".rentalEquipmentContainer").show();
        } else if (selectedType === "RentalRoom") {
            $(".rentalRoomContainer").show();
        }
    });
});


//Function for RentalHistory model, Create and Edit pages:
window.onload = function () {
    labelNameChangeFunction();
};
function labelNameChangeFunction() {
    var DamagesIncurredlabelvalue = document.getElementById('RentalHistory-create--damagesIncurredLabel');
    var Noteslabelvalue = document.getElementById('RentalHistory-create--notesLabel');
    var checkboxValue = document.getElementById('rentalDamageCheckbox').checked;

    if (checkboxValue) {
        DamagesIncurredlabelvalue.style.display = "block";
        Noteslabelvalue.style.display = "none";
    }

    else
    {
        Noteslabelvalue.style.display = "block";
        DamagesIncurredlabelvalue.style.display = "none";
    }
}

function dropDownMenuAppears() {
    var DropDownMenuValue = document.getElementsByClassName("RentalHistory-index--dropdownMenuButton");
    for (var i = 0; i < DropDownMenuValue.length; i += 1) {
        DropDownMenuValue[i].style.display = "block";
    }
}

function dropDownMenuDisappears() {
    var DropDownMenuValue = document.getElementsByClassName("RentalHistory-index--dropdownMenuButton");
    for (var i = 0; i < DropDownMenuValue.length; i += 1) {
        DropDownMenuValue[i].style.display = "none";
    }
}