
const con = new signalR.HubConnectionBuilder()
    .withUrl("/connection")
    .build();

con.start();

var btn = $("#btn");
var input = $("#inputTag");
btn.on("click", function () {
    var id = input.val();
    con.invoke("Send", id);
});

con.on("Receive", function (id) {
    var li = $(`#${id}`);
    li.remove();
});
con.on("NotFound", function (error) {
    var err = $("#error");
    err.text(error);
});
function clearError() {
    var err = $("#error");
    err.text("");
}
