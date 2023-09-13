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

$(document).ready(function () {
    function toggleGraphic() {
        var Checked = $('#RentalDamaged').is(':checked');
        var Graphic = Checked ? 'x' : 'o' ;
        $('#damageGraphic').text(label);
    }
    toggleLabel();
    $('#damagedGraphic').change(function () {
        toggleLabel();
    });
});

$(".check").each(function () {
    $(this).hide();

    var $image = $(<i class="fa-solid fa-circle-xmark" style="color: #ff0000;"></i>).insertAfter(this);

    $image.click(function () {
        var $check-box = $(this.prev(".check");
        $check-box.prop('checked', !$checkbox.prop('checked'));

        if ($check-box.prop("checked")) {
            $image.attr(<i class="fa-solid fa-square-check" style="color: #00ff40;"></i>);
        } else {
            $image.attr(<i class="fa-solid fa-circle-xmark" style="color: #ff0000;"></i>);
        }
    });
});