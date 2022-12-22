$("#RentalOptions").change(function () {
    var value = $(this).val();
    if (value == "RentalEquipment") {
        $("#rentals-createEdit--RentalEquipmentForm").show();

        $("#rentals-createEdit--RentalRoomForm").val(0);
        $("#rentals-createEdit--RentalRoomForm").hide();
    }
    else if (value == "RentalRoom") {
        $("#rentals-createEdit--RentalRoomForm").show();

        $("#rentals-createEdit--RentalEquipmentForm").val(0);
        $("#rentals-createEdit--RentalEquipmentForm").hide();
    }
    else
    {
        $("#rentals-createEdit--RentalRoomForm").val(0);
        $("#rentals-createEdit--RentalRoomForm").hide();

        $("#rentals-createEdit--RentalEquipmentForm").val(0);
        $("#rentals-createEdit--RentalEquipmentForm").hide();
    }
})