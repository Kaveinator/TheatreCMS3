// For Rent Request Toggle button
function RentRequestCurrentExpire() {
    var btnName = document.getElementById("rentReqToggleBtn").textContent.replace(/\s/g, "");
    if (btnName == "Expired") {
        document.getElementById("rentReqToggleBtn").textContent = "Current";


    } else {
        document.getElementById("rentReqToggleBtn").textContent="Expired";
       
    }

    

    //$("#rentReqToggleBtn").click(function (e) {
    //document.getElementById("rentReqToggleBtn").addEventListener("click", function (e) {
    //    const tgt = e.target;
    //    const text = tgt.textContent.replace(/\s/g, "");
    //    //tgt.textContent = text === "Expired" ? "Current" : "Expired"
    //    if (text == "Expired") {
    //        tgt.textContent = "Current";
    //        var expiredOrNot = document.getElementById("expiredOrNot").textContext;
    //        if ( expiredOrNot == "Expired!") {
    //            document.getElementById('displayRentalRequestDiv').style.display = "none";
    //        }

    //    }else {
    //        tgt.textContent = "Expired";
    //        document.getElementById('displayRentalRequestDiv').hidden = true;   
    //    }

    //});
}


// Function to change style of expired rentals to hidden
function hideMeFunction(){
    var x = document.getElementById("displayRentalRequestDiv");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}
