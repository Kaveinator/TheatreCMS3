function showDetails(id) {
    $("#showDetails-" + id).show();
    $("#blogPosts-" + id).hide();
}
function showPosts(id) {
    $("#blogPosts-" + id).show();
    $("#showDetails-" + id).hide();
}
