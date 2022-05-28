const limparBTN = document.getElementById("limparBtn");

limparBTN.addEventListener("click", () => {
    document.getElementById("Nome").value = "";
    document.getElementById("urlp").value = "";
    document.getElementById("urlc").value = "";
    document.getElementById("urlt").value = "";
    document.getElementById("dir").value = "";
    document.getElementById("ano").value = "";
    document.getElementById("dur").value = "";
    document.getElementById("res").value = "";
})

document.getElementById("EnviarBtn").addEventListener("click", async () => {
    // check if urltrailer is valid
    // if not, show error message
    // if yes, send form
    //valid: https://www.youtube.com/embed/
    const urltrailer = document.getElementById("urlt").value;

    if (urltrailer.substring(0, 32) != "https://www.youtube.com/embed/") {
        alert("URL do trailer inválida");
    } else {
        form.submit();
    }
});