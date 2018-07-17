var APIUrl = "http://localhost:54999/api/";
function formatErrorMessage(jqXHR, exception) {
    if (jqXHR.status === 0) {
        return ('error code: ' + jqXHR.status + '<br>Not connected.<br>Please verify your network connection.');
    } else if (jqXHR.status == 404) {
        return ('error code: ' + jqXHR.status + '<br>The requested page not found.');
    } else if (jqXHR.status == 500) {
        return ('error code: ' + jqXHR.status + '<br>Internal Server Error.');
    } else if (exception === 'parsererror') {
        return ('error code: ' + jqXHR.status + '<br>Requested JSON parse failed.');
    } else if (exception === 'timeout') {
        return ('error code: ' + jqXHR.status + '<br>Time out error.');
    } else if (exception === 'abort') {
        return ('error code: ' + jqXHR.status + '<br>Ajax request aborted.');
    } else {
        return ('error code: Uncaught Error<br>' + jqXHR.responseText);
    }
}

function _arrayBufferToBase64(buffer) {
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}

function LogOut() {
    setCookie('UserName', null);
    setCookie('UserID', null);
    setCookie('Token', null);
    window.location.replace("Index.html");
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(cname, cvalue) {
    var d = new Date();
    d.setTime(d.getTime() + (365 * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}


function PleaseWaitStatus(flag, ModalName) {
    var Img;
    var Button;
    ModalName = ModalName.toLowerCase();
    switch (ModalName) {
        case "changepassmodal":
            Img = $("#ChangePassModal_WaitImg");
            Button = $("#ChangePassModal_btnSave");

            document.getElementById('ChangePassModal_CurrentPass').disabled = flag;
            document.getElementById('ChangePassModal_NewPass').disabled = flag;
            document.getElementById('ChangePassModal_ConfirmPass').disabled = flag;

            break;
        case "rolemodal":
            Img = $("#RoleModal_WaitImg");
            Button = $("#RoleModal_btnSave");

            document.getElementById('RoleModal_Description').disabled = flag && false;

            break;
        case "userdatamodal":
            Img = $("#UserDataModal_WaitImg");
            Button = $("#UDM_btnSave");
            document.getElementById('UDM_UP_FName').disabled = flag;
            document.getElementById('UDM_UP_LName').disabled = flag;
            document.getElementById('UDM_UP_Email').disabled = flag;
            document.getElementById('UDM_UP_Address').disabled = flag;
            document.getElementById('UDM_UP_Phone').disabled = flag;

            var Vflag = document.getElementById("UDM_V_Enable").checked;
            document.getElementById('UDM_V_Enable').disabled = flag + !Vflag;
            document.getElementById('UDM_V_Rfc').disabled = flag + !Vflag;
            document.getElementById('UDM_V_Temp').disabled = flag + !Vflag;
            document.getElementById('UDM_V_Active').disabled = flag + !Vflag;

            var Ucflag = document.getElementById("UDM_Uc_Enable").checked;
            document.getElementById('UDM_Uc_Enable').disabled = flag + !Ucflag;
            document.getElementById('UDM_UC_UserName').disabled = flag + !Ucflag;
            document.getElementById('UDM_UC_Active').disabled = flag + !Ucflag;
            document.getElementById('UDM_UC_DDRole').disabled = flag + !Ucflag;
            document.getElementById('UDM_btnCASImg').disabled = flag + !Ucflag;

            break;
        default:
            return;
    }
    if (flag) {
        Img.css("visibility", "visible");
        Button.css("visibility", "hidden");
    } else {
        Img.css("visibility", "hidden");
        Button.css("visibility", "visible");
    }


}



