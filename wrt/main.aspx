<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="wrt.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WRT</title>

    <script src="ui/jquery-1.12.4.min.js"></script>
    <!--Script signalR -->
    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.3.min.js"></script>
    <script src="signalr/hubs"></script>
    <script src="plugin/call-hub.js"></script>
    <script src="plugin/read-data.js"></script>

    <script>
        //global
        var connectString = "Data Source=wnl;Initial Catalog=eldb;User ID=sa;Password=Sa12345@";

        //function
        function f_list_division() {
            get_data_division();
        }

        //not used
        function f_add_division() {
           insert_record_division();
        }

        function f_update_division() {
            update_record_division();

             //filter
            var code = document.getElementById('code').value.toUpperCase();

            find_record(code);
            row_focus();
         
        }

        function f_delete_division() {
            delete_record_division();
        }


        function message_edit(e) {
            $('#info-edit').text(e);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
             <Services>
                 <asp:ServiceReference Path="~/services/shares/svshare.svc" />

            </Services>
        </asp:ScriptManager>


        <h2>Realtime</h2>
              
        <div id="id-msg" style="bottom:0; padding:10px; color: green;">info : </div>
         <br />
               
        <div  style ="float:left; position:relative; width:300px;">
            <div style="padding:10px;">
                <label for="code">Code:</label><br/>
            <input type="text" id="code" name="code" value=""><br/>
            <label for="name">Name:</label><br/>
            <input type="text" id="name" name="dname" value=""><br/>
            <label for="status">Staus:</label><br/>
            <input type="text" id="status" name="status" value="A"><br/><br/>

            <input id="add-rec" type="button" value="Add" >
            <input  id="update-rec" type="button" value="Update" >
            <input  id="del-rec" type="button" value="Delete" >

           <input style="margin-left:50px;"  type="button" value="List" onclick="f_list_division()">
                        

                <br/><br/>
                <div id="info-edit" style="bottom:0; padding:10px; color:red;">message edit : </div>
            </div>
        </div>

        <div style ="float:left; position:relative;">
        
        <div id="id-show"></div><br/>
       </div>

    </form>
</body>
</html>


