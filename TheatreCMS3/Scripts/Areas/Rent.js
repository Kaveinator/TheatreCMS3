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

function labelNameChangeFunction() {
    var checkboxValue = $("#rentalDamageCheckbox").val();
    var label = "DamagesIncurred"
    if (checkboxValue) {
        $("#labelNameChangeId").hide();
        $("#labelNameChangeIdDisplay").html(label);
    }
}
