const con = new signalR.HubConnectionBuilder()
    .withUrl("/connection")
    .build();

con.start();

con.on("Display", function (total) {
    var show = document.getElementById("score");
    show.innerText = total;
})