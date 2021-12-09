// get the variable for the label and checkbox
var damage = document.querySelector("#RentalDamaged");
var decs = document.querySelector("#RentalLabel");
// Listener when checked or enchecked
damage.addEventListener('change', function () {
    if (this.checked) {
        decs.innerHTML = "Damages Incurred";
    }
    else {
        decs.innerHTML = "Notes";
    }
});
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