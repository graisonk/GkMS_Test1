// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DelProfile(isTrue) {
    if (isTrue) {
        $('#DelConfirm').show();
        $('#DelPrompt').hide();
    }
    else {
        $("#DelConfirm").hide();
        $("#DelPrompt").show();
    }
}