console.log("hello world");


$(document).ready(function () {
    $("#myCheck input[type='checkbox']").click(function () {
        var label = $("label[for='DamagesIncurred']");

        if (this.checked) {
            label.text("Damages Incurred");
        } else {
            label.text("Notes");
        }
    });
});
