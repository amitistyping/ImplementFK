<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="primarydetails.aspx.cs" Inherits="whydothis.primarydetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelFirstName" runat="server" Text="FirstName "></asp:Label>     
            <asp:TextBox ID="TextFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelLastName" runat="server" Text="LastName "></asp:Label>
            <asp:TextBox ID="TextLastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelAge" runat="server" Text="Age "></asp:Label>
            <asp:TextBox ID="TextAge" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelGender" runat="server" Text="Gender "></asp:Label>
            <asp:RadioButton ID="RadioMale" runat="server" Text="Male" Checked="true" GroupName="Gender" />
            <asp:RadioButton ID="RadioFemale" Text="Female" runat="server" GroupName="Gender" />
            <br />
            <asp:Label ID="LabelPAN" runat="server" Text="PAN "></asp:Label>
            <asp:TextBox ID="TextPAN" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelLicense" runat="server" Text="License "></asp:Label>
            <asp:TextBox ID="TextLicense" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelPhone" runat="server" Text="Phone "></asp:Label>
            <asp:TextBox ID="TextPhone" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelHobbies" runat="server" Text="Select Your Hobbies"></asp:Label>
            <asp:CheckBoxList ID="CheckHobbies" runat="server">
                
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />

        </div>
    </form>
</body>
</html>
