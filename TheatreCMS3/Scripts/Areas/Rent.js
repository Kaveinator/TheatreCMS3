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

//function iconChangeFunction() {
//    for (let i = 0, len = .length, i < len; i++)
//        text = sg[i]
//    var checkboxValue = document.getElementById('RentalHistory-index--checkbox').checked;
//    console.log(checkboxValue);
//}



//$(document).ready(function () {

//    $(".RentalHistory-index--checkbox").change(function () {
//        if (this.checked) {
//            $("#link").css("display", "block");
//        }
//        else {
//            $("#link").css("display", "none");
//        }
//    });
//}