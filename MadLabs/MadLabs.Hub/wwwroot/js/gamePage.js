window.addEventListener("keydown", function (e) {

    // Disable Space + Arrow keys
    if ([32, 37, 38, 39, 40].indexOf(e.keyCode) > -1) {
        e.preventDefault();
    }

}, false);

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById("game-iframe").scrollIntoView(true);
});