function timerInactivo(dotnethelper) {
    var timer;

    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        //timer = setTimeout(logout, 10000 * 6 * 5);
    }

    function logout() {
        dotnethelper.invokeMethodAsync("CerrarSesion");
    }
}