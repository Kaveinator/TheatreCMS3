$('#BlogPost-Index--ModalConfirmDelete').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var id = button.data('blogpostid');
    var blogpost = $('#' + id);
    var title = blogpost.find(".BlogPost-Title").text();
    var author = blogpost.find(".BlogPost-Author").text();
    var posteddate = blogpost.find(".BlogPost-Datetime").text();
    var modal = $(this);
    modal.find('.modal-title').html("CONFIRM DELETE");
    modal.find('.modal-body').html("Select Confirm Delete to Delete the following Blog Post: <br/><br/>Blog Post Title: "
        + "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + title + "</b>" + "<br/>Author: "
        + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + author + "</b>" + "<br/>Posted Date: "
        + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + posteddate);
})

/* .on JQuery method start an event watcher. show.bs.modal is the specific event - start trying to show the modal.
    function(event): call the function, event as an argument.
    event.relatedTarget: caused the event. data-toggle & data-target that is activating this.
    get id from the button= button.data in the html of data-blogpostid.
    using .find (either nested or child of the tag), get the title
    same for author
    grabbing the modal, this = #BlogPostModalConfirmDelete... 
    overwrite the .modal-title info with title. .text is string
    .html allows using of html syntax

    JS: each tag is its own object. grab it by class, id, etc.
 */