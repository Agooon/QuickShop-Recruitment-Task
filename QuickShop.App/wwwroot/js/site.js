// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

console.log("test")
const PlaceHolderElement = $('#modal-holder');
$(function () {

    var buttons = document.querySelectorAll('.btn-modal');
    var buttonItems = [].slice.call(buttons);

    buttonItems.forEach((item) => {
        item.addEventListener('click', (e) => {
            var url = item.getAttribute('data-url');
            console.log(url);
            $.get(url).done((data) => {
                PlaceHolderElement.html(data);
                PlaceHolderElement.find('.modal').modal('show');
            });
        });
    });

});