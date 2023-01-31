

function Likes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLikes",
        data: {id: id},
    })
}
