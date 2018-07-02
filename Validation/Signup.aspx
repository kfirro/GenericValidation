<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Signup.aspx.cs" Inherits="Validation.Signup" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function validateClientSide() {
            return true;
        }
    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="SitePlaceHolder">
    <div>
        <h1>Sign Up Page</h1>
        <div>
            <div id="divErrorMessages">
                <asp:Label ID="lblErrorMessages" runat="server"></asp:Label>
            </div>
            <form runat="server" id="frmSignup" name="frmSignup" method="post">
                <input id="iUsername" runat="server" type="text" name="username" value="" placeholder="username" /><br />
                <input id="iPassword" runat="server" type="password" name="password" value="" placeholder="password" /><br />
                <input id="iEmail" runat="server" type="text" name="Email" value="" placeholder="email" /><br />
                <asp:Button ID="btnSignup" Text="Sign Up" runat="server" OnClientClick="return validateClientSide()" OnClick="btnSignup_Click" />
            </form>
        </div>
    </div>
</asp:Content>
