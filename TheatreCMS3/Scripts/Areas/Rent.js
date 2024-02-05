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

function resetToggleCards() {
    $('.RentalHistory-index--tr').hover(
        function () {
            $(this).find('.RentalHistory-index--dropdownMenuButton').show();
        },
        function () {
            $(this).find('.RentalHistory-index--dropdownMenuButton').hide();
        }
    );
};

$(document).ready(function () {
    $('.RentalHistory-index--tr').hover(
        function () {
            $(this).find('.RentalHistory-index--dropdownMenuButton').show();
        },
        function () {
            $(this).find('.RentalHistory-index--dropdownMenuButton').hide();
        }
    );
});


$(document).ready(function () {
    $('#sortingSelect').change(function () {
        var selectedOption = $(this).val();
        if (selectedOption === 'damagedrentals') {
            $.ajax({
                url: '/Rent/RentalHistories/SortByDamaged',
                type: 'GET',
                success: function (result) {
                    console.log("success")
                    $('#RentalHistory-index--tableId').html(result);
                    $('.RentalHistory-index--table').find('.RentalHistory-index--dropdownMenuButton').hide();
                    resetToggleCards();
                }
            });
        } else if (selectedOption === 'undamagedrentals') {
            $.ajax({
                url: '/Rent/RentalHistories/SortByUndamaged',
                type: 'GET',
                success: function (result) {
                    console.log("success")
                    $('#RentalHistory-index--tableId').html(result);
                    $('.RentalHistory-index--tr').find('.RentalHistory-index--dropdownMenuButton').hide();
                    resetToggleCards();
                }
            });
        } else if (selectedOption === 'rentalsAtoZ') {
            $.ajax({
                url: '/Rent/RentalHistories/SortByAZ',
                type: 'GET',
                success: function (result) {
                    console.log("success")
                    $('#RentalHistory-index--tableId').html(result);
                    $('.RentalHistory-index--tr').find('.RentalHistory-index--dropdownMenuButton').hide();
                    resetToggleCards();
                }
            });
        } else if (selectedOption === 'rentalsZtoA') {
            $.ajax({
                url: '/Rent/RentalHistories/SortByZA',
                type: 'GET',
                success: function (result) {
                    console.log("success")
                    $('#RentalHistory-index--tableId').html(result);
                    $('.RentalHistory-index--tr').find('.RentalHistory-index--dropdownMenuButton').hide();
                    resetToggleCards();
                }
            });
        }
    });
});