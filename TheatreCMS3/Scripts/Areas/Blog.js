//const { data } = require("jquery");
//const { default: index } = require("../esm/popper-utils");


function upvote(id) {
	$.ajax({
		url: "/Comment/Upvote/" + id,
		type: "POST",
		data: JSON.stringify({ "id" : id }),
		success: function (message) {
			console.log(message)
			$(".comment-likes[data-CommentId=" + id + "]").html(message.message)
	}
	})
}

function downvote(id) {
	$.ajax({
		url: "/Comment/Downvote/" + id,
		type: "POST",
		data: JSON.stringify({ "id" : id }),
		success: function (message) {
			console.log(message)
			$(".comment-dislikes[data-CommentId=" + id + "]").html(message.message)
	}
	})
}