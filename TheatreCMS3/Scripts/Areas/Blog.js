//const { data } = require("jquery");
//const { default: index } = require("../esm/popper-utils");

function upvote(id) {
	$.ajax({
		url: "/Comment/Upvote/" + id,
		type: "POST",
		data: JSON.stringify({ "id" : id }),
		success: function (message) {
			console.log(message)
			$(".comment-likes[data-commentId=" + id + "]").html(message.message)
			$(".progress-bar[data-commentId=" + id + "]").css('width', message.ratio)
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
			$(".comment-dislikes[data-commentId=" + id + "]").html(message.message)
			$(".progress-bar[data-commentId=" + id + "]").css('width', message.ratio)
	}
	})
}

function remove (id) {
	$.ajax({
		url: "/Comment/Delete/" + id,
		type: "POST",
		data: JSON.stringify({ "id" : id }),
		success: function (message) {
			console.log(message.id, message.success)
			if (message.success === true) {
				$(".comment-item[data-commentId=" + id + "]").hide()
				$(".comment-deleted").show()
				setTimeout(function () {
					$(".comment-deleted").fadeOut('slow')
				}, 3000)
			}
			else {
				$(".comment-not-deleted").show()
				setTimeout(function () {
					$(".comment-not-deleted").fadeOut('slow')
				}, 3000)
			}
		}
	})
}