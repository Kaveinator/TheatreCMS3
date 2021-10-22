var pageIndex = 1;
showPages(pageIndex);

function currentPage(n) {
    showPages(pageIndex = n);
}
// This function is for the Blog Author Details page. It provides the ability to switch between views.
function showPages(n, blogId) {
    
    if (blogId=== undefined) { blogId= 0; }
    var displaying = $("#" + blogId);
    var blogPostDisplay = $("#blogPost(" + blogId+ ")");
    var navDisplay1 = $("#pg1(" + n + ")");
    var navDisplay2 = $("#pg2(" + n + ")");
    if (n = 1) {
        displaying.style.display = "block";
        blogPostDisplay.style.display = "none";
        navDisplay1.removeClass("btn-success");
        if (!navDisplay1.hasClass("btn-secondary")) { navDisplay1.addClass("btn-secondary") };
    }

    if (n = 2) {
        displaying.style.display = "block";
        blogPostDisplay.style.display = "none";
        navDisplay2.removeClass("btn-success");
        if (!navDisplay2.hasClass("btn-secondary")) { navDisplay2.addClass("btn-secondary") };
    }
    
}