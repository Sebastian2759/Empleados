$(function () {
    var jwtToken = sessionStorage.getItem("jwtToken");
    if (jwtToken) {
        $('#input_apiKey').val('Bearer ' + jwtToken);
    }
});