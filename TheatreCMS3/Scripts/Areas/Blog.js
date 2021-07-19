let onLikeClickUrl = $("#OnLikeClick").val();

$.ajax({
    url: onLikeClickUrl,
    type: 'POST',
    data: JSON.stringify({ "PID"; parseInt(PID) }),
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (result) {
        $('#dvLoader').hide();

        if (result.Status == "True") {
            toastr.success(result.Message);
            clear();
            display();
        }
        else {
            toastr.success(result.Message);
            clear();
            display();
        }
    }
})