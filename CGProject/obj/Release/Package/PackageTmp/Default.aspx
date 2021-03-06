﻿<%@ Page Language="C#" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CGProject.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>REGISTRATION - WEB PROJECT</title>

    <!-- Favicon -->
    <link rel="icon" href="Source/Resource/logo.png" />

    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Monoton|Roboto+Slab:400,700|Material+Icons" />
    <link href="Source/Styles/style.css" rel="stylesheet" />
</head>
<body>
    <div class="main-content">
        <form id="Register" runat="server">
            <div class="top-silicon" style="background-color: #fff; width: 100%; margin-top: -15px; box-shadow: 0px 1px 21px -7px rgba(0,0,0,1);">
                <nav class="navbar navbar-transparent navbar-color-on-scroll navbar-expand-lg" style="background-color: #363491;">
                    <div class="container" style="background-color: #fff; padding-top: -15px;">
                        <div>
                            <div style="padding: 15px;">
                                <a style="font-family: Monoton; color: #1163ad; font-size: 30px;">ROOK&nbsp;&nbsp;&nbsp;&nbsp;LABS</a>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="Infobtnn" CausesValidation="false" class="infobtn" runat="server" OnClick="ViewInfo" Text="Info." />
                        </div>
                    </div>
                </nav>
            </div>
            <asp:ScriptManager ID="UpdateScript" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="MainPanel" runat="server">
                <asp:Panel ID="FortificationController" runat="server">
                    <div class="container-fluid">
                        <div style="position: center; text-align: center; width: 100%;">
                        </div>
                        <div id="MainRow" class="row">
                            <div class="col-lg-4 col-md-6">
                                <div class="card card-profile">
                                    <div class="card-header card-header-primary text-center">
                                        <h4 class="card-title">New  Registration</h4>
                                    </div>
                                    <div class="card-body" style="min-height: 500px;">
                                        <asp:UpdatePanel ID="UserInterface" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <br />

                                                <!-- Student1 -->
                                                <asp:Panel ID="UserDetails" runat="server">
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="UsnValidator1"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="*Invalid USN"
                                                            ControlToValidate="StudentUsn1"
                                                            ValidationExpression="^1+[bByY]{2}\d{2}[A-aZ-z]{2}[0-9]{3}$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator CssClass="validation-class-text" ControlToValidate="StudentUsn1" ID="UsnRequired" runat="server" ErrorMessage="*Required Field">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend" style="text-transform: uppercase">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">assignment</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="StudentUsn1" class="form-control" placeholder="First Student USN..." data-toggle="tooltip" data-placement="top" title="University Seat Number" data-container="body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator1"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="Invalid Name"
                                                            ControlToValidate="StudentName1"
                                                            ValidationExpression="^[aA-zZ ]+$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator CssClass="validation-class-text" ControlToValidate="StudentName1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required Field">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">face</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="StudentName1" class="form-control" placeholder="First Student Name..." data-toggle="tooltip" data-placement="top" title="Phone Number" data-container="body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <!-- Student2 -->
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="UsnValidator2"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="*Invalid USN"
                                                            ControlToValidate="StudentUsn2"
                                                            ValidationExpression="^1+[bByY]{2}\d{2}[A-aZ-z]{2}[0-9]{3}$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <br />
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend" style="text-transform: uppercase">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">assignment</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="StudentUsn2" class="form-control" placeholder="Second Student USN..." data-toggle="tooltip" data-placement="top" title="University Seat Number" data-container="body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator4"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="**Invalid Name"
                                                            ControlToValidate="StudentName2"
                                                            ValidationExpression="^[aA-zZ ]+$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <br />
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">face</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="StudentName2" class="form-control" placeholder="Second Student Name..." data-toggle="tooltip" data-placement="top" title="Phone Number" data-container="body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <!-- Student3 -->
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="UsnValidator3"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="*Invalid USN"
                                                            ControlToValidate="StudentUsn3"
                                                            ValidationExpression="^1+[bByY]{2}\d{2}[A-aZ-z]{2}[0-9]{3}$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <br />
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend" style="text-transform: uppercase">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">assignment</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="StudentUsn3" class="form-control" placeholder="third Student USN..." data-toggle="tooltip" data-placement="top" title="University Seat Number" data-container="body" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator6"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="**Invalid Name"
                                                            ControlToValidate="StudentName3"
                                                            ValidationExpression="^[aA-zZ ]+$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <br />
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">face</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="StudentName3" class="form-control" placeholder="third Student Name..." data-toggle="tooltip" data-placement="top" title="Phone Number" data-container="body" runat="server"></asp:TextBox>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="UserAuthentication" runat="server">
                                                    <div class="otp-section">
                                                        <a>Enter the OTP sent to: </a>
                                                        <asp:Label CssClass="otp-label" ID="EmailLabel" runat="server" Text="prashanth8983@gmail.com"></asp:Label>
                                                    </div>
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="EmailOTPValid"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="*Invalid OTP"
                                                            ControlToValidate="EmailOTP"
                                                            ValidationExpression="^[0-9]{6}$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator CssClass="validation-class-text" ControlToValidate="EmailOTP" ID="EmailOTPRequired" runat="server" ErrorMessage="*Required Field">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="material-icons">vpn_lock</i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="EmailOTP" runat="server" class="form-control" placeholder="Email OTP..."></asp:TextBox>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="UserSelection" runat="server">
                                                    <br />
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator7"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="*Invalid Prefix"
                                                            ControlToValidate="Prefix"
                                                            ValidationExpression="^[aA-zZ ]+$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">
                                                                    <i class="material-icons">title</i>
                                                                </span>
                                                            </div>
                                                            <asp:DropDownList class="form-control" ID="Prefix" runat="server">
                                                                <asp:ListItem Text="Select Prefix(if any)..." Value="" />
                                                                <asp:ListItem Text="Online" Value="Online" />
                                                                <asp:ListItem Text="Digital" Value="Digital" />
                                                                <asp:ListItem Text="Smart" Value="Smart" />
                                                                <asp:ListItem Text="Secured" Value="Secured" />
                                                                <asp:ListItem Text="Social" Value="Social" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <!-- TITLE -->
                                                    <div style="padding: 20px; color: #ff0000;">
                                                        <a>&nbsp Enter only the title:</a><br />
                                                        <a>➊&nbsp Don't include any prefix or suffix, like virutal,simulation etc.</a><br />
                                                        <a>➋&nbsp Don't include any special character.</a>
                                                    </div>
                                                    <div class="validation-container">
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator5"
                                                            CssClass="validation-class-text" runat="server"
                                                            ErrorMessage="*Invalid Title"
                                                            ControlToValidate="ProjectTitle"
                                                            ValidationExpression="^[aA-zZ0-9 ]+$"
                                                            Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator CssClass="validation-class-text" ControlToValidate="ProjectTitle" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required Field">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-group">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">
                                                                    <i class="material-icons">title</i>
                                                                </span>
                                                            </div>
                                                            <asp:TextBox ID="ProjectTitle" runat="server" class="form-control" placeholder="Project title..."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="input-group">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">
                                                                    <i class="material-icons">text_fields</i>
                                                                </span>
                                                            </div>
                                                            <asp:DropDownList class="form-control" ID="Suffix" runat="server">
                                                                <asp:ListItem Text="Select Suffix(if any)..." Value="" />
                                                                <asp:ListItem Text="Portal" Value="Portal" />
                                                                <asp:ListItem Text="System" Value="System" />
                                                                <asp:ListItem Text="Analyzer" Value="System" />
                                                                <asp:ListItem Text="Database" Value="Database" />
                                                                <asp:ListItem Text="Game" Value="Game" />
                                                                <asp:ListItem Text="WebSite" Value="WebSite" />
                                                                <asp:ListItem Text="Reservation System/Portal" Value="Reservation System/Portal" />
                                                                <asp:ListItem Text="Management System/Portal" Value="Management System/Portal" />
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                    <br />
                                                </asp:Panel>
                                                <div class="button-div">
                                                    <br />
                                                    <div class="footer text-center">
                                                        <asp:Button ID="BackButton" CssClass="btn" CausesValidation="false" runat="server" Text="BACK" OnClick="BackButton_Click" />
                                                        <asp:Button ID="SubmitButton" runat="server" CssClass="btn btn-primary" Text="NEXT" OnClick="SubmitButton_Click" />
                                                    </div>
                                                    <br />
                                                </div>
                                                <asp:Panel ID="SucessPanel" runat="server">
                                                    <div class="update-progress">
                                                        <div class="modal-load">
                                                            <div class="modal-content" style="margin-top: 80px;">
                                                                <div class="modal-body">
                                                                    <div style="width: 80px; position: center; margin-left: auto; margin-right: auto;">
                                                                        <img src="Source/Resource/tick.png" height="80" width="80" />
                                                                    </div>

                                                                    <div style="text-align: center; padding-top: 20px;">
                                                                        <a style="padding-top: 60px; font-family: Calibri; font-size: 30px; font-weight: 600;">Success!</a>
                                                                    </div>
                                                                    <br />
                                                                    <p style="text-align: center; font-family: Verdana, Roboto; padding-left: 8px; font-size: 15px; font-weight: 400">
                                                                        You registration is complete.<br />
                                                                        You can verify your details from the information page.
                                                                    </p>
                                                                </div>

                                                                <div class="footer" style="position: center; margin-left: auto; margin-right: auto;">
                                                                    <asp:Button CausesValidation="false" Font-Size="Small" ID="SucessBtn" class="btn btn-rose" runat="server" Text="Awesome!" OnClick="SucessBtn_Click" />
                                                                </div>
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="MessagePanel" runat="server">
                                                    <div class="update-progress">
                                                        <div id="myModal1" class="modal-load">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" style="font-weight: 600; font-size: 20px;">
                                                                        <asp:Label ID="MessageHeader" runat="server" Text="Label"></asp:Label>
                                                                    </h5>
                                                                </div>
                                                                <div class="modal-body">
                                                                    <p style="text-align: center;">
                                                                        <asp:Label ID="MessageLabel" runat="server" Text="Label"></asp:Label>
                                                                    </p>
                                                                </div>
                                                                <div style="position: center; margin-left: auto; margin-right: auto;">
                                                                    <asp:Button CausesValidation="false" ID="_messagebutton" class="btn btn-info" runat="server" Text="OK" OnClick="_messagebutton_Click" />
                                                                </div>
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="ConfirmPanel" runat="server">
                                                    <div class="update-progress">
                                                        <div id="myModal12" class="modal-load">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" style="font-weight: 600; font-size: 20px;">Confirm Title!!
                                                                    </h5>
                                                                </div>
                                                                <div class="modal-body">
                                                                    <p style="text-align: center;">
                                                                        Your title is&nbsp&nbsp'
                                                                       <b>
                                                                           <asp:Label ID="ConfirmTitle" runat="server" Text="Label"></asp:Label>
                                                                       </b>'
                                                                    </p>
                                                                </div>
                                                                <div style="position: center; margin-left: auto; margin-right: auto;">
                                                                    <asp:Button CausesValidation="false" ID="ConfirmCancel" class="btn btn-default" runat="server" Text="Cancel" OnClick="_ConfirmCancel_Click" />
                                                                    <asp:Button CausesValidation="false" ID="ConfirmOK" class="btn btn-warning" runat="server" Text="Confirm" OnClick="_ConfirmOK_Click" />
                                                                </div>
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="SubmitButton" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UserInterface">
                                            <ProgressTemplate>
                                                <div class="update-progress">
                                                    <div id="myModal1" class="modal-load">
                                                        <div class="modal-load-content">
                                                        </div>
                                                    </div>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <asp:UpdatePanel ID="StatusTable" runat="server">
                                    <ContentTemplate>
                                        <div class="card">
                                            <div class="table-container" style="max-height: 350px;">
                                                <!-- Withheld List -->
                                                <asp:GridView ID="GridFinal" CssClass="customers" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:TemplateField HeaderText="Project Title">
                                                            <ItemTemplate>
                                                                <%# Eval("Prefix") + " " + Eval("Title") + " " + Eval("Suffix")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="usn" HeaderText="USN's" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <a style="font-weight: 600; margin-bottom: -15px;">Witheld/Flagged List</a>
                                        <!-- Final List -->
                                        <div class="card">
                                            <div class="table-container" style="max-height: 150px;">
                                                <asp:GridView ID="GridWithHeld" CssClass="customers" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridWithHeld_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="usn" HeaderText="USN's" />
                                                        <asp:TemplateField HeaderText="Project Title">
                                                            <ItemTemplate>
                                                                <%# Eval("Prefix") + " " + Eval("Title") + " " + Eval("Suffix")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Remark" HeaderText="Remarks" />
                                                        <asp:ButtonField HeaderText="#" ControlStyle-ForeColor="#363491" ControlStyle-CssClass="info-view" Text="Delete" CommandName="Select" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <asp:Timer ID="loopBack" runat="server" OnTick="grid_load" Interval="5000" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </form>
    </div>
    <div class="waves">
        <svg width="100%" height="200px" fill="none">
            <path
                fill="#00abfa"
                d="
          M0 67
          C 273,183
            822,-40
            1920.00,106 

          V 359 
          H 0 
          V 67
          Z">
                <animate
                    repeatCount="indefinite"
                    attributeName="d"
                    dur="15s"
                    values="
            M0 77 
            C 473,283
              822,-40
              1920,116 

            V 359 
            H 0 
            V 67 
            Z; 

            M0 77 
            C 473,-40
              1222,283
              1920,136 

            V 359 
            H 0 
            V 67 
            Z; 

            M0 77 
            C 973,260
              1722,-53
              1920,120 

            V 359 
            H 0 
            V 67 
            Z; 

            M0 77 
            C 473,283
              822,-40
              1920,116 

            V 359 
            H 0 
            V 67 
            Z
            ">
                </animate>
            </path>
        </svg>
    </div>
    <div class="footer-new">
        <p class="pull-left">
            <a style="font-family: 'Monoton'; font-size: 30px; font-weight: 400; color: #fff;" href="https://www.rooklabs.net" target="_blank">ROOK&nbsp;&nbsp;LABS</a>
            <br />
            <a>ಬೆಂಗಳೂರು-64</a>
        </p>
    </div>
    <script src="Source/Scripts/bootstrap-material-design.min.js"></script>
    <script src="Source/Scripts/jquery.min.js"></script>
    <script src="Source/Scripts/material-kit.min.js"></script>
</body>
</html>

