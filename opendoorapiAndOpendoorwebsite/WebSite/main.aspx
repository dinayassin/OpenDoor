<%@ Page Title="" Language="C#" MasterPageFile="~/OpenDoor.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="WebSite.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<header><title>Main</title></header>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
	<link href="Css/Main.css" rel="stylesheet" />

	<link href='http://fonts.googleapis.com/css?family=Roboto+Condensed|Open+Sans+Condensed:300' rel='stylesheet' type='text/css'>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script src="Js/JS.js"></script>
	<script src="Js/Main.js"></script>
	<br />
	<br />
   
    <div class="panel panel-primary" style="width: 100%">
		<div class="panel-heading">
			<div style="font-size: 30px; font-style: oblique; width: 50%;">
				<span style="font-size: larger;">
					<span style="margin-right: 5px" class="glyphicon glyphicon glyphicon-duplicate"></span>
					<span id="TableTitleDiv" runat="server"></span>

				</span>

			</div>
		</div>
		<div class="row">
			<div class="col-xs-12" id="menuDiv" runat="server">
				<center>
                <button type="button" style="margin: 3px; width: 32.8%" class="btn btn-success col-lg-3 col-xs-3" onclick="ShowLogData()"><span style="font-size: larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-list-alt"></span>Logs History</span></button>
                <button type="button" style="margin: 3px; width: 32.8%" class=" btn btn-success col-lg-3 col-xs-3" onclick="ShowUsersData()"><span style="font-size: larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-user"></span>Users</span></button>
                <button type="button" style="margin: 3px; width: 32.8%" class=" btn btn-success col-lg-3 col-xs-3" onclick="ShowRoleData()"><span style="font-size: larger;"><span style="margin-right: 5px" class="glyphicon glyphicon-tasks"></span>Roles</span></button>
				</center>
			</div>
		</div>

		<div id="LogTableDiv" runat="server"></div>
		<div id="UsersTableDiv" runat="server"></div>
		<div id="RolesTableDiv" runat="server"></div>
	</div>



	<div id="LogImgViewModal" class="modalDialog">
		<div id="LogImgViewModalPanel">
			<a href="#close" title="Close" class="close">X</a>
			<div id="LogImgViewModal_Title">Title</div>
			<div id="LogImgViewModal_Content">Content</div>
			<img id="ImgPreview" src="" />
		</div>
	</div>

	<div id="RoleModal" class="modalDialog">
		<div id="RoleModalPanel">
			<a href="#close" title="Close" class="close">X</a>
			<div id="RoleModal_Title">Title</div>
			<div id="RoleModal_Content"></div>
			<input type="text" id="RoleModal_Description" /><br />
			<center>
            <button type='button' class='btn btn-info' id='RoleModal_btnSave'>Save</button>
                <img id="RoleModal_WaitImg" src="img/pleaseWait.gif"/>
                <br />                
            </center>
		</div>
	</div>
   
	<div id="UserDataModal" class="modalDialog">
		<div id="UDMPanel">
			<a href="#close" title="Close" class="close">X</a>

			<div id="UDMTitle">Title</div>
			<div id="UDMContent">



				<table id="UDM_MasterTable" runat="server">
					<tr>
						<td class="UDM_MasterCol" colspan="3">
							<div id="UDM_UP">
								<div class="UDM_Titles">User Profile</div>
								<br />
								<table id="UDM_UPTable" runat="server">
									<tr>
										<td>FName:</td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_UP_FName">
										</td>
									</tr>
									<tr>
										<td>LName:</td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_UP_LName">
										</td>
									</tr>
									<tr>
										<td>Email:</td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_UP_Email">
										</td>
									</tr>
									<tr>
										<td>Phone:</td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_UP_Phone">
										</td>
									</tr>
									<tr>
										<td>Address:</td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_UP_Address">
										</td>
									</tr>
								</table>
							</div>
						</td>
						<td rowspan="2">
							<div id="UDM_ImgProfileDiv">
								<center>
                                <img id="UDM_ImgProfile"  />
                                    <br /><br />
                                     <input type="file" id="UDM_PhotoFile" name="UDM_PhotoFile"  required/>
                                     <button type='button' class='btn btn-info' id='UDM_btnCASImg'>Change Image Profile</button>
                               </center>
							</div>
							<div id="UDM_message"></div>
						</td>
					</tr>
					<tr>
						<td class="UDM_MasterCol">
							<div id="UDM_V">
								<div class="UDM_Titles">
									<input type="checkbox" id="UDM_V_Enable" checked="checked" onchange="UDM_V_EnableChange()">
									Visitor
								</div>
								<br />
								<table id="UDM_VTable" runat="server">
									<tr>
										<td>RFC Card:</td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_V_Rfc">
										</td>
									</tr>

									<tr>
										<td>Temp:</td>
										<td>
											<input type="checkbox" id="UDM_V_Temp">
										</td>
									</tr>
									<tr>
										<td>Active:</td>
										<td>
											<input type="checkbox" id="UDM_V_Active">
										</td>
									</tr>
								</table>
							</div>
						</td>
						<td class="UDM_tableColSpace"></td>
						<td class="UDM_MasterCol">
							<div id="UDM_UC">
								<div class="UDM_Titles">
									<input type="checkbox" id="UDM_Uc_Enable" checked="checked" onchange="UDM_Uc_EnableChange()">
									User Credntials
								</div>
								<br />
								<table id="UDM_UCTable" runat="server">
									<tr>
										<td>UserName: </td>
										<td>
											<input type="text" class="UDM_TextBox" id="UDM_UC_UserName">
										</td>
									</tr>
									<tr>
										<td>Active: </td>
										<td>
											<input type="checkbox" id="UDM_UC_Active">
										</td>
									</tr>
									<tr>
										<td>Role: </td>
										<td>
											<select id="UDM_UC_DDRole">
												<option id="0"></option>
											</select>
										</td>
									</tr>
								</table>
							</div>
						</td>
					</tr>



				</table>
				<div style="text-align: center; padding: 5px;">
					<button type='button' class='btn btn-info' id='UDM_btnSave'>Save</button>
                    <img id="UserDataModal_WaitImg" src="img/pleaseWait.gif"/>



				</div>
			</div>
		</div>
	</div>

</asp:Content>

