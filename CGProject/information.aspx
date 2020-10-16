<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="information.aspx.cs" Inherits="CGProject.information" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>REGISTRATION - CG PROJECT</title>
    <!-- Favicon -->
    <link rel="icon" href="Source/Resource/logo.png" />
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Monoton|Roboto+Slab:400,700|Material+Icons" />
    <link href="Source/Styles/style.css" rel="stylesheet" />
</head>
<body>
    <form id="InformationForm" runat="server">
        <div class="top-silicon" style="background-color: #fff; width: 100%; margin-top: -15px;">
            <nav class="navbar navbar-transparent navbar-color-on-scroll navbar-expand-lg" style="background-color: #363491;">
                <div class="container" style="background-color: #fff; padding-top: -15px;">
                    <div>
                        <div style="float: left; padding-right: 10px;">
                            <img src="Source/Resource/logo.png" height="60" />
                        </div>
                        <div style="float: right; padding-top: 10px;">
                            <a style="font-family: Arial; font-size: 30px; color: #d30000; font-weight: 600">BMS</a><br />
                            <a style="font-family: Calibri; color: #363491; font-size: 22px; font-weight: 600">INSTITUTE OF TECHNOLOGY</a>
                        </div>
                    </div>
                    <div>
                        <button id="backsilicon" class="infobtn" onclick="print()">Print</button>
                        <asp:Button ID="printsilicon" CssClass="infobtn" runat="server" Text="Home" OnClick="printsilicon_Click" />
                    </div>
                </div>
            </nav>
        </div>
        <hr class="infohr" />
        <div class="table-form">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="StatusTable" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="GridPanel" runat="server">
                        <div class="table-div">
                            <asp:GridView ID="printableTable" CssClass="customers" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="printableTable_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl No." ItemStyle-Width="100">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Project Title">
                                        <ItemTemplate>
                                            <%# Eval("Prefix") + " " + Eval("Title") + " " + Eval("Suffix")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="student1" HeaderText="Student" />
                                    <asp:BoundField DataField="section1" HeaderText="SEC" />
                                    <asp:BoundField DataField="student2" HeaderText="Student" />
                                    <asp:BoundField DataField="section2" HeaderText="SEC" />
                                    <asp:BoundField DataField="student3" HeaderText="Student" />
                                    <asp:BoundField DataField="section3" HeaderText="SEC" />
                                </Columns>
                            </asp:GridView>
                            <div class="provider-footer" style="text-align: center; font-weight: 600;">
                                <br />
                                <br />
                                Powered by;<br />
                                <a style="font-family: Monoton; font-size: 20px; color: #0094ff;">ROOK &nbsp&nbsp LABS</a>
                            </div>
                        </div>
                        <br />
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
                                    <asp:Button ID="_messagebutton" class="btn-message" runat="server" Text="OK" OnClick="_messagebutton_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="StatusTable">
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
    </form>
</body>
</html>
