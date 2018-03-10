console.log("Hello, World!");
window.addEventListener("keydown", function (e) {

    // Disable Space + Arrow keys
    if ([32, 37, 38, 39, 40].indexOf(e.keyCode) > -1) {
        e.preventDefault();
    }

}, false);

window.onload = function () {
    document.getElementById("game-iframe").scrollIntoView(true);
};