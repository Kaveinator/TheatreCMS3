$(document).ready(function () {
    $("#myCheck input[type='checkbox']").click(function () {
        var label = $("label[for='DamagesIncurred']");

        if (this.checked) {
            label.text("Damages Incurred");
            /*$(".RH-index-damaged").html('<span class="bi bi-x-circle-fill red-color"></span>');*/
        } else {
            label.text("Notes");
            /*$(".RH-index-damaged").html('<span class="bi bi-check-circle-fill green-color"></span>');*/
        }
    });
});



$(document).ready(function () {
    $(".RH-index-sortdrop").change(function () {
        
        var selectedValue = $(this).val();
        if (selectedValue === 'damaged') {
            console.log("damaged sort")
            $.ajax({
                url: '/Rent/RentalHistories/SortDamaged',
                type: "GET",
                success: function (result) {
                    $("#RH-index-table").html(result);
                }
            });
        } else if (selectedValue === 'undamaged') {
            console.log("undamaged sort")
            $.ajax({
                url: '/Rent/RentalHistories/SortUndamaged',
                type: "GET",
                success: function (result) {
                    $("#RH-index-table").html(result);
                }
            });
        } else if (selectedValue === 'az') {
            console.log("az sort")
            $.ajax({
                url: '/Rent/RentalHistories/Sortaz',
                type: "GET",
                success: function (result) {
                    $("#RH-index-table").html(result);
                }
            });
        } else if (selectedValue === 'za') {
            console.log("za sort")
            $.ajax({
                url: '/Rent/RentalHistories/Sortza',
                type: "GET",
                success: function (result) {
                    $("#RH-index-table").html(result);
                }
            });
        }
    });
});

