var ProductionDetailPostBackURL = '/Prod/Productions/DetailsModal';
$(function () {
    $("#ModalButton").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        $.ajax({
            type: "GET",
            url: ProductionDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            dataType: "json",
            success: function (data) {
                $('#ModalContent').html(data);
                $('#DetailsModal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
});