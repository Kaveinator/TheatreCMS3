$(document).ready(function () {
    $(".latest-posts").hide();

    $(".author-details-btn").click(function () {
        const authorId = $(this).data("author-id");
        $(`.latest-posts[data-author-id="${authorId}"]`).hide();
        $(`.author-details[data-author-id="${authorId}"]`).show();
    });

    $(".latest-posts-btn").click(function () {
        const authorId = $(this).data("author-id");
        $(`.author-details[data-author-id="${authorId}"]`).hide();
        $(`.latest-posts[data-author-id="${authorId}"]`).show();
    });
});

// funciton to hide/display navigation tabs on details/delete view
function toggleView(view) {
    if (view === 'authorDetails') {
        $('#authorDetailsTab').tab('show');
    } else if (view === 'blogPosts') {
        $('#blogPostsTab').tab('show');
    }
};

$(document).ready(function () {
    $('.deleteAuthor').click(function () {
        var authorRequestId = $(this).data('deleteindex');
        console.log(authorRequestId);

        if (confirm("Are you sure you want to delete the author?")) {
            $.ajax({
                url: '/Blog/BlogAuthors/DeleteConfirmed/' + authorRequestId,
                type: 'POST',  // Make sure your server supports DELETE method
                success: function (result) {
                    console.log(result);
                    var x = document.getElementById("authorContainer");
                    if (x.style.display === "none") {
                        x.style.display = "block";
                    } else {
                        x.style.display = "none";
                    }
                    // Optionally, update the UI or take further actions upon success
                },
                error: function (err) {
                    console.log("Error:", err);
                    // Optionally, handle the error or provide user feedback
                }
            });
        }
    });
});