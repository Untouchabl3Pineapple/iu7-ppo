function hidePas() {
    var x = document.getElementById("pas");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}