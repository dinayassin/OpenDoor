//Log Page
$(document).ready(function () {
	$('#btnTestt').click(function () {
		alert("hi");
		GetAllLogs();
	});

	$('.element-row').hover(
    function () {
        hideAllElementOptions();
        var row = $(this);
        var elementOptions = row.find(".element-options");
        elementOptions.css({
            opacity: 0,
            display: 'inline-block'
        }).animate({ opacity: 1 }, 0); // your parameters here
    },
  function () {
      var row = $(this);
      var elementOptions = row.find(".element-options");
      elementOptions.css({
          display: 'inline-block'
      }).animate({ opacity: 0 }, 0); // your parameters here
  }
);


});

function GetAllLogs() {
	var result = null;

	$.ajax({
		url: APIUrl + "Log",
		dataType: "json",
		type: "GET",
		//data: JSON.stringify(Parameter),
		contentType: "application/json; charset=utf-8",
		error: function (jqXHR, exception) {
			alert(formatErrorMessage(jqXHR, exception));
		},
		async: false,
		success: function (data) {
			result = JSON.parse(data);
		}
	});
	var str = "";
	if (result != null) {
		for (var i = 0; i < result.length; i++) {
			str += result[i].LogID + ", " + result[i].UserFullName + ", " + result[i].RFCCard + ", " + result[i].LoginDateTime + ", " + result[i].IsOpen + ", <br>"
		}
	}
	document.getElementById("ResDiv").innerHTML = str;


}