var pageIndex = 1;
showPages(pageIndex);

function currentPage(n) {
    showPages(pageIndex = n);
}
// This function is for the Blog Author Details page. It provides the ability to switch between views.
function showPages(n) {
    var i;
    var pages = document.getElementsByClassName("pages");
    var displays = document.getElementsByClassName("displays");
    if (n > pages.length) { pageIndex = 1 };
    if (n < 1) { pageIndex = pages.length };
    for (i = 0; i < displays.length; i++) {
        displays[i].style.display = "none";
    }
    for (i = 0; i < pages.length; i++) {
        pages[i].classList.remove("btn-success");
        if (!pages[i].classList.contains("btn-secondary")) { pages[i].classList.add("btn-secondary") };
    }
    displays[pageIndex - 1].style.display = "block";
    pages[pageIndex - 1].classList.remove("btn-secondary");
    pages[pageIndex - 1].classList.add("btn-success");

}