function showAuthorDetails() {
    $("#latestPosts").hide();
    $("#authorDetails").show();
    $("#btnLatestPosts").removeClass("active");
    $("#btnAuthorDetails").addClass("active");
}

function showLatestPosts() {
    $("#authorDetails").hide();
    $("#latestPosts").show();
    $("#btnAuthorDetails").removeClass("active");
    $("#btnLatestPosts").addClass("active");
}