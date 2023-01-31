

function Likes(Id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLikes",
        data: { id: id },
    })
}
