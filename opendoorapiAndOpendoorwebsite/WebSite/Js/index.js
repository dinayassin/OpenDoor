
function LblInfoText(txt) {
	$('#infoDiv').html(txt);
	if (txt == "") {
		$('#infoDiv').hide();
	} else {
		$('#infoDiv').show();
	}
}

function LblFPInfoText(txt) {
	$('#FPinfoDiv').html(txt);
	if (txt == "") {
		$('#FPinfoDiv').hide();
	} else {
		$('#FPinfoDiv').show();
	}
}

function ForgotPasswordShow(flag) {
	if (flag) {
		$('#LoginFormDiv').hide();
		$('#ForgotPasswordForm').show();
	}
	else {
		$('#ForgotPasswordForm').hide();
		$('#LoginFormDiv').show();
	}
}
$(document).ready(function () {

	wait(false);
	LblInfoText("");
	LblFPInfoText("");
	ForgotPasswordShow(false);

	$('#TxtUsername').keyup(function () {
		LblInfoText("");
	});

	$('#TxtPassword').keyup(function () {
		LblInfoText("");
	});

	$('#TxtFPUsername').keyup(function () {
		LblFPInfoText("");
	});

	$('#btnTest').click(function () {
		LblInfoText("success.");
	});

	$('#txtForgotPassword').click(function () {
		ForgotPasswordShow(true);
	});

	$('#btnFPCancel').click(function () {
		ForgotPasswordShow(false);
	});


});

function wait(flag) {
	if (flag) {
		$('#LoginFormDiv').hide();
		$('#LoadingDiv').show();
	}
	else {
		$('#LoginFormDiv').show();
		$('#LoadingDiv').hide();
	}

}


function waitFP(flag) {
	if (flag) {
		$('#ForgotPasswordDiv').hide();
		$('#LoadingDiv').show();
	}
	else {
		$('#ForgotPasswordDiv').show();
		$('#LoadingDiv').hide();
	}

}

function validateFormOnSubmit(theForm) {
	wait(true);
	var User = $('#TxtUsername').val();
	var Pass = $('#TxtPassword').val();
	var loginData = {
		"UserName": User,
		"Password": Pass
	}; //loginData
	$.ajax({
		url: APIUrl + "UserCredntials/WebsiteLogin",
		type: "POST",
		data: JSON.stringify(loginData),
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		error: LoginError,
		failure: function (response) {
			alert(response.d);
		},
		//async: false,
		success: function (response) {
			var res = JSON.parse(response);
			if (res.Result) {
				setCookie('UserName', User);
				setCookie('UserID', res.UserID);
				setCookie('Token', res.Token);
				LblInfoText("<a class='SuccessLogin'>success.</a>");
				window.location.replace("main.aspx");
			}
			else {
				LblInfoText("<a class='FaildLogin'>invalid username or password.</a>");
				wait(false);
				setCookie('UserName', null);
				setCookie('UserID', null);
				setCookie('Token', null);
			}

		}
	});
	return false;
}
function LoginError(jqXHR, exception) {
	var errorStr = formatErrorMessage(jqXHR, exception);
	LblInfoText("<center><a class='ServerErrorTitle'>Server error</a></center><a class='ServerErrorContent'>" + errorStr + "</a>");
	wait(false);
}



//ForgotPassword
function ForgotPassword(theForm) {
	waitFP(true);
	var Prm = $('#TxtFPUsername').val();

	$.ajax({
		url: APIUrl + "UserCredntials/ForgotPassword",
		type: "POST",
		data: JSON.stringify(Prm),
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		error: ForgotPasswordError,
		failure: function (response) {
			alert(response.d);
		},
		//async: false,
		success: ForgotPasswordRes
	});
	return false;
}
function ForgotPasswordError(jqXHR, exception) {
	var errorStr = formatErrorMessage(jqXHR, exception);
	LblFPInfoText("<center><a class='ServerErrorTitle'>Server error</a></center><a class='ServerErrorContent'>" + errorStr + "</a>");
	waitFP(false);
}
function ForgotPasswordRes(response) {
	var res = JSON.parse(response);
	if (res) {
		LblFPInfoText("<a class='SuccessForgotPasswordRes'>Please check your inbox.</a>");
	}
	else {
		LblFPInfoText("<a class='FaildForgotPasswordRes'>invalid username.</a>");
	}
	waitFP(false);
}