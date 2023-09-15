////const contain = document.getElementById('table');
////const hiddenDiv = document.getElementById('dropdown');

////contain.addEventListener('mouseover', function handleMouseOver() {
////    hiddenDiv.style.display = 'block';
////});

$(".dropdown").hide(onload)

$(document).ready(function () {
    $('.rentContainer').hover(
        function () {
            $(this).find('.dropdown').show();
        },
        function () {
            $(this).find('.dropdown').hide();
        }
    );
});



$(document).ready(function () {
    function toggleLabel() {
        var isChecked = $('#RentalDamaged').is(':checked');
        var label = isChecked ? 'Damages Incurred' : 'Notes';
        $('#damageLabel').text(label);
    }
    toggleLabel();
    $('#RentalDamaged').change(function () {
        toggleLabel();
    });
});
