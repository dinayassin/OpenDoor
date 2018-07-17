//https://www.formget.com/ajax-image-upload-php/
//
var UserIDTemp = 0;
var UDM_message_Html = "";
var UDM_CompliteFlag = false;
//get functions

function GetUserProfile(UserID) {
    var Data = null;
    $.ajax({
        url: APIUrl + "UserProfile/UserProfileData",
        type: "Post",
        data: JSON.stringify(UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Data = JSON.parse(response);
        }
    });
    return Data;
}
function GetUserCredntials(UserID) {
    var Data = null;
    $.ajax({
        url: APIUrl + "UserCredntials/UserCredntialsByID",
        type: "Post",
        data: JSON.stringify(UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Data = JSON.parse(response);
        }
    });
    return Data;
}
function GetVisitor(UserID) {
    var Data = null;
    $.ajax({
        url: APIUrl + "Visitor/VisitorById",
        type: "Post",
        data: JSON.stringify(UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Data = JSON.parse(response);
        }
    });
    return Data;
}



//Create Or Edit Functions
function CreateOrEditUserProfile(Data) {
    var Res = null;
    $.ajax({
        url: APIUrl + "UserProfile/CreateEdit",
        type: "Post",
        data: JSON.stringify(Data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Res = JSON.parse(response);
        }
    });
    return Res;
}
function CreateOrEditUserCredntials(Data) {
    var Res = null;
    $.ajax({
        url: APIUrl + "UserCredntials/CreateEdit",
        type: "Post",
        data: JSON.stringify(Data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        //async: false,
        success: function (response) {
            Res = JSON.parse(response);
            UDM_Complite();
            UDM_CompliteFlag = true;
        }
    });
    return Res;
}
function CreateOrEditVisitor(Data) {
    var Res = null;
    $.ajax({
        url: APIUrl + "Visitor/CreateEdit",
        type: "Post",
        data: JSON.stringify(Data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        //async: false,
        success: function (response) {
            Res = JSON.parse(response);
            UDM_Complite();
            UDM_CompliteFlag = true;
        }
    });
    return Res;
}


//Delete Functions
function DeleteUserProfile(UserID) {
    $.ajax({
        url: APIUrl + "UserProfile/UserProfileDelete",
        type: "Post",
        data: JSON.stringify(UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
        }
    });
}
function DeleteUserCredntials(UserID) {
    $.ajax({
        url: APIUrl + "UserCredntials/UserCredntialsDelete",
        type: "Post",
        data: JSON.stringify(UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        //async: false,
        success: function (response) {
            UDM_Complite();
            UDM_CompliteFlag = true;
        }
    });
}
function DeleteVisitor(UserID) {
    $.ajax({
        url: APIUrl + "Visitor/VisitorDelete",
        type: "Post",
        data: JSON.stringify(UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        //async: false,
        success: function (response) {
            UDM_Complite();
            UDM_CompliteFlag = true;
        }
    });
}



function UDM_Complite() {
    if (UDM_CompliteFlag) {
        $("#UDM_message").css('color', 'green');
        $("#UDM_message").html("Success (*_*) <br> " + UDM_message_Html);
        PleaseWaitStatus(false, "UserDataModal");
        ShowUsersData();
    }
}
function userNameExists(userName, UserID) {
    var Data = null;
    prm = {
        "UserName": userName,
        "UserID": UserID
    };
    $.ajax({
        url: APIUrl + "UserCredntials/UserNameExists",
        type: "Post",
        data: JSON.stringify(prm),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Data = JSON.parse(response);
        }
    });
    return Data;
}
function AddRoleAjax(Desc) {

    prm = {
        "Description": Desc
    };
    $.ajax({
        url: APIUrl + "Role",
        type: "Post",
        data: JSON.stringify(prm),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        //async: false,
        success: function (response) {
            PleaseWaitStatus(false, "RoleModal");
            ShowRoleData();
        }
    });

}

function RFCExists(Rfc, UserID) {
    var Data = null;
    var prm = {
        "RFCStr": Rfc,
        "UserID": UserID
    };
    $.ajax({
        url: APIUrl + "Visitor/RFCExists",
        type: "Post",
        data: JSON.stringify(prm),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Data = JSON.parse(response);
        }
    });
    return Data;
}

//End 

function validationUserData() {
    var ErrorResult = "";
    //User Profile
    if (document.getElementById('UDM_UP_FName').value == "") {
        $('#UDM_UP_FName').addClass('validationError');
        ErrorResult += "First name is empty <br>";
    }
    if (document.getElementById('UDM_UP_LName').value == "") {
        $('#UDM_UP_LName').addClass('validationError');
        ErrorResult += "Last name is empty <br>";
    }
    if (document.getElementById('UDM_UP_Email').value == "") {
        $('#UDM_UP_Email').addClass('validationError');
        ErrorResult += "Email is empty <br>";
    }

    //UserCredntials

    if (document.getElementById("UDM_Uc_Enable").checked == true) {
        var UC_UserName = document.getElementById('UDM_UC_UserName').value;
        if (UC_UserName == "") {
            $('#UDM_UC_UserName').addClass('validationError');
            ErrorResult += "User name is empty <br>";
        }
        if (userNameExists(UC_UserName, UserIDTemp)) {
            $('#UDM_UC_UserName').addClass('validationError');
            ErrorResult += "User name is Exists <br>";
        }

        var UC_DDRole = document.getElementById("UDM_UC_DDRole");
        //var RoleValue = "";
        var RoleValue = parseInt(UC_DDRole.options[UC_DDRole.selectedIndex].id);
        if (RoleValue == 0) {
            $('#UDM_UC_DDRole').addClass('validationError');
            ErrorResult += "Role is empty <br>";
        }
    }

    //visitor
    var UDM_V_Enable = document.getElementById("UDM_V_Enable").checked
    if (UDM_V_Enable == true) {
        var RFCStr = document.getElementById('UDM_V_Rfc').value;
        if (RFCStr == "") {
            $('#UDM_V_Rfc').addClass('validationError');
            ErrorResult += "RFCCard is empty <br>";
        }
        if (RFCExists(RFCStr, UserIDTemp)) {
            $('#UDM_V_Rfc').addClass('validationError');
            ErrorResult += "RFCCard is Exists <br>";
        }
        if (!document.getElementById("UDM_V_Temp").checked) {

            var ProfileImgSrc = document.getElementById("UDM_ImgProfile").src;
            ProfileImgSrc = ProfileImgSrc.replace(/^data:image\/\w+;base64,/, '').replace(document.location.origin + "/", '').replace("main.aspx?P=Users", '');
            if (ProfileImgSrc == "") {
                ErrorResult += "Profile Image Is Empty <br>";
                $('#UDM_ImgProfileDiv').addClass('validationError');
            }
        }
    }

    return ErrorResult;
}
function AddNewRole() {
    document.getElementById('RoleModal_Title').innerText = "Add New Role";
    $('#RoleModal_Content').html("Please Enter your Role Description:");
    $('#RoleModal_Description').value = "";

    RoleModalShow();
}

function AddNewUser() {
    UserIDTemp = 0;
    clearDataUserDataModal();
    document.getElementById('UDMTitle').innerText = "Add New user";
    $("#UDMContent").css("visibility", "visible");
    document.getElementById("UDM_Uc_Enable").checked = false;
    document.getElementById("UDM_V_Enable").checked = false;
    UDM_Uc_EnableChange();
    UDM_V_EnableChange();
    UserDataModalShow();

}
function UserEdit(ID) {
    clearDataUserDataModal();
    var UserProfile = GetUserProfile(ID);
    UserIDTemp = ID;
    if (UserProfile != null) {
        //UserProfile
        document.getElementById('UDM_UP_FName').value = UserProfile.Fname;
        document.getElementById('UDM_UP_LName').value = UserProfile.Lname;
        document.getElementById('UDM_UP_Email').value = UserProfile.Email;
        document.getElementById('UDM_UP_Phone').value = UserProfile.Phone;
        document.getElementById('UDM_UP_Address').value = UserProfile.Address;

        //UserCredntials
        var UserCredntials = GetUserCredntials(ID);
        if (UserCredntials != null) {
            document.getElementById("UDM_Uc_Enable").checked = true;
            document.getElementById('UDM_UC_UserName').value = UserCredntials.UserName;
            document.getElementById("UDM_UC_Active").checked = UserCredntials.IsActive;

            RoleDDSelectByID(UserCredntials.RoleID)
        }

        //Visitor
        var visitor = GetVisitor(ID);


        if (visitor != null) {
            document.getElementById("UDM_V_Enable").checked = true;
            document.getElementById('UDM_V_Rfc').value = visitor.RFCCard;
            document.getElementById("UDM_V_Temp").checked = visitor.IsTemp;
            document.getElementById("UDM_V_Active").checked = visitor.IsActive;
            if (visitor.ProfileImg != null && visitor.ProfileImg != "")
                document.getElementById("UDM_ImgProfile").src = "data:image/png;base64," + visitor.ProfileImg;
        }

        document.getElementById('UDMTitle').innerText = "Updating user (" + UserProfile.UserID + ")";
        $("#UDMContent").css("visibility", "visible");
    }
    UserDataModalShow();
    UDM_Uc_EnableChange();
    UDM_V_EnableChange();
}

function clearDataUserDataModal() {
    //UserProfile
    document.getElementById('UDM_UP_FName').value = "";
    document.getElementById('UDM_UP_LName').value = "";
    document.getElementById('UDM_UP_Email').value = "";
    document.getElementById('UDM_UP_Phone').value = "";
    document.getElementById('UDM_UP_Address').value = "";

    //UserCredntials
    document.getElementById("UDM_Uc_Enable").checked = false;
    document.getElementById('UDM_UC_UserName').value = "";
    document.getElementById("UDM_UC_Active").checked = false;
    RoleDDSelectByID(0)

    // Visitor
    document.getElementById("UDM_V_Enable").checked = false;
    document.getElementById('UDM_V_Rfc').value = "";
    document.getElementById("UDM_V_Temp").checked = false;
    document.getElementById("UDM_V_Active").checked = false;
    document.getElementById("UDM_ImgProfile").src = "";
}

function GetRoleOpt() {
    var Data = null;

    $.ajax({
        url: APIUrl + "Role/RoleList",
        type: "Post",
        //data: JSON.stringify(ID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            Data = JSON.parse(response);
            for (var i = 0; i < Data.length; i++) {
                addRoleOpt(Data[i].RoleID, Data[i].Description);
            }
        }
    });
}

function UserDelete(ID) {
    DeleteUserProfile(ID);
    window.location.replace("?P=Users");
}

function LogImgView(ID) {
    var img = null;
    $.ajax({
        url: APIUrl + "Log/LogImg",
        type: "Post",
        data: JSON.stringify(ID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response);
        },
        async: false,
        success: function (response) {
            img = JSON.parse(response);
        }
    });

    if (img != "") {
        LogImgModalShow("Image for LOG #" + ID, "<br>", img);
    } else {
        alert("Sorry!\nNo image for LOG # " + ID);
    }



}


function UDM_V_EnableChange() {
    var flag = document.getElementById("UDM_V_Enable").checked;
    document.getElementById('UDM_V_Rfc').disabled = !flag;
    document.getElementById('UDM_V_Temp').disabled = !flag;
    document.getElementById('UDM_V_Active').disabled = !flag;
    document.getElementById('UDM_btnCASImg').disabled = !flag;


}
function UDM_Uc_EnableChange() {
    var flag = document.getElementById("UDM_Uc_Enable").checked;
    document.getElementById('UDM_ImgProfile').disabled = !flag;
    document.getElementById('UDM_UC_UserName').disabled = !flag;
    document.getElementById('UDM_UC_Active').disabled = !flag;
    document.getElementById('UDM_UC_DDRole').disabled = !flag;
}

$(document).ready(function () {


    $('#UDM_UC_Enable').change(function () {

        var flag = false;
        if ($(this).is(':checked')) {
            flag = true;
        }


    });



    $('#RoleModal_btnSave').click(function () {
        PleaseWaitStatus(true, "RoleModal");
        var Desc = document.getElementById('RoleModal_Description').value;
        AddRoleAjax(Desc);
        //window.location.replace("#close");

    });
    $('#UDM_btnSave').click(function () {
        UDM_CompliteFlag = false;
        PleaseWaitStatus(true, "UserDataModal");

        $("#UDM_message").empty(); // To remove the previous error message
        $("#UDM_message").css('color', 'red');
        //remove validationError class
        $('#UDM_UP_FName').removeClass('validationError');
        $('#UDM_UP_LName').removeClass('validationError');
        $('#UDM_UP_Email').removeClass('validationError');
        $('#UDM_UC_UserName').removeClass('validationError');
        $('#UDM_UC_DDRole').removeClass('validationError');
        $('#UDM_V_Rfc').removeClass('validationError');
        $('#UDM_ImgProfileDiv').removeClass('validationError');
        //End remove validationError class
        var ErrorStr = validationUserData();

        if (ErrorStr != "") {
            $("#UDM_message").html(ErrorStr);
            PleaseWaitStatus(false, "UserDataModal");
            return;
        }

        $("#UDM_message").empty();
        UDM_message_Html = "";
        UserProfileData = {
            "UserID": UserIDTemp,
            "Fname": document.getElementById('UDM_UP_FName').value,
            "Lname": document.getElementById('UDM_UP_LName').value,
            "Email": document.getElementById('UDM_UP_Email').value,
            "Phone": document.getElementById('UDM_UP_Phone').value,
            "Address": document.getElementById('UDM_UP_Address').value

        };

        var userID = CreateOrEditUserProfile(UserProfileData);
        UDM_message_Html += "CreateOrEditUserProfile >> " + userID + "<br>";
        if (userID > 0) {

            //UserCredntials
            var UC_DDRole = document.getElementById("UDM_UC_DDRole");
            var RoleValue = parseInt(UC_DDRole.options[UC_DDRole.selectedIndex].id);


            if (document.getElementById("UDM_Uc_Enable").checked) {
                UserCredntialsData = {
                    "UserProfileId": userID,
                    "UserName": document.getElementById('UDM_UC_UserName').value,
                    "IsActive": document.getElementById("UDM_UC_Active").checked,
                    "RoleID": RoleValue
                };
                var res = CreateOrEditUserCredntials(UserCredntialsData);
                UDM_message_Html += "CreateOrEditUserCredntials >> " + res + "<br>";
            }
            else {
                var res = DeleteUserCredntials(userID);
                UDM_message_Html += "DeleteUserCredntials >> OK<br>";
            }

            // Visitor
            var ProfileImgSrc = document.getElementById("UDM_ImgProfile").src;
            ProfileImgSrc = ProfileImgSrc.replace(/^data:image\/\w+;base64,/, '').replace(document.location.origin + "/", '').replace("main.aspx?P=Users", '');

            if (document.getElementById("UDM_V_Enable").checked) {
                VisitorData = {
                    "RFCCard": document.getElementById('UDM_V_Rfc').value,
                    "UserProfileId": userID,
                    "ProfileImg": ProfileImgSrc,
                    "IsTemp": document.getElementById("UDM_V_Temp").checked,
                    "IsActive": document.getElementById("UDM_V_Active").checked

                };
                var res = CreateOrEditVisitor(VisitorData);
                UDM_message_Html += "CreateOrEditVisitor >> " + res + "<br>";

            }
            else {

                var res = DeleteVisitor(userID);
                UDM_message_Html += "DeleteVisitor >> OK<br>";
            }
        }
        else {
            PleaseWaitStatus(false, "UserDataModal");
            $("#UDM_message").html("Error !");
        }
    });
    //****************************************************************************************************
    $('#UDM_btnCASImg').click(function () {
        $('#UDM_btnCASImg').value = "Please wait ...";
        $('#UDM_PhotoFile').click();
        $('#UDM_btnCASImg').value = "Change & Save Img Profile";
    });

    // Function to preview image after validation
    $(function () {
        $("#UDM_PhotoFile").change(function () {
            $("#UDM_message").empty(); // To remove the previous error message
            var file = this.files[0];
            var imagefile = file.type;
            var match = ["image/jpeg", "image/png", "image/jpg"];
            if (!((imagefile == match[0]) || (imagefile == match[1]) || (imagefile == match[2]))) {
                //$('#previewing').attr('src', 'noimage.png');
                $("#UDM_message").html("<p id='error'>Please Select A valid Image File</p>" + "<h4>Note</h4>" + "<span id='error_message'>Only jpeg, jpg and png Images type allowed</span>");
                return false;
            }
            else {
                var reader = new FileReader();
                reader.onload = imageIsLoaded;
                reader.readAsDataURL(this.files[0]);
                //document.getElementById("ImgPreview").src = reader.result;
            }
        });
    });
    function imageIsLoaded(e) {
        $("#UDM_PhotoFile").css("color", "green");
        $('#UDM_ImgProfileDiv').css("display", "block");
        $('#UDM_ImgProfile').attr('src', e.target.result);
        $('#UDM_ImgProfile').attr('width', '250px');
        $('#UDM_ImgProfile').attr('height', '230px');
    };

    GetRoleOpt();

});


function validateExtension(v) {
    var allowedExtensions = new Array("jpg", "JPG", "jpeg", "JPEG");
    for (var ct = 0; ct < allowedExtensions.length; ct++) {
        sample = v.lastIndexOf(allowedExtensions[ct]);
        if (sample != -1) { return true; }
    }
    return false;
}
function RoleDDSelectByID(valueToSet) {
    var selectObj = document.getElementById("UDM_UC_DDRole");
    for (var i = 0; i < selectObj.options.length; i++) {
        if (selectObj.options[i].id == valueToSet) {
            selectObj.options[i].selected = true;
            return;
        }
    }
}

function addRoleOpt(id, txt) {
    var str = "<option id='" + id + "'>" + txt + "</option>"
    $("#UDM_UC_DDRole").append(str);
}

function ModalConfirm(msg, postbackurl) {
    $('#modal-msg').html(msg);
    $('#confirm-modal').modal({ backdrop: 'static', keyboard: false })
    .one('click', '#btnok', function () {
        if (postbackurl != '') {
            window.location = postbackurl;
        }
    });
}

function ModalAlert2(msg) {
    $('#modal-msg-alert').html(msg);
    $('#alert-modal').modal({ backdrop: 'static', keyboard: false })
}


function LogImgModalShow(title, msg, imgBytes) {
    $('#LogImgViewModal_Title').html(title);
    if (imgBytes != null)
        document.getElementById("ImgPreview").src = "data:image/png;base64," + imgBytes;
    else
        document.getElementById("ImgPreview").src = "";
    $('#LogImgViewModal_Content').html(msg);
    window.location.replace("#LogImgViewModal");
}

function UserDataModalShow() {
    window.location.replace("#UserDataModal");
}

function RoleModalShow() {
    window.location.replace("#RoleModal");
}

function ShowLogData() {
    window.location.replace("?P=Logs");
}

function ShowUsersData() {
    window.location.replace("?P=Users");
}

function ShowRoleData() {
    window.location.replace("?P=Roles");
}

/////////////////////////////////////////////////upload
