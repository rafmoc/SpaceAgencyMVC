// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Action(id, controller, action) {
    $.ajax({
        url: controller + "/" + action,
        type: "GET",
        data: { id: id }
    }).done(function (partialViewResult) {
        $("#partialC").html(partialViewResult);
    })
};