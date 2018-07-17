<%@ Page Title="" Language="C#" MasterPageFile="~/OpenDoor.Master" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="WebSite.log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="Css/style.css" rel="stylesheet" />--%>
		<script src="Js/jquery-3.2.1.min.js"></script>
	<script src="Js/JS.js"></script>
	<script src="Js/LogJS.js"></script>


	<div id="LogTableDiv" runat="server">

		<asp:GridView ID="GridViewLog" runat="server" OnSelectedIndexChanged="GridViewLog_SelectedIndexChanged">
		</asp:GridView>
		<button id="btnTestt">btnTestt</button>
        <asp:Button ID="Button1" runat="server" Text="temp" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
       
        <table style="border:solid 1px black;">
<tr >
<td colspan=2 >row1.12
</td>
<TD rowspan=2 width=100>
    r12.3</TD>
</tr>
<TR >
<TD >r2.1
</TD>
<TD >r2.2
</TD>
</TR>
</table>


        <br />
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
        <br />
		<br />
		<div id="ResDiv"></div>
	</div>






    <div class="panel panel-primary" style="width:100%">
    <div class="panel-heading">
        <span style="font-size: 30px; font-style:oblique"><span style="font-size:larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-star"></span>Starring</span></span>
    </div>

    <div class="row">
        <div class="col-xs-12">

            <button type="button" style="margin:3px; width:32.8%" class="btn btn-success col-lg-3 col-xs-3" onclick="location.href='@Url.Action("Create", "Movie")';return false;"><span style="font-size:larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-plus"></span>Add New Movie</span></button>
            <button type="button" style="margin: 3px; width: 32.8%" class=" btn btn-success col-lg-3 col-xs-3"  onclick=" location.href='@Url.Action("Create", "Employee")' ;return false;"><span style="font-size:larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-plus"></span>Add New Employee</span></button>
            <button type="button" style="margin: 3px; width: 32.8%" class="btn btn-success col-lg-3 col-xs-3"  onclick=" location.href='@Url.Action("Create", "Show")' ;return false;"><span style="font-size:larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-plus"></span>Add New Showing</span></button>

        </div>
    </div>

       <table class="table table-striped table-hover table-responsive table-condensed">
        <tr>
            <th>
                <h3 style="font-size:x-large"><span style="font-weight:bolder">Movie Name</span></h3>
            </th>
            <th>
                <h3 style="font-size:x-large"><span style="font-weight:bolder">Release Date</span></h3>
            </th>
            <th>
                <h3 style="font-size:x-large"><span style="font-weight:bolder">Actor</span></h3>
            </th>
            <th>
                <h3 style="font-size:x-large"><span style="font-weight:bolder">@Html.DisplayNameFor(model => model.Role)</span></h3>
            </th>
            <th></th>
        </tr>
        @foreach (var item in Model)
        {
            <tr>
                <td class="col-lg-2">
                    <span style="font-size: 17px;">@Html.DisplayFor(modelItem => item.movieName)</span>
                </td>
                <td class="col-lg-2">
                    <span style="font-size: 17px;">@Html.DisplayFor(modelItem => item.movieReleaseDate)</span>
                </td>
                <td class="col-lg-1">
                    <span style="font-size: 17px;">@Html.DisplayFor(modelItem => item.employeeName)</span>
                </td>
                <td class="col-lg-1">
                    <span style="font-size: 17px;">@Html.DisplayFor(modelItem => item.Role)</span>
                </td>
                <td class="col-lg-3">
                    <button type="button" class="btn btn-warning col-lg-3" onclick="location.href='@Url.Action("Edit", "Movie", new { id = item.movieID })';return false;"><span style="margin-right: 5px" class="glyphicon glyphicon-pencil"></span>Edit</button>

                    <button type="button" class="btn btn-info col-lg-3 col-lg-offset-1" onclick="location.href='@Url.Action("Details", "Movie", new { id = item.movieID })';return false;"><span style="margin-right: 5px" class="glyphicon glyphicon-align-justify"></span>Details</button>

                    <button type="button" class="btn btn-danger col-lg-3 col-lg-offset-1" onclick="location.href='@Url.Action("Delete", "Movie", new { id = item.movieID })' ;return false;"><span style="margin-right: 5px" class="glyphicon glyphicon-trash"></span>Delete</button>
                </td>
            </tr>
        }

    </table>


</div>
</asp:Content>
