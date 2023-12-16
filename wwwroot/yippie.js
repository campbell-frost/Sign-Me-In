window.playSound = function () {
    var audio = document.getElementById('yippieAudio');
    if (audio) {
        audio.currentTime = 0;
        audio.play();
    }
};
