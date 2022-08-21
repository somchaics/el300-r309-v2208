
$(function () {
    var hubproxy = $.connection.hublink;
    //client
   
    hubproxy.client.display_division_client = function (opx, d) {
        switch (opx) {
            case 0: add_table_row(d); break; //add
            case 1: find_update_record(d); break; //update 
            case 2: find_record(d[0]);  row_delete(); break; //delete
        }
       
    }
        
    hubproxy.client.send_message = function (msg) {
        display_info(msg);
    }

    hubproxy.client.get_data_chat = function (data) {
        display_info(data);
        getAllMessages();
    }

     // Start the connection.  
    $.connection.hub.start().done(function () {
         //call server
        $("#send-msg").click(function () {
           //call hub hublink.cs
           //var code = document.getElementById('msg').value;
            var code = $("#msg").val(); //jQuery
            hubproxy.server.send_message(code);
        });

        $("#add-rec").click(function () {
            var r = {};
            var c= [];
            set_division(r, c);

            var svc = new svShare;
            svc.division_insert_record(connectString, JSON.stringify(r), onSuccess, onFail, null);
            function onSuccess(result) {
                if (result != null) {
                    message_edit(result);
                    return;
                }

                hubproxy.server.display_division_server(0, c);
                message_edit("add success");
            }

            function onFail(result) {
                message_edit(result);
            }
        });

        $("#update-rec").click(function () {
            var r = {};
            var c = [];
            set_division(r, c);

            var svc = new svShare;
            svc.division_update_record(connectString, JSON.stringify(r), onSuccess, onFail, null);
            function onSuccess(result) {
                if (result != null) {
                    message_edit(result);
                    return;
                }
              
                hubproxy.server.display_division_server(1, c);
                message_edit("update success");
            }

            function onFail(result) {
                message_edit(result);
            }
           
        });

        $("#del-rec").click(function () {
            var r = {};
            var c = [];
            set_division(r, c);

            var svc = new svShare;
            svc.division_delete_record(connectString, c[0], onSuccess, onFail, null);
            function onSuccess(result) {
                if (result != null) {
                    message_edit(result);
                    return;
                }
                hubproxy.server.display_division_server(2, c);
                message_edit("delete success");
            }

            function onFail(result) {
                message_edit(result);
            }

        });

       // getAllMessages();
        display_info('connection started.');

    }).fail(function (e) {
        display_info('connection fail.');
    });

    //reconnect
    $.connection.hub.disconnected(function () {
        setTimeout(function () {
            $.connection.hub.start();
        }, 5000); // Restart connection after 5 seconds.
    });

});

//send from hub 
function getAllMessages() {
    var svc = new svShare;
    svc.get_chat_state(connectString, onSuccess, onFail, null);
    function onSuccess(result) {
        if (result[0] == "*") {
            display_info('error reading (1).');
            return;
        }
     }
    function onFail(result) {
        display_info('fail..' + result);
    }
}

function display_info(e) {
    $('#id-msg').text(e);
}

function set_division(r, c) {
    c[0] = document.getElementById('code').value;
    c[1] = document.getElementById('name').value;
    c[2] = document.getElementById('status').value;

    r["Division_code"] = c[0];
    r["Division_name"] = c[1];
    r["Division_status"] = c[2];
}
