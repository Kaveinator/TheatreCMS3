

$("#RentalOptions").change(function () {
    var value = $(this).val();
    if (value == "RentalEquipment") {
        $("#ChokingHazard").show();
        $("#ChokingHazardLabel").show();

        $("#SuffocationHazard").show();
        $("#SuffocationHazardLabel").show();

        $("#PurchasePrice").show();
        $("#PurchasePriceLabel").show();

        $("#RoomNumber").val(0);
        $("#RoomNumber").hide();
        $("#RoomNumberLabel").hide();

        $("#SquareFootage").val(0);
        $("#SquareFootage").hide();
        $("#SquareFootageLabel").hide();

        $("#MaxOccupancy").val(0);
        $("#MaxOccupancy").hide();
        $("#MaxOccupancyLabel").hide();
    }

    else if (value == "RentalRoom") {
        $("#RoomNumber").show();
        $("#RoomNumberLabel").show();

        $("#SquareFootage").show();
        $("#SquareFootageLabel").show();

        $("#MaxOccupancy").show();
        $("#MaxOccupancyLabel").show();

        $("#ChokingHazard").hide();
        $("#ChokingHazardLabel").hide();

        $("#SuffocationHazard").hide();
        $("#SuffocationHazardLabel").hide();

        $("#PurchasePrice").val(0);
        $("#PurchasePrice").hide();
        $("#PurchasePriceLabel").hide();
    }
    else
    {
        $("#ChokingHazard").hide();
        $("#ChokingHazardLabel").hide();

        $("#SuffocationHazard").hide();
        $("#SuffocationHazardLabel").hide();

        $("#PurchasePrice").hide();
        $("#PurchasePriceLabel").hide();

        $("#RoomNumber").hide();
        $("#RoomNumberLabel").hide();

        $("#SquareFootage").hide();
        $("#SquareFootageLabel").hide();

        $("#MaxOccupancy").hide();
        $("#MaxOccupancyLabel").hide();
    }
})