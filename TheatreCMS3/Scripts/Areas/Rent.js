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

        $.ajax({
            url: "@Url.Action("SortedRental", "RentalHistoriesController")":, // Update with your controller and action names
            type: "GET",
            data: { sortOrder: selectedValue },
            success: function (data) {
                $("#RH-index-table").html(data);
            }
        });
    });
});

