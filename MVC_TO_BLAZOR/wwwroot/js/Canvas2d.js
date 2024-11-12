window.draw = function (id) {
    console.log(`draw function ${id}`);
    const canvas = document.getElementById(id);
    console.log(canvas);
    if (canvas.getContext) {
        console.log("got ctx");
        const ctx = canvas.getContext("2d");
        ctx.fillStyle = "green";
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        ctx.fillStyle = "orange";
        ctx.fillStyle = "rgb(200 0 0)";
        ctx.fillRect(10, 10, 50, 50);

        ctx.fillStyle = "rgb(0 0 200 / 50%)";
        ctx.fillRect(30, 30, 50, 50);
    }
}
