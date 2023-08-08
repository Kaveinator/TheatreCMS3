var checkbox = $('.checkbox input[type="checkbox"]');
var isChecked = checkbox.prop("checked");
var label = $('.renthistory-damage');
    if (isChecked) {
        label.text('Damages Incurred');
    } else {
        label.text('Notes');
    }

$(document).ready(function () {
    var checkbox = $('.checkbox input[type="checkbox"]');
    var label = $('.renthistory-damage');

    checkbox.on('change', function () {
        var checked = this.checked;
        if (checked) {
            label.text('Damages Incurred');
        } else {
            label.text('Notes');
        }
    });
});


$(".dropdown-button").hover(function () {
    $(this).find(".dropdown-menu").slideToggle();
});