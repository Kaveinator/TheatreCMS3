$(document).ready(function () {
    $("#myCheck input[type='checkbox']").click(function () {
        var label = $("label[for='DamagesIncurred']");
        var checkbox = $(this);

        if (checkbox.prop("checked")) {
            label.text("Damages Incurred");
           /* $(".RH-index-damaged").html('<span class="bi bi-x-circle-fill red-color"></span>');*/
        } else {
            label.text("Notes");
            /*$(".RH-index-damaged").html('<span class="bi bi-check-circle-fill green-color"></span>');*/
        }
    });
});

