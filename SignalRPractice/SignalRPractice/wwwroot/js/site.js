const con = new signalR.HubConnectionBuilder()
    .withUrl("/connection")
    .build();


con.start().then(function () {

    con.invoke("SendMessage", "this is test message", "user123");
});

con.on("ReceiveMessage", function (message) {
    console.log(message);
});