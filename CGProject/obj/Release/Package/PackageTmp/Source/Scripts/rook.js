﻿function Display() { var e = new XMLHttpRequest, n = document.getElementById("UserUsn").value; e.open("GET", "request.aspx?UserUsn=" + n, !1), e.send(null); var t = e.responseText.split(","); document.getElementById("UserName").value = t[0], document.getElementById("UserEmail").value = t[1] } function home() { window.location = "Home" } function print() { var e = document.getElementById(printableTable).innerHTML, n = document.body.innerHTML; document.title = "My new title", document.body.innerHTML = e, window.print(), document.body.innerHTML = n }