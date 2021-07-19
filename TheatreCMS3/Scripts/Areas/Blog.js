//Ajax function to Post to BlogPostController with the value taken from the Button creating the modal
$("#BlogPost-index--deleteModal").on('show.bs.modal', function (event) {
    let myUrl = $("#myUrl").val();
    let btn = $(event.relatedTarget);
    let id = btn.val();
    let modal = $(this);
    modal.find("#deleteButton").on("click", function (e) {
        $.ajax({
            type: "POST",
            url: myUrl,
            data: { Id: id },
            success: function () {
                $(btn).closest("tr").hide();
                $("#BlogPost-index--deleteModal").modal("hide");
                $(".BlogPost-index--deleteNotif").fadeIn(500).delay(3000).fadeOut(2000);
            },
            error: function () {
            }
        });
    });
})

//On Close Event for Modal that removes the listener from the DeleteButton that was applied above
$("#BlogPost-index--deleteModal").on('hide.bs.modal', function () {
    let modal = $(this);
    modal.find("#deleteButton").off();
})