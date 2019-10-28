<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="busproj.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 320px">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter the details!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Source"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Destination"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search!" />
            <br />
            <br />
            <asp:GridView  ID="GridView1" AllowSorting="true" runat="server"  AutoGenerateColumns="false" OnRowCommand="Grid_RowCommand">
                <Columns>   
                    <asp:BoundField DataField="BusId" HeaderText="Bus Number"/> 
                    <asp:BoundField DataField="Operator" HeaderText="Operator"/>   
                    <asp:BoundField DataField="DepartureTime" SortExpression="DepartureTime" HeaderText="Departure Time"/>   
                    <asp:BoundField DataField="ArrivalTime" HeaderText="Arrival Time"/>   
                    <asp:BoundField DataField="Source" HeaderText="Source"/>
                    <asp:BoundField DataField="Destination" HeaderText="Destination"/>
                    <asp:BoundField DataField="Price" HeaderText="Price"/>
                    <asp:BoundField DataField="Seats" HeaderText="Seats"/>
                    <asp:ButtonField CommandName="Reserve" Text="Reserve now!" />
                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
