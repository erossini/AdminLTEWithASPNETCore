var idleTime = 0;

$(document).ready(function () {
    console.log("Start detect inactivity");
    //Increment the idle time counter every minute.
    var idleInterval = setInterval(timerIncrement(), 6000); // 1 minute

    //Zero the idle timer on mouse movement.
    $(this).mousemove(function (e) {
        idleTime = 0;
    });
    $(this).keypress(function (e) {
        idleTime = 0;
    });
});

function timerIncrement() {
    console.log("Inactivity for " + idleTime + " minutes");
    idleTime = idleTime + 1;
    if (idleTime > afterMinutes) {
        window.location.redirectUrl = redirectUrl;
    }
}