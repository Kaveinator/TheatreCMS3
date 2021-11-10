/* the popup message when a BlogPost is deleted should have a green theme 
 * and a Font-Awesome checkmark at the end of the sentence.  When the BlogPost is deleted, 
 * this message should appear and stay on the screen for 3 seconds, then fade out and disappear. */

$('#BlogPost-Index--ModalConfirmDelete').on('show.bs.modal', function (event) {
    var id = $(event.relatedTarget).data('blogpostid');                 /* getting the wrap of the individual blog post on the index page. */
    var blogpost = $('#' + id);                                         /* get the blogpost id associated with the Delete button */                                          
    var title = blogpost.find(".BlogPost-Title").text();
    var author = blogpost.find(".BlogPost-Author").text();
    var posteddate = blogpost.find(".BlogPost-Datetime").text();
    var modal = $(this);
    modal.find('.modal-title').html("CONFIRM DELETE");
    /*  use a Bootstrap modal.  Ask the user if they are sure they want to delete this BlogPost. */
    modal.find('.modal-body').html("Select Confirm Delete to Delete the following Blog Post: <br/><br/> Blog Post Title: "
        + "<div class='modalTexts'>" + title + "</div>" + "<br/>Author: "
        + "<div class='modalTexts'>" + author + "</div>" + "<br/>Posted Date: "
        + "<div class='modalTexts'>" + posteddate + "</div>" + "<br/>");
    modal.find('#BlogPost-Index--ConfirmDelete').val(id);
})

/* 1. put/assign info to the modal.
    .on JQuery method start an event watcher. show.bs.modal is the specific event - start trying to show the modal.
    function(event): call the function, event as an argument.
    event.relatedTarget: caused the event. Delete button's data-toggle & data-target that is activating this.
    get id from the button= button.data in the html of data-blogpostid.
    using .find (either nested or child of the tag), get the title
    same for author
    grabbing the modal, this = #BlogPostModalConfirmDelete... 
    overwrite the .modal-title info with title. .text is string
    .html allows using of html syntax
    .val() assign a value to the the button.

    JS: each tag is its own object. grab it by class, id, etc.
 */



// 2. ajax delete from the database.
$('#BlogPost-Index--ConfirmDelete').click(function () {
    var confirmDeleteId = $(this).val();
    var blogpost = $('#' + confirmDeleteId);                            /* get the id of the confirmDelete post */
    $.ajax({                                                            /* when Confirm Delete is clicked */
        url: '/BlogPost/AjaxDelete',
        type: 'Post',
        data: { id: confirmDeleteId },
    })
        .done(function (results) {                                      /* if successful */
            /* Clicking the confirm button should delete the BlogPost
             * without reloading the page (using Ajax is one possible solution), hide the deleted BlogPost on the page */
            blogpost.fadeOut(50);
            /* display a fixed message at the top of the page 
             * that says "The blog post was deleted successfully" if the BlogPost was successfully deleted.
             * The popup message when a BlogPost is deleted should have a green theme and a Font-Awesome checkmark at the end of the sentence.  
             * When the BlogPost is deleted, this message should appear and stay on the screen for 3 seconds, then fade out and disappear.*/
            $("#fademsg").html("The blog post: " + results.Data[0] + " was deleted successfully <i class='fas fa-check' style='padding-left: 12px;'></i>").css({ "display": "block" });
            $("#fademsg").fadeOut(3000);
        })
        .fail(function (xhr, status, error) { alert(xhr.statusText); alert(status); alert(error); })
});
 
/* activate when the confirmdelete button is clicked
   grab the value of that button of the .val assign as confirmDeleteId.
   start ajax response
   url location method
   type is post= HttpPost method.
   data: actual info sending to the controller: AjaxDelete
   waits for respsonse from controller
   if result is sucess then .done function is run, or else .fail will run.
   always set (xhr, status, error)  
*/


