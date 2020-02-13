$(document).ready(function () {
    console.log("A");

    $.ajax({
        url: 'Home/GetRoots',
        success: function (e) {
            console.log(e);
        },
        error: function (e) {
            console.log(e);
        }
    })
})