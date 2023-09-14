const con = new signalR.HubConnectionBuilder()
    .withUrl("/connection")
    .build();

con.start();

var input = document.getElementById("add");
var btn = document.getElementById("submit");
btn.addEventListener("click", function () {
    var sco = input.value;
    con.invoke("Add", sco);
});

con.on("Display", function (total) {
    var show = document.getElementById("score");
    show.innerText = total;
})