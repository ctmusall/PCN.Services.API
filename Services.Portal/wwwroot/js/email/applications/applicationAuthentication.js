var emailAuthentication = {
    createToken: function () {
        $.ajax({
            type: "POST",
            url: "/EmailToken/GetEmailToken",
            success: function (data) {
                sessionStorage.setItem("emailToken", JSON.parse(data));
                applicationGrid.createGrid();
            }
        });
    }
};

$(function () {
    emailAuthentication.createToken();
});