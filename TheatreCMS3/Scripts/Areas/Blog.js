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

    $("#content").show();
    $("#blank-content").hide();   

}

function showPosts(id) {
    $("#content").hide();
    $("#blank-content").show();

}

//function showDetails(id) {
//    var id = '#AuthorDetails';
//    $(id).attr("#id", "-1");
//    $(id).change(function () {
//        $(id + 'button').each(function () {
//            $('#' + this.id).hide();
//        });

//    })
//    $(id).each(function () {
//        $("#blank-content" + this.id).hide();
//    });
//    $("#BlogPosts").each(function () {
//        $("#content" + this.id).show();
//    });



//}

//function showPosts(id) {
//    $(document).ready(function () {
//        $("#AuthorDetails").click(function () {
//            $("#blank-content").show();
//        });
//        $("#BlogPosts").click(function () {
//            $("#content").hide();
//        });
//    });

//}

//$(document).ready(function () {
//    var 
    


//});