$(document).ready(function () {
    //submit excel form
    $("#_submit_seance").click(function () {
        if (document.getElementById("excel_seance").files.length == 0) {
            return;
        } else {
            $("#_submit_form_seance").submit();
        }
    });

    $("#_submit").click(function () {
        if (document.getElementById("excel_semaine").files.length == 0) {
            return;
        } else {
            $("#_submit_form").submit();
        }
    });
});

var password = document.getElementById("newPassword")
    , confirm_password = document.getElementById("confirmNewPassword");

function validatePassword() {
    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Les mots de passe ne correspondent pas");
    } else {
        confirm_password.setCustomValidity('');
    }
}
password.onchange = validatePassword;
confirm_password.onkeyup = validatePassword;

