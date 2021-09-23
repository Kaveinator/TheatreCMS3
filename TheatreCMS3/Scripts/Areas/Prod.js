
//Modal script 
var ProductionDetailsURL = '/Productions/IndexModal';
$(function () {
    $(".anchorDetail").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id')
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: ProductionDetailsURL,
            contentType: "application/json; charset=utf-8",
            data: { "ProductionId": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');
            },
            error: function () {
                alert("Something went wrong. Failed to load.");
            }
        });
    });
    $("#closebtn").click(function () {
        $('#myModal').modal('hide');
    });
});