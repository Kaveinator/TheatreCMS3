
// Change display of Current and Expired Rental Request Cards
function RentRequestCurrentExpire() {
    // Change the name of the button
    var btnName = document.getElementById("rentReqToggleBtn").textContent.trim();
    if (btnName === "Expired rentals") {
        document.getElementById("rentReqToggleBtn").textContent = "Current rentals";
    } else {
        document.getElementById("rentReqToggleBtn").textContent="Expired rentals";      
    }

    // Toggle the cards from hidden to show and vis versa
    $(".RRCurrentCard").toggle();
    $(".RRExpiredCard").toggle();
}
