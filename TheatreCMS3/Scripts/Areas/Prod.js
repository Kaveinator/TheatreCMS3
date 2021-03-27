
// Retreive database record from production table and open modal
$(function () {
    $('.ModalButton').click(function () {
        var button = $(this);
        var id = button.attr('data-id');
        $.ajax({
            type: "POST",
            url: '/Prod/Productions/DetailsModal',
            data: {id : id},
            success: function (data) {
                $('#ModalContent').html(data);
                $('#Details').modal('toggle');
            }
        });    
    });
});
$(function () {
	$('.prod-calendar--pop').popover()
})

