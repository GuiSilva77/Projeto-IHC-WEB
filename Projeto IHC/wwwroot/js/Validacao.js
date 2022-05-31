const limparBTN = document.getElementById("limparBtn");

const emBreve = document.getElementById("emBreve");
const emCartaz = document.getElementById("emCartaz");
const clas = document.getElementsById("clas");
const res = document.getElementById("res");

document.getElementById("EnviarBtn").addEventListener("click", (e) => {
  e.preventDefault();

  if (
    (emBreve.checked == true && emCartaz.checked == true) ||
    (emBreve.checked == false && emCartaz.checked == false)
  ) {
    document.getElementById("op-sp").innerText = "Selecione uma opção";
    return;
  }

  if (clas.value == "0") {
    document.getElementById("clas-sp").innerText =
      "Selecione uma classificação";
    return;
  }

  if (res.value == "" || res.value == null) {
    document.getElementById("res-sp").innerText = "Insira o resumo";
    return;
  }

  if (res != "" && res != null && clas.value != "0") {
    const form = document.getElementById("form");
    form.submit();
  }
});
