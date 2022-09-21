// function counts the number of devs who have signed in
// on the sign-in page by counting the number of child <p>
// elements in the #PersonList <div>
$().ready(function () {
    const dev_count = $('#PersonList p').length;
    $('#NumPersons').html(dev_count);
});

