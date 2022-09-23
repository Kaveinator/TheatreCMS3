// updates dev-count badge on sign-in page
$().ready(function () {
    const dev_count = $('#PersonList p').length;
    $('#NumPersons').html(dev_count);
});

// toggles Rental History 'Damages Incurred'/'Notes' text
// based on the state of the checkbox
$('#RentalDamaged').change(function () {
    this.checked ?
        $('.damages-incurred').html('Damages Incurred') :
        $('.damages-incurred').html('Notes')
});