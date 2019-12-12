<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckLoopQR3.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.6.4.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

<style>
    #myInput {
        font-size: 16px;
        padding: 6px 20px 6px 10px;
        border: 1px solid #ddd;
        margin-bottom: 3px;
    }
</style>

    <script type="text/javascript">
    $(window).load(function(){
    $("#checkAll").change(function () {
    $("input:checkbox").prop('checked', $(this).prop("checked"));
    });
    });
    </script>
    <script>
        function myFunction() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("CheckBox1");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>QR Code Generator</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Please Input Data</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtQRCode" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-prepend">
                                <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-secondary" Text="Generate" OnClick="btnGenerate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnSelect" runat="server" CssClass="btn btn-secondary" Text="Display Text" OnClick="btnSelect_Click" /><br /><br />

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            <asp:CheckBox ID="checkAll" runat="server" Font-Size="Large"/><asp:Label id="checkTextAll" runat="server" Font-Size="Large"></asp:Label><br /><br />

            <label>Input Number to Search &nbsp;&nbsp;</label>
            <input type="text" id="myInput" onkeyup="myFunction()"><br /><br />

            <asp:CheckBoxList ID="CheckBox1" runat="server" Border="1"
            BorderColor="LightGray" Font-Size="Large"></asp:CheckBoxList>  

        </div>
    </form>
</body>
</html>