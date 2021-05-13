
/*---Rental History Checkbox/Label ---*/



$("#chkDamagesIncurred").change(function () {
    if (this.checked) {
        $('#id1').show().html("Damages Incurred");
    } else {
        $('#id1').show().html("Notes");
    }
});

