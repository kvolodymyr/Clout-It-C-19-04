$('.login-button-pass').click(function () {
    $('.login-button-driver').fadeOut(600);
    $('.login-button-pass').fadeOut(600, function () {
        $(".container-pass").fadeIn();
        TweenMax.from(".container-pass", .4, { scale: 0, ease: Sine.easeInOut });
        TweenMax.to(".container-pass", .4, { scale: 1, ease: Sine.easeInOut });
    });
});

$('.login-button-driver').click(function () {
    $('.login-button-pass').fadeOut(600);
    $('.login-button-driver').fadeOut(600, function () {
        $(".container-driv").fadeIn();
        TweenMax.from(".container-driv", .4, { scale: 0, ease: Sine.easeInOut });
        TweenMax.to(".container-driv", .4, { scale: 1, ease: Sine.easeInOut });
    });
});

$(".close-btn").click(function () {
    TweenMax.from(".container-pass", .4, { scale: 1, ease: Sine.easeInOut });
    TweenMax.to(".container-pass", .4, { left: "0px", scale: 0, ease: Sine.easeInOut });
    TweenMax.from(".container-driv", .4, { scale: 1, ease: Sine.easeInOut });
    TweenMax.to(".container-driv", .4, { left: "0px", scale: 0, ease: Sine.easeInOut });
    $(".container-pass, .container-driv").fadeOut(800, function () {
        $(".login-button-pass").fadeIn(800);
        $(".login-button-driver").fadeIn(800);
    });
});

/* Forgotten Password
$('#forgotten').click(function () {
    $("#container").fadeOut(function () {
        $("#forgotten-container").fadeIn();
    });
});*/