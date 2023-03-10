$(document).ready(() => {

    $(".limpar").click(() => {
        $(".form-control").val("");
    })

    $(".form").validate();
});