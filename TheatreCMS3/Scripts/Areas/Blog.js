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

//function toggle(id) {
//    var e = document.getElementById(id);
//    if (e.style.display == 'block')
//        e.style.display = 'none';
//    else
//        e.style.display = 'block';
//}

//$(document).ready(function () {
//    $(".nav-tabs a").click(function () {
//        $(this).tab('show');
//    });
//});

function activaTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};

activaTab('authorDetailsTab');