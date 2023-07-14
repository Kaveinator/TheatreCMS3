$('#check-box').change(function () {
    console.log('why are you not working??')
    setLabel();
});

function setLabel() {
    var damageTrue = $('#check-box').is(':checked');
    var damageNotes = damageTrue ? 'Damages Incurred' : 'Notes';
    var damagesIncurredLabel = $('#damages-incurred-label'); 
    damagesIncurredLabel.text(damageNotes);
}