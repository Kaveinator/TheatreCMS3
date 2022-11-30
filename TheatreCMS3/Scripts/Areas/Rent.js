$('#RentalOptions').change(function(){
    var value = $(this).val();
    if (value == "RentalEquipment") {
        $('.Rental-Create--RentalEquipmentView').show();
        $('.Rental-Create--RentalRoomView').hide();
    }
    else if (value == "RentalRoom") {
        $('.Rental-Create--RentalRoomView').show();
        $('.Rental-Create--RentalEquipmentView').hide();
        $('.Rental-Create--RentalView').hide();
    }
    else {
        $('.Rental-Create--RentalEquipmentView').hide();
        $('.Rental-Create--RentalRoomView').hide();
    }
})
    
