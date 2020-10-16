<%@ Page Language="C#" AutoEventWireup="true" UnobtrusiveValidationMode="None" CodeBehind="ConfirmDelete.aspx.cs" Inherits="CGProject.ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTRATION - CG PROJECT</title>
    <link rel="icon" href="Source/Resource/logo.png" />
    <!-- Favicon -->
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Monoton|Roboto+Slab:400,700|Material+Icons" />
    <link href="Source/Styles/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="DeletePanel" runat="server">
                    <div class="update-progress">
                        <div id="myModal123" class="modal-load">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" style="font-weight: 600; font-size: 20px;">Confirm Deletion!
                                    </h5>
                                </div>
                                <div class="modal-body">
                                    <a>Enter OTP sent to&nbsp</a>
                                    <b>
                                        <asp:Label ID="DeleteEmail" runat="server" Text="mail@example.com"></asp:Label></b>
                                    <br />
                                    <div style="color: #ff0000; padding-left: 20px;">
                                        <asp:Label ID="DeleteOTPLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:RegularExpressionValidator
                                        ID="EmailOTPValid"
                                        CssClass="validation-class-text" runat="server"
                                        ErrorMessage="*Invalid OTP"
                                        ControlToValidate="DeleteOTP"
                                        ValidationExpression="^[0-9]{6}$"
                                        Display="Dynamic">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator CssClass="validation-class-text" ControlToValidate="DeleteOTP" ID="EmailOTPRequired" runat="server" ErrorMessage="*Required Field">
                                    </asp:RequiredFieldValidator>
                                    <div class="input-group has-danger">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text ">
                                                <i class="material-icons">lock</i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="DeleteOTP" runat="server" class="form-control" placeholder="Enter OTP..."></asp:TextBox>
                                    </div>
                                </div>
                                <div style="position: center; margin-left: auto; margin-right: auto;">
                                    <asp:Button CausesValidation="false" ID="DeleteCancel" class="btn btn-default" runat="server" Text="Cancel" OnClick="DeleteCancel_Click" />
                                    <asp:Button ID="DeleteConfirm" class="btn btn-danger" runat="server" Text="Delete Response" OnClick="DeleteResponse_Click" />
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
                                    <p>
                                        <asp:Label ID="MessageLabel" runat="server" Text="Label"></asp:Label>
                                    </p>
                                </div>
                                <asp:Button ID="_messagebutton" CausesValidation="false" class="btn-message" runat="server" Text="OK" OnClick="messagebutton_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
<script src="Source/Scripts/bootstrap-material-design.min.js"></script>
<script src="Source/Scripts/jquery.min.js"></script>
<script src="Source/Scripts/material-kit.min.js"></script>
<script src="Source/Scripts/popper.min.js"></script>
</html>
