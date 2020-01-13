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


//function myFunction(y) {
//    var x = document.getElementsByName('radioButton');
//    for (var i = 0; i < x.length; i++) {
//        if (x[i].checked == true) {
//            let z = document.getElementById(y).disabled;
//            z = false;
//        }
//    }
//}

// $("button.send", container)
// $container.find("button.send")[0].disabled = false;
// alert(this.value);
// alert($(this).data("id"));

$("[name=radioButton]").click(function () {
    let $that = $(this);
    let $container = $that.parents("tr");
    $("table[name='drivers']").find("button.send").attr("disabled", "disabled");
    $container.find("button.send").removeAttr("disabled");
});


$("button.send").click(function () {
    let $form = $("form");
    let route = $("[name='searchRequset']", $form).val();
    if (!route) {
        alert('Add route');
        return;
    }
    $("[name='driver']", $form).val($(this).data("driverid"));
    $form.submit();
});