
//likesButton.click(function () {
//        $.ajax({
//            type: 'POST',
//            url: '@Url.Action("LikeButtonIncrease", "CommentsController")',
//            data: 
              //"/Comments/addLike",
            
            


//})

//    dislikesButton.click(function () {
//        dislikes += 1;
//    })


//})

function addLike(id) {
    $.ajax({
        type: 'POST',
        url: "/Comments/addLike",
        data: { id: id }
    });
    console.log(id);
    
};

function addDislike(id) {
    $.ajax({
        type: 'POST',
        url: "/Comments/addDislike",
        data: { id: id }
    });
    console.log(id);

};        

