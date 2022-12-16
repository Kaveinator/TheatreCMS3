//--------- Blog Author Pages ----------


//Call upon clicking delete button
function deleteAuthor(authorId) {
    //Define delete modal id
    let deleteModal = '#' + authorId + '-deleteModal'
    //Open delete modal css
    $(deleteModal).show();
    $("body").css("overflow-y", "hidden");
    $(".blog_author-index-authorCardContainer, #createNewButton").css("opacity", "0.5");
}

//Call upon clicking x button in modal
function closeModal(authorId, buttonName) {
    //Define delete modal id
    let deleteModal = '#' + authorId + '-deleteModal'
    //Close delete modal - css
    $(deleteModal).hide();
    $("body").css("overflow-y", "visible");
    $(".blog_author-index-authorCardContainer, #createNewButton").css("opacity", "1");

    //Upon clicking the deleteButton removes author from page and database
    if (buttonName == 'deleteButton') {
        //Fade out animation
        $('.' + authorId).fadeOut(500);

        $.ajax({
            type: "POST",
            url: "/BlogAuthors/AsyncDelete",
            data: { id: authorId },
        })
    }
    
}

//Author info buttons
function viewAuthorInfo(authorId, buttonName) {

    //Define buttons
    let detailsButton = '#' + authorId + '-detailsButton'
    let blogPostsButton = '#' + authorId + '-blogPostsButton'
    let contactButton = '#' + authorId + '-contactButton'
    let twitterButton = '#' + authorId + '-twitterButton'
    let buttonClicked = '#' + authorId + '-' + buttonName

    //Reset colors of each button
    $(detailsButton).removeClass('btn-success')
    $(detailsButton).addClass('btn-dark')

    $(blogPostsButton).removeClass('btn-success')
    $(blogPostsButton).addClass('btn-dark')

    $(contactButton).removeClass('btn-success')
    $(contactButton).addClass('btn-dark')

    $(twitterButton).removeClass('btn-success')
    $(twitterButton).addClass('btn-dark')

    //Update the clicked button's color
    $(buttonClicked).removeClass('btn-dark')
    $(buttonClicked).addClass('btn-success')

    //Run upon clicking 'author details', resets the author section text
    if (buttonName == 'detailsButton') {
        location.reload();
    }
    //Will run upon clicking any other button 
    else {
        $('.' + authorId + " .blog_author-details-delete--authorTextContainer").text('For future stories');
    }
}



//--------- BlogPost Pages ----------


// this function gets a the unique id passed to, communicates with the controller through ajax and calls the DeletePostAsync JSONRESULT method
function DeleteBlogPost(id) {
    $.ajax({
        type: "POST",
        url: "/BlogPosts/DeletePostAsync", //sends unique id and calls controller method
        data: { id: id },
    })
        .done(function () { 
            $("#BlogPost-" + id).remove();//once this gets hit the post is removed from the users view
            $("#" + id).fadeIn(500).delay(3000).fadeOut(500); // targets div on index and fades in a message letting the user know a post has been successfully deleted and then fades out.
        
         })
}
