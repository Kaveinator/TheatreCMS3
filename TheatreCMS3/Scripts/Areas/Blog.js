

// New Comment Event
const newCommentEvent = (e) => {
    var message = $("#commentMessage").val();
    // check if the message is empty or white spaces
    if (message.trim().length < 1) {
        $("#commentMessage").attr("placeholder", "Please type something");
    }
    else {
        var path = e.target.getAttribute("data-CommentPath");
        //Sends input text to Create method in controller which creates a new comment in the Db with text input as comment Message
        $.ajax({
            type: "POST",
            url: path,
            data: { message: message },
            success: function (result) {
                //Replace input text with placeholder text
                $("#commentMessage").val(null);
                var jQueryResult = $(result);
                // Add like
                jQueryResult.find('.likeBtn').click(addLikeEvent);
                // Add Dislike
                jQueryResult.find('.dislikeBtn').click(addDislikeEvent);
                // Click Trashcan
                jQueryResult.find('.trashcan').click(trashcanEvent);
                // Click Reply - show form
                jQueryResult.find('.replyBtn').click(replyEvent);
                // Add New Reply Comment - submit new reply comment
                jQueryResult.find('.replySubmitBtn').click(newReplySubmitEvent);
                // Cancel Reply - hide form
                jQueryResult.find('.cancelReplyBtn').click(cancelReplyEvent);
                // Add new comment to top of the list
                $(".newComment").prepend(jQueryResult);
            },
            error: function (request, status, error) {
                serviceError();
            }
        });
    }
}


// Add Like Event
const addLikeEvent = (e) => {
    console.log("like clicked");
    console.log(e);
    var id = e.target.getAttribute("data-CommentId");
    var path = e.target.getAttribute("data-CommentPath");
    $.ajax({
        type: "POST",
        url: path,
        data: JSON.stringify({ "id": id }),
        success: function (result) {
            $(".likes[data-CommentId=" + id + "]").html(result.like);
            $(".progress-bar[data-CommentId=" + id + "]").css('width', result.ratio + '%');
            $(".like-ratio[data-CommentId=" + id + "]").html(result.ratio + '% likes');
        }
    });
}

// Add Dislike Event
const addDislikeEvent = (e) => {
    console.log("dislike clicked");
    var id = e.target.getAttribute("data-CommentId");
    var path = e.target.getAttribute("data-CommentPath");
    $.ajax({
        type: "POST",
        url: path,
        data: JSON.stringify({ "id": id }),
        success: function (result) {
            $(".dislikes[data-CommentId=" + id + "]").html(result.dislike);
            $(".progress-bar[data-CommentId=" + id + "]").css('width', result.ratio + '%');
            $(".like-ratio[data-CommentId=" + id + "]").html(result.ratio + '% likes');
        }
    });
} 
// Trashcan Event
const trashcanEvent = (e) => {
    console.log('trashcan clicked');
    $(".deleteConfirmed").attr('data-CommentPath', e.target.getAttribute("data-CommentPath"));
    $(".deleteConfirmed").attr('data-CommentId', e.target.getAttribute("data-CommentId"));
}

// Reply Event
const replyEvent = (e) => {
    var id = e.target.getAttribute("data-CommentId");
    console.log('reply clicked');
    $(".hiddenComment[data-commentId=" + id + "]").fadeIn(100);
}

// Cancel Reply Event
const cancelReplyEvent = (e) => {
    var id = e.target.getAttribute("data-CommentId");
    console.log('cancel reply button clicked');
    $(".hiddenComment[data-commentId=" + id + "]").fadeOut(100);
}

// Add New Reply Submit Comment Event
const newReplySubmitEvent = (e) => {
    console.log('new reply submit clicked');
    // Get text from box
    var message = $('#replyMessage').val();
    var id = e.target.getAttribute("data-CommentId");
    var path = e.target.getAttribute("data-CommentPath");
    // Create new comment and add to list
    $.ajax({
        type: "POST",
        url: path,
        data: { message: message },
        success: function (result) {
            //Replace input text with placeholder text
            $("#commentMessage").val(null);
            var jQueryResult = $(result);
            // Add like
            jQueryResult.find('.likeBtn').click(addLikeEvent);
            // Add Dislike
            jQueryResult.find('.dislikeBtn').click(addDislikeEvent);
            // Click Trashcan
            jQueryResult.find('.trashcan').click(trashcanEvent);
            // Click Reply - show form
            jQueryResult.find('.replyBtn').click(replyEvent);
            // Add New Reply Comment - submit new reply comment
            jQueryResult.find('.replySubmitBtn').click(newReplySubmitEvent);
            // Cancel Reply - hide form
            jQueryResult.find('.cancelReplyBtn').click(cancelReplyEvent);
            // Add new comment to top of the list
            $(".newComment").prepend(jQueryResult);
        },
        error: function (request, status, error) {
            serviceError();
        }
    });

    // Hide Form
    $(".hiddenComment[data-commentId=" + id + "]").fadeOut(100);
}

//

$(document).ready(function () {

    // New Comment Button
    $(".newCommentBtn").click(newCommentEvent); 

    // Add Like
   $(".likeBtn").click(addLikeEvent);

    // Add Dislike
    $(".dislikeBtn").click(addDislikeEvent); 

    // Delete
    $(".trashcan").click(trashcanEvent); 

    // Confirm Delete
    $(".deleteConfirmed").click(function () {
        console.log('deleteConfirmed clicked');
        var id = $(this).attr("data-CommentId");
        var path = $(this).attr("data-CommentPath");
        $.ajax({
            type: "POST",
            url: path,
            data: JSON.stringify({ "id": id }),
            success: function (result) {
                //console.log(result);
                console.log(id);
                $("#deleteModal").modal('hide');
                $(".commentCard[data-commentId=" + id + "]").animate({ height: "0px" }, 1000, function () { $(this).remove(); });
                $(".successBadge").fadeIn(100).delay(3000).fadeOut(500);

            }
        });
    });

    // Cancel comment Button
    $(".cancelCommentBtn").click(function () {
        $("#commentMessage").val(null);
    });

    // Reply button - Displays the comment form below the comment who's reply button the user clicked
    $(".replyBtn").click(replyEvent); 

    //Cancel Reply Button - Hides reply comment form
    $('.cancelReplyBtn').click(cancelReplyEvent); 

    // Add New Reply Comment
    $('.replySubmitBtn').click(newReplySubmitEvent);

});

