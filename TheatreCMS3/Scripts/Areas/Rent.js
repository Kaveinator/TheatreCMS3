console.log("Hello World!");
$(document).ready(function () {
    var checkbox = $('.checkbox');
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
