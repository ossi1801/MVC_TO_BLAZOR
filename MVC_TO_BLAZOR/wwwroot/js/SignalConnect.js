//Connects to signalR
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .withAutomaticReconnect() //Reconnect
    .configureLogging(signalR.LogLevel.Information)
    .build();
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
connection.onclose(async () => {
    await start();
});
start();
//End - Connects to signalR

//Reconnect
connection.onreconnecting(error => {
    console.assert(connection.state === signalR.HubConnectionState.Reconnecting);

    document.getElementById("messageInput").disabled = true;

    const li = document.createElement("li");
    li.textContent = `Connection lost due to error "${error}". Reconnecting.`;
    document.getElementById("messageList").appendChild(li);
});

//custom functions called from c# :
connection.on("ReceiveMessage", (user, message) => {
    console.log(`${user}: ${message}`)
    // const li = document.createElement("li");
    // li.textContent = `${user}: ${message}`;
    // document.getElementById("messageList").appendChild(li);
});

connection.on("CanvasInit", (id,data) => {
    window.parent.draw(id);
    console.log(`${id}: ${data}`)
    // const li = document.createElement("li");
    // li.textContent = `${user}: ${message}`;
    // document.getElementById("messageList").appendChild(li);
});
// Start the connection.
