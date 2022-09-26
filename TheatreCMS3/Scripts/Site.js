// updates dev-count badge on sign-in page
$().ready(function () {
    const dev_count = $('#PersonList p').length;
    $('#NumPersons').html(dev_count);
});