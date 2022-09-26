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

$('#rh-sort-options').change(function () {
    $.ajax({
        type: "GET",
        url: "/RentalHistorySortAjax",
        data: { sortOption: this.value }
    });
});