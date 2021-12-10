/*blogauthoer JS*/

$(document).ready(function () {
    $('.blogauthor-details-tab-container:first').show();
    $('.blogauthor-details-tab-navigation .blogauthor-details-li:first').addClass('active');

    $('.blogauthor-details-li').click(function(event) {
        index = $(this).index();
        $('.blogauthor-details-li').removeClass('active');
        $(this).addClass('active');
        $('.blogauthor-details-tab-container').hide();
        $('.blogauthor-details-tab-container').eq(index).show();
    });
})


/*End Blogauthor JS*/