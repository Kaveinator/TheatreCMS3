
function addLike(id) {
    $.ajax({
        type: 'POST',
        url: "/Comments/addLike",
        data: { id: id },
        success: function (response) {
            var likeRatio = (response.Likes / (response.Likes + response.Dislikes)) * 100;
            var commentIdStr = response.CommentId.toString()
            $("#" + "likes-bar-" + commentIdStr).attr('aria-valuenow', likeRatio).css('width', likeRatio + '%')
            $("#" + "likes-bar-" + commentIdStr).text(response.Likes)
            $("#" + "likes-percentage-" + commentIdStr).text(likeRatio.toFixed() + "%")
            $("#" + "dislikes-percentage-" + commentIdStr).text(100 - likeRatio.toFixed() + "%")
            $("#" + "progress-bar-likes-" + commentIdStr).text(response.Likes)
            $("#" + "likes-value-" + commentIdStr).html( response.Likes)
         
            
            
        }



    });
};

function addDislike(id) {
    $.ajax({
        type: 'POST',
        url: "/Comments/addDislike",
        data: { id: id },
        success: function (response) {
            var likeRatio = (response.Likes / (response.Likes + response.Dislikes)) * 100;
            var commentIdStr = response.CommentId.toString()
            $("#" + "dislikes-bar-" + commentIdStr).attr('aria-valuenow', 100 - likeRatio).css('width', 100 - likeRatio + '%')
            $("#" + "dislikes-bar-" + commentIdStr).text(response.Dislikes)
            $("#" + "likes-percentage-" + commentIdStr).text(likeRatio.toFixed() + "%")
            $("#" + "dislikes-percentage-" + commentIdStr).text(100-likeRatio.toFixed() + "%")
            $("#" + "progress-bar-dislikes-" + commentIdStr).text(response.Dislikes)
            $("#" + "dislikes-value-" + commentIdStr).html( response.Dislikes)
        }
    });

};        

