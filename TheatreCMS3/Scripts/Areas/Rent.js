$('#RentalOptions').change(function(){
    var value = $(this).val();
    if (value == "RentalEquipment") {
        $('.Rental-Create--RentalEquipmentView').show();
        $('.Rental-Create--RentalRoomView').hide();
        $('.Rental-Create--RentalView').show();
    }

    else if (value == "RentalRoom") {
        $('.Rental-Create--RentalRoomView').show();
        $('.Rental-Create--RentalEquipmentView').hide();
        $('.Rental-Create--RentalView').show();
    }

    else {
        $('.Rental-Create--RentalEquipmentView').hide();
        $('.Rental-Create--RentalRoomView').hide();
        $('.Rental-Create--RentalView').show();
    }
})

//function Edit () {
//    var RType = document.getElementsByClass('Edit').val();
//    if (RType == "RentalEquipment") {
//        $('.Rental-Create--RentalEquipmentView').show();
//        $('.Rental-Create--RentalRoomView').hide();
//        $('.Rental-Create--RentalView').show();
//    }

//    else if (Rtype == "RentalRoom") {
//        $('.Rental-Create--RentalRoomView').show();
//        $('.Rental-Create--RentalEquipmentView').hide();
//        $('.Rental-Create--RentalView').show();
//    }

//    else {
//        $('.Rental-Create--RentalEquipmentView').hide();
//        $('.Rental-Create--RentalRoomView').hide();
//        $('.Rental-Create--RentalView').show();
//    }
//}
