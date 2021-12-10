$(function () {

    // get the variable for the label and checkbox
    $('#RentalDamaged').change(function () {
        if ($(this).is(":checked")) {
            $("#RentalLabel").html("Damages Incurred");
        }
        else {
            $("#RentalLabel").html("Notes");
        }
    });

    function dropdownList() {
        // Toggel the drowpdown menu
        $('.dropdown').hover(function () {
            $(this).children(".dropdown-menu").css({
                "display": "block",
            });
        }, function () {
            $(this).children(".dropdown-menu").css({
                "display": "none"
            });
        });
    }
    dropdownList();
    // when selected
    $("#sortSelect").on('change', function () {
        event.preventDefault();
        // value of the selection
        var val = this.value;
        $.ajax({
            type: "POST",
            url: 'RentalHistories/ShowRentalHistoryList',
            data: { sortOrder: val },
            success: function (data) {
                console.log("success");
                $("#rentHistoryListArea").html(data);
                dropdownList();
            }
        });
    });
});
