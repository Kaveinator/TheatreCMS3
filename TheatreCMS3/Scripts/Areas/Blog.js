//const { data } = require("jquery");
//const { default: index } = require("../esm/popper-utils");

// Comment Like/Dislike script
//$(document).ready(function () {
//	 Call function when icon is clicked
//	$("#comment-upvote").click(function () {
//		$.ajax({
//			type: "POST",
//			url: location.href,
//			data: JSON.stringify({ "id": id }),
//			dataType: "json",
//			success: function (data) {
//			alert("Hello");
//			}
//		}); 
//	});
//}

//$.ajax({
//	url: ,
//	type: "POST",
//	data: JSON.stringify({ "id": parseInt(id) }),
//	success: function (result) {
//		alert("Hello World?");
//	}
//});

function upvote(id) {
	$.ajax({
		url: @Url.Action("Upvote", "Comment"),
		type: "POST",
		data: JSON.stringify(id),
		success: function (message) {
			alert(message);
	}
	})
}