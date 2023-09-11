$(document).ready(function () {
    function toggleLabel() {
        var isChecked = $('#RentalDamaged').is(':checked');
        var label = isChecked ? 'Damages Incurred' : 'Notes';
        $('#damageLabel').text(label);
    }
    toggleLabel();
    $('#RentalDamaged').change(function () {
        toggleLabel();
    });
});