
function display_data(rec) {
    var colw = [150, 250, 50]; //col width
    var coltext = ["Code", "Division name", "Status"]; //header text
    var col = [];
    for (var i = 0; i < rec.length; i++) {
        for (var key in rec[i]) {
            if (col.indexOf(key) === -1) {
                col.push(key);
            }
        }
    }

    var table = document.createElement("table");
    table.setAttribute("id", "id-mytable");
    var tr = document.createElement("tr");      //header
    table.appendChild(tr);

    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");      //header
        th.style.width = colw[i] + "px";
        th.innerHTML = coltext[i];
        tr.appendChild(th);
    }

    // ADD JSON DATA 
    for (var i = 0; i < rec.length; i++) {
        // tr = table.insertRow(-1);
        var tr = document.createElement("tr");      //header
        table.appendChild(tr);

        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1);
            tabCell.innerHTML = rec[i][col[j]];
        }
    }

    var divContainer = document.getElementById("id-show");
    divContainer.innerHTML = "";
    divContainer.appendChild(table);

}

function get_data_division() {
    var svc = new svShare;
    svc.get_division(connectString, onSuccess, onFail, null);
    function onSuccess(result) {
        if (result[0] == "*") {
            alert(result);
            return;
        }
        const rec = JSON.parse(result);
        display_data(rec);
    }

    function onFail(result) {
        alert(result);
    }
}


function insert_record_division() {

    var row = {};
    var col = [];
    col[0] = document.getElementById('code').value;
    col[1] = document.getElementById('name').value;
    col[2] = document.getElementById('status').value;

    row["Division_code"] = col[0];
    row["Division_name"] = col[1];
    row["Division_status"] = col[2];
       
    var svc = new svShare;
    svc.division_insert_record(connectString, JSON.stringify(row), onSuccess, onFail, null);
    function onSuccess(result) {
        if (result != null) {
            message_edit(result);
            return;
        }
        add_table_row(col);
        message_edit("add success");
    }

    function onFail(result) {
        message_edit(result);
    }

}

function update_record_division() {
    var row = {};
    row["Division_code"] = document.getElementById('code').value;
    row["Division_name"] = document.getElementById('name').value;
    row["Division_status"] = document.getElementById('status').value;

    var svc = new svShare;
    svc.division_update_record(connectString, JSON.stringify(row), onSuccess, onFail, null);
    function onSuccess(result) {
        if (result != null) {
            message_edit(result);
            return;
        }

        update_table_list();
        message_edit("update success");
    }

    function onFail(result) {
        message_edit(result);
    }

}

function delete_record_division() {
    var code = document.getElementById('code').value;

    var svc = new svShare;
    svc.division_delete_record(connectString, code, onSuccess, onFail, null);
    function onSuccess(result) {
        if (result != null) {
            message_edit(result);
            return;
        }

        //find to delete row 
        var code = document.getElementById('code').value.toUpperCase();
        find_record(code);
        row_delete();
        message_edit("delete success");
    }

    function onFail(result) {
        message_edit(result);
    }
}

function update_table_list() {
    if (index < 0) return;
    row[index].getElementsByTagName("td")[1].innerText = document.getElementById('name').value;
    row[index].getElementsByTagName("td")[2].innerText = document.getElementById('status').value;

}

function add_table_row(col) {
    var table = document.getElementById("id-mytable");
    var tr = document.createElement("tr");
    table.appendChild(tr);

    for (var j = 0; j < col.length; j++) {
        var tabCell = tr.insertCell(-1);
        tabCell.innerHTML = col[j];
    }

}

//filter
function filter_record(filter) {
    var table = document.getElementById("id-mytable");
    var tr = table.getElementsByTagName("tr");
   
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

//find
var index;
var row;
var lastindex =-1;
var lastrow;

function row_focus() {
    if (index < 0) return;
    if (lastindex >= 0) row_losefocus();

    row[index].setAttribute("style", "background-color: orange;");
   
    lastindex = index;
    lastrow = row;
}

function row_losefocus() {
    lastrow[lastindex].setAttribute("style", "background-color: transparent;");
}

function row_delete() {
    if (index < 0) return;
    document.getElementById("id-mytable").deleteRow(index);

    lastindex = -1; //clear focus
}

function find_record(value) {
    index = -1; //clear
    var table = document.getElementById("id-mytable");
    var tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(value) > -1) { //found
                index = i;
                row = tr;
                row[index].getElementsByTagName("td")[1].innerText = document.getElementById('name').value;
                row[index].getElementsByTagName("td")[2].innerText = document.getElementById('status').value;
                break;
            }
        }
    }
}

function find_update_record(col) {
    index = -1; //clear
    var table = document.getElementById("id-mytable");
    var tr = table.getElementsByTagName("tr");
 
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(col[0]) > -1) { //found
                index = i;
                row = tr;
                row[index].getElementsByTagName("td")[1].innerText =col[1];
                row[index].getElementsByTagName("td")[2].innerText = col[2];
                row_focus();
                break;
            }
        }
    }
}