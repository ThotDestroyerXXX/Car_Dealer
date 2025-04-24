document.getElementById("filterButton").addEventListener("click", function (event) {
    var pickupDate = document.getElementById("pickupDate").value;
    var returnDate = document.getElementById("returnDate").value;
    if (!pickupDate || !returnDate) {
        alert("Please select both pickup and return dates.");
        event.preventDefault(); // Prevent form submission
        return;
    }
    if (pickupDate && returnDate) {
        if (new Date(pickupDate) >= new Date(returnDate)) {
            alert("Pickup date must be before return date.");
            event.preventDefault(); // Prevent form submission
        }
    }
});
var open = false;
function triggerMenu() {
    var nav = document.getElementById("desktop-nav");
    if (open) {
        // Close the menu
        nav.style.display = "none";
        open = false;
    } else {
        // Open the menu
        nav.style.display = "flex";
        open = true;
    }
}