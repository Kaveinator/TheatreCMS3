const { data } = require("jquery");
const { default: index } = require("../esm/popper-utils");

// Comment Like/Dislike script
/*$(document).ready(function () {*/
	// Call function when icon is clicked
	$("#comment-upvote").click( {
		$.ajax({
			type: "POST",
			url: location.href,
			data: { "id": id },
			dataType: "json",
			success: function (data) {
			alert("Hello");
			}
		}); 
	});
/*}*/