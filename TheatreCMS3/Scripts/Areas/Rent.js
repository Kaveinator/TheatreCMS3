// Toggel the drowpdown menu
$('.dropdown').hover(function () {
    $(this).children(".dropdown-menu").css({
        "display": "block"
    });
}, function () {
    $(this).children(".dropdown-menu").css({
        "display": "none"
    });
});