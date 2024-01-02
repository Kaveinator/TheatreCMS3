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

