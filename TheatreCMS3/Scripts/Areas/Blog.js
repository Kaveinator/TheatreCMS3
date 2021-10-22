

// This function is for the Blog Author Details page. It provides the ability to switch between views.
function showPages(n, blogId) {
    
    if (blogId === undefined) { return; }
    
    var displaying = $("#" + blogId);
    var blogPostDisplay = $("#blogPost-" + blogId);
    var navDisplay1 = $("#pg1-" + blogId);
    var navDisplay2 = $("#pg2-" + blogId);
    if (n == 1) {
        navDisplay1.addClass("btn-success");
        displaying.show();
        blogPostDisplay.hide();
        navDisplay2.removeClass("btn-success");
        if (!navDisplay1.hasClass("btn-secondary")) { navDisplay1.addClass("btn-secondary"); }
    }

    if (n == 2) {
        navDisplay2.addClass("btn-success");
        displaying.hide();
        blogPostDisplay.show();
        navDisplay1.removeClass("btn-success");
        if (!navDisplay2.hasClass("btn-secondary")) { navDisplay2.addClass("btn-secondary"); }
    }
    
}