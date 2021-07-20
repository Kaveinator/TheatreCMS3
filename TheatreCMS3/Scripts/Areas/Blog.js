function getBlogBio(id) {
    alert("Halp");
    $(document).ready(function () {
        var url = '/Blog/BlogAuthors/BlogBio/' + id;
        $.get(url, null, function (data) {
            $("#displayText" + id).html(data);
        });
    })
}

function getBlogPost(id) {
    $(document).ready(function () {
        $("#displayText" + id).html("Implmented in future stories");
    })
}
function getBlogBio(id) {
    $(document).ready(function () {
        var url = '/Blog/BlogAuthors/BlogBio/' + id;
        $.get(url, null, function (data) {
            $("#displayText" + id).html(data);
        });
    })
}

function getBlogPost(id) {
    $(document).ready(function () {
        $("#displayText" + id).html("Implmented in future stories");
    })
}