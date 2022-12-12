//--------- Blog Author Pages ----------

function viewAuthorInfo(authorId, buttonName) {

    //Define buttons
    let detailsButton = '#' + authorId + '-detailsButton'
    let blogPostsButton = '#' + authorId + '-blogPostsButton'
    let contactButton = '#' + authorId + '-contactButton'
    let twitterButton = '#' + authorId + '-twitterButton'
    let buttonClicked = '#' + authorId + '-' + buttonName

    //Clear all button colors
    $(detailsButton).removeClass('btn-success')
    $(detailsButton).addClass('btn-dark')

    $(blogPostsButton).removeClass('btn-success')
    $(blogPostsButton).addClass('btn-dark')

    $(contactButton).removeClass('btn-success')
    $(contactButton).addClass('btn-dark')

    $(twitterButton).removeClass('btn-success')
    $(twitterButton).addClass('btn-dark')

    //Update clicked button color
    $(buttonClicked).removeClass('btn-dark')
    $(buttonClicked).addClass('btn-success')

    //Update author text
    if (buttonName == 'detailsButton') {
        location.reload();
    } else {
        $('.' + authorId + " .blog_author-details-delete--authorTextContainer").text('For future stories');
    }

}