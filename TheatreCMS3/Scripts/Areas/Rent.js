// toggles Rental History 'Damages Incurred'/'Notes' text
// based on the state of the checkbox
$('#RentalDamaged').change(function () {
    this.checked ?
        $('.damages-incurred').html('Damages Incurred') :
        $('.damages-incurred').html('Notes')
});

// handles link menu pop-up on Rental History Index page
function showLinksMenu(id) {
    menu = '#link-menu-' + id;
    $(menu).css('display', 'block');
};

// ajax method for reloading rental history table data
$('#rh-sort-options').change(function () {
    var url = $('#rh-sort-options').find(":selected").data('url');
    $('#rh-sort-table').load(url);
});

