$(document).ready(function () {
    var label = $('#damagesLabel');
    var checkbox = $('#RentalDamaged');

    label.text('Notes');
    label.css('display', 'inline-block');

    checkbox.click(function () {
        if (this.checked) {
            label.text('Damages' + ' Incurred');
        } else {
            label.text('Notes');
        }
    });
});
