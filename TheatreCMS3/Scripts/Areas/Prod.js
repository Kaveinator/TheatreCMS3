$('#production-index--detailsModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal

    var title = button.data('title') // Extract info from data-* attributes
    var desc = button.data('desc')
    var playwright = button.data('playwright')
    var runtime = button.data('runtime')
    var opening = button.data('opening')
    var closing = button.data('closing')
    var showtimeeve = button.data('showtimeeve')
    var showtimemat = button.data('showtimemat')
    var season = button.data('season')
    var premiere = button.data('premiere')
    var tickets = button.data('tickets')
    var currently = button.data('currentlyshowing')
    
    var modal = $(this) //updates modal with variable info
    modal.find('.prodTitle').text('Title: ' + title)
    modal.find('.prodDesc').text('Description: ' + desc)
    modal.find('.prodPlaywright').text('Playwright: ' + playwright)
    modal.find('.prodRuntime').text('Runtime: ' + runtime)
    modal.find('.prodOpen').text('Opening Day: ' + opening)
    modal.find('.prodClose').text('Closing Day: ' + closing)
    modal.find('.prodTimeEve').text('Evening Show Time: ' + showtimeeve)
    modal.find('.prodTimeMat').text('Morning Show Time: ' + showtimemat)
    modal.find('.prodSeason').text('Season: ' + season)
    modal.find('.prodPremiere').text('World Premiere: ' + premiere)
    modal.find('.prodTickets').text('Ticket link: ' + tickets)
    modal.find('.prodCurrently').text('Currently Showing: ' + currently)
})