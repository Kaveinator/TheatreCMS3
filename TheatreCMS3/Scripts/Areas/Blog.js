// Blog Author Section Start
var details = document.getElementById("ContentAuthorDetails");
var detailsButton = document.getElementById("BtnAuthorDetails")
var post = document.getElementById("ContentAuthorPost");
var postButton = document.getElementById("BtnAuthorPost")
var contact = document.getElementById("ContentAuthorContact")
var contactButton = document.getElementById("BtnAuthorContact")
var twitter = document.getElementById("ContentAuthorTwitter")
var twitterButton = document.getElementById("BtnAuthorTwitter")

function ResetAuthorMenu() {
    details.style.display = "none";
    post.style.display = "none";
    contact.style.display = "none";
    twitter.style.display = "none";
    detailsButton.style.backgroundColor = '#4a4a4a';
    postButton.style.backgroundColor = '#4a4a4a';
    contactButton.style.backgroundColor = '#4a4a4a';
    twitterButton.style.backgroundColor = '#4a4a4a';
}

function btnAuthorDetails() {
    if (details.style.display === "none") {
        ResetAuthorMenu();
        details.style.display = "block";
        document.getElementById('BtnAuthorDetails').style.backgroundColor = 'green';
    }
}

function btnAuthorPost() {
    if (post.style.display === "none") {
        ResetAuthorMenu();
        post.style.display = "block";
        document.getElementById('BtnAuthorPost').style.backgroundColor = 'green';
    }
}

function btnAuthorContact() {
    if (contact.style.display === "none") {
        ResetAuthorMenu();
        contact.style.display = "block";
        document.getElementById('BtnAuthorContact').style.backgroundColor = 'green';
    }
}

function btnAuthorTwitter() {
    if (twitter.style.display === "none") {
        ResetAuthorMenu();
        twitter.style.display = "block";
        document.getElementById('BtnAuthorTwitter').style.backgroundColor = 'green';
    }
}

function upvote(id) {
    $.ajax({
        url: "/Comment/Upvote/" + id,
        type: "POST",
        data: JSON.stringify({ "id": id }),
        success: function (message) {
            console.log(message)
            $(".comment-likes[data-commentId=" + id + "]").html(message.message)
            $(".progress-bar[data-commentId=" + id + "]").css('width', message.ratio)
        }
    })
}

function downvote(id) {
    $.ajax({
        url: "/Comment/Downvote/" + id,
        type: "POST",
        data: JSON.stringify({ "id": id }),
        success: function (message) {
            console.log(message)
            $(".comment-dislikes[data-commentId=" + id + "]").html(message.message)
            $(".progress-bar[data-commentId=" + id + "]").css('width', message.ratio)
        }
    })
}

function remove(id) {
    $.ajax({
        url: "/Comment/Delete/" + id,
        type: "POST",
        data: JSON.stringify({ "id": id }),
        success: function (message) {
            console.log(message.id, message.success)
            if (message.success === true) {
                $(".comment-item[data-commentId=" + id + "]").hide()
                $(".comment-deleted").show()
                setTimeout(function () {
                    $(".comment-deleted").fadeOut('slow')
                }, 3000)
            }
            else {
                $(".comment-not-deleted").show()
                setTimeout(function () {
                    $(".comment-not-deleted").fadeOut('slow')
                }, 3000)
            }
        }
    })
}

function passCommentId(id) {
    var commentId = id
    console.log(commentId)
    $(".btn-trash").attr("onclick", "remove(" + commentId + ")")
}