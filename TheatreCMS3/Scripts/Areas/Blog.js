$(document).ready(function () {
    $(".latest-posts").hide();

    $("#authorDetailsBtn").click(function () {
        $(".author-details").show();
        $(".latest-posts").hide();
    });

    $("#latestPostsBtn").click(function () {
        $(".latest-posts").show();
        $(".author-details").hide();
    });
});