$(function () {

    // get the variable for the label and checkbox
    $('#RentalDamaged').change(function () {
        if ($(this).is(":checked")) {
            $("#RentalLabel").html("Damages Incurred");
        }
        else {
            decs.innerHTML = "Notes";
        }
    });

    // Toggel the drowpdown menu
    $('.dropdown').hover(function () {
        $(this).children(".dropdown-menu").css({
            "display": "block"
        });
    }, function () {
        $(this).children(".dropdown-menu").css({
            "display": "none"
        });
    });

    // Display the rental history list 
    function loadRentalHistoryList(val) {
        $.ajax({
            type: "POST",
            url: 'ShowRentalHistoryList',
            data: { sortOrder: val },
            success: function (data) {
                console.log("success");
                $("#rentHistoryListArea").html(data);
            }
        });
    }
    // On Page Load
    loadRentalHistoryList("damaged");
    // when selected
    $("#sortSelect").on('change', function () {
        event.preventDefault();
        // value of the selection
        var val = this.value;
        loadRentalHistoryList(val)
    });
});
