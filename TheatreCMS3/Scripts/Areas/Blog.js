//--------- Blog Author Pages ----------

//jQuery | Blog Author Details/Delete Buttons script
let currentSection = '#detailsButton'

$("#detailsButton").click(() => {
    location.reload();
    $('#detailsButton').removeClass('btn-dark');
    $("#detailsButton").addClass('btn-success');
    $(currentSection).removeClass('btn-success');
    $(currentSection).addClass('btn-dark');
    currentSection = '#detailsButton'
})

$("#blogPostsButton").click(() => {
    $(".blog_author-details-delete--authorTextContainer").text('For future stories');
    $('#blogPostsButton').removeClass('btn-dark');
    $("#blogPostsButton").addClass('btn-success');
    $(currentSection).removeClass('btn-success');
    $(currentSection).addClass('btn-dark');
    currentSection = '#blogPostsButton'
})

$("#contactButton").click(() => {
    $(".blog_author-details-delete--authorTextContainer").text('For future stories');
    $('#contactButton').removeClass('btn-dark');
    $("#contactButton").addClass('btn-success');
    $(currentSection).removeClass('btn-success');
    $(currentSection).addClass('btn-dark');
    currentSection = '#contactButton'
})

$("#twitterButton").click(() => {
    $(".blog_author-details-delete--authorTextContainer").text('For future stories');
    $('#twitterButton').removeClass('btn-dark');
    $("#twitterButton").addClass('btn-success');
    $(currentSection).removeClass('btn-success');
    $(currentSection).addClass('btn-dark');
    currentSection = '#twitterButton'
})