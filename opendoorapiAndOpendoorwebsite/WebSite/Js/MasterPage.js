function ChangePassModalClear() {
    $("#ChangePassModal_message").empty(); // To remove the previous error message
   
    document.getElementById('ChangePassModal_CurrentPass').value = "";
    document.getElementById('ChangePassModal_NewPass').value = "";
    document.getElementById('ChangePassModal_ConfirmPass').value = "";
}
function ChangePassModalClear22() {

}
$(document).ready(function () {
    $('#imgLogOut').click(function () {
        LogOut();
    });
    $('#ChangePassModal_btnSave').click(function () {
        PleaseWaitStatus(true, "ChangePassModal")
        $("#ChangePassModal_message").empty(); // To remove the previous error message
        var ErrorStr = "";
        var userName = getCookie("UserName");
        var currentPass = document.getElementById('ChangePassModal_CurrentPass').value;
        var newPass = document.getElementById('ChangePassModal_NewPass').value;
        var confirmPass = document.getElementById('ChangePassModal_ConfirmPass').value;

        if (currentPass == "" || newPass == "" || confirmPass == "")
            ErrorStr += "All fields are mandatory."
        if (confirmPass != newPass)
            ErrorStr += "Passwords do not match."
        if (ErrorStr != "") {
            $("#ChangePassModal_message").html(ErrorStr);
            PleaseWaitStatus(false, "ChangePassModal");
            return;
        }

        var prm = {
            "UserName": userName,
            "CurrentPass": currentPass,
            "NewPass": newPass
        };

        $.ajax({
            url: APIUrl + "UserCredntials/ChangePass",
            type: "Post",
            data: JSON.stringify(prm),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (response) {
                $("#ChangePassModal_message").html("Server Error: " + response.responseText);
            },
            failure: function (response) {
                $("#ChangePassModal_message").html("Server Error: " + response);
            },
            //async: false,
            success: function (response) {
                var Data = JSON.parse(response);
                if (Data) {
                    $("#ChangePassModal_message").css("color", "green");
                    $("#ChangePassModal_message").html("change password success !");
                    PleaseWaitStatus(false, "ChangePassModal");
                    window.location.replace("#close");
                }
                else {
                    $("#ChangePassModal_message").css("color", "red");
                    $("#ChangePassModal_message").html("Invalid current password");
                    PleaseWaitStatus(false, "ChangePassModal");
                }
            }
        });

    });

});



function ChangePassFunc() {
    var UserName = getCookie("UserName");
    document.getElementById('ChangePassModal_Title').innerText = "Change Password For UserName: " + UserName;
    $('#ChangePassModal_CurrentPass').value = "";
    $('#ChangePassModal_NewPass').value = "";
    $('#ChangePassModal_ConfirmPass').value = "";
    $('#ChangePassModal_message').value = "";
    $("#ChangePassModal_Content").css("visibility", "visible");
    ChangePassModalClear();
    window.location.replace("#ChangePassModal");
}

