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

//function deleteAuthor() {
//    //var getId = $.ajax({
//    //    type: "GET",
//    //    url: "/BlogAuthors/Delete/" + Id
//    /*})*/
//    if (confirm("Are you sure you want to delete this author?")) {
//            console.log("Hello");
//    } else {
//        console.log("Hello1");
//    }
//}

//var modal = document.getElementById('simpleModal');
//var modalBtn = document.getElementById('modalBtn');
//var closeBtn = document.getElementsByClassName('closeBtn')[0];


//modalBtn.addEventListener('click', openModal);

//closeBtn.addEventListener('click', closeModal);

//window.addEventListener('click', outsideClick);

//function openModal() {
//    modal.style.display = 'block';
//}

//function closeModal() {
//    modal.style.display = 'none';
//}

//function outsideClick(e) {
//    if (e.target == modal) {
//        modal.style.display = 'none';
//    }
//}

$(document).ready(function () {
    $('.deleteAuthor').click(function (x) {
        x.preventDefault();
        var authorRequestId = $(this).data('indexDelete')
        console.log(authorRequestId);
        if (confirm("are you sure you want to delete the author?")) {
            $.ajax({
                url: '/blogauthors/delete/' + authorrequestid,
                type: 'post',
                success: function (result) {
                    console.log(result)
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    });
});