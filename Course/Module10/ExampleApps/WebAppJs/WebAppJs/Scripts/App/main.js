/*sdfgsdfg*/
$(".load").click(function () {
    // $.ajax("/api/values")
    $.get("/api/values")
        .done(function (data) {
            alert("second success " + JSON.stringify(data));
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            debugger;
            alert("error");
        })
        .always(function () {
            alert("finished");
        });
});

$(".save").click(function () {
    let form = $(this).parents("form");
    let data = {};
    $("input", form).each(function (index, el) {
        let $el = $(el);
        data[$el.attr("name")] = $el.val();
    });
    $.post("/api/values", data);

    //var formData = new FormData();
    //formData.append("value", '1111');
    //$.ajax({
    //    url: "/api/values",
    //    type: 'POST',
    //    cache: false,
    //    contentType: false,
    //    processData: false,
    //    data: formData,
    //    success: function (response) {
    //        alert(response);
    //    }
    //});
});