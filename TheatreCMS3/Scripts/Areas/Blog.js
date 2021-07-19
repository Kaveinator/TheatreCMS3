function getBlogBio(id) {
    var url = 
}
$(document).ready(function () {
    $('#blogBio@(Model.BlogAuthorId)').click(function () {
        var url = '@Url.Action("BlogBio", "BlogAuthors", new { id = Model.BlogAuthorId })';
        $.get(url, null, function (data) {
            $("#displayText@(Model.BlogAuthorId)").html(data);
        });
    })
    $('#blogPost@(Model.BlogAuthorId)').click(function () {
        $("#displayText@(Model.BlogAuthorId)").html("Implmented in future stories");
    });
});