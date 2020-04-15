function Display() {
    var xmlhttp = new XMLHttpRequest();
    var usn = document.getElementById("UserUsn").value;
    xmlhttp.open("GET", "request.aspx?UserUsn=" + usn, false);
    xmlhttp.send(null);
    var data = xmlhttp.responseText.split(",");
    document.getElementById("UserName").value = data[0];
    document.getElementById("UserEmail").value = data[1];
}

function home()
{
    window.location = "Home";
}


function print() {
    var printContents = document.getElementById(printableTable).innerHTML;
    var originalContents = document.body.innerHTML;
    document.title = "My new title";
    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
}

