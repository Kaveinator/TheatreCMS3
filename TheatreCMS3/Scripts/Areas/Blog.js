const tabs = document.querySelector(".BlogAuthor-DetailsDelete--TabContainerWrapper");
const tabButton = document.querySelectorAll(".BlogAuthor-DetailsDelete--TabButton");
const contents = document.querySelectorAll(".BlogAuthor-DetailsDelete--content");

tabs.onclick = e => {
    const id = e.target.dataset.id;
    if (id) {
        tabButton.forEach(btn => {
            btn.classList.remove("active");
        });

        e.target.classList.add("active");

        contents.forEach(content => {
            content.classList.remove("active");
        });

        const element = document.getElementById(id);
        element.classList.add("active");
    }
}

//const tabsIndex = document.querySelector(".BlogAuthor-Index--TabContainerWrapper");
//const tabButtonIndex = document.querySelectorAll(".BlogAuthor-Index--TabButton");
//const contentsIndex = document.querySelectorAll(".BlogAuthor-Index--content");

//tabsIndex.click = e => {
//    const id = e.target.dataset.id;
//    if (id) {
//        tabButtonIndex.forEach(btn => {
//            btn.classList.remove("active");
//        });

//        e.target.classList.add("active");

//        contentsIndex.forEach(content => {
//            content.classList.remove("active");
//        });

//        const element = document.getElementById(id);
//        element.classList.add("active");
//    }
//}

function showDetails(id) {
    //alert(id);
    $("#content-" + id).show();
    $("#blank-content-" + id).hide();   

}

function showPosts(id) {
    $("#content-" + id).hide();
    $("#blank-content-" + id).show();

}

function fadeRemove(id) {
    $("#BlogAuthor-AsyncDelete--Entree-" + id).fadeOut(300, function () {
        $("#BlogAuthor-AsyncDelete--Entree-" + id).remove();
    });
}