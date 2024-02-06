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


//Functions for RentalHistory model, Create and Edit pages:
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

//Functions for RentalHistory Index page Sorting feature:
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
    $('#sortingSelect').change(function () {
        var selectedOption = $(this).val();

        switch (selectedOption) {
            case 'damagedrentals':
                sendAjaxRequest('/Rent/RentalHistories/SortByDamaged');
                break;
            case 'undamagedrentals':
                sendAjaxRequest('/Rent/RentalHistories/SortByUndamaged');
                break;
            case 'rentalsAtoZ':
                sendAjaxRequest('/Rent/RentalHistories/SortByAZ');
                break;
            case 'rentalsZtoA':
                sendAjaxRequest('/Rent/RentalHistories/SortByZA');
                break;
            case 'nosorting':
                sendAjaxRequest('/Rent/RentalHistories/NoSorting');
                break;
        }
    });

    function sendAjaxRequest(url) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (result) {
                $('#RentalHistory-index--tableId').html(result);
                $('.RentalHistory-index--tr').find('.RentalHistory-index--dropdownMenuButton').hide();
                resetToggleCards();
            }
        });
    }
});

//table = document.getElementById("RentalHistory-index--tableId");
//rows = table.rows;
//console.log(rows.length);
//var id = document.getElementById('RentalHistory-index--itemId');

//$(document).ready(function () {
//    $('.RentalHistory-index--damageNotesButton').click(
//        function () {
//            //$(this).find('td:nth-child(5)').show();

//            //alert('The info of the cell you clicked on is: ' + ($(this).find('td:nth-child(5)').text()));
//            $('.collapseclass').collapse('toggle');

//        }
//    );
//});

$(document).ready(function () {
    $('.text-left').click(
        function () {
            $('.collapse').collapse('toggle');
        }
    );
});

//$('.card').find('h2').click(function () {
//    alert('You clicked row ' + ($(this).index() + 1));
//});

