const limparBTN = document.getElementById("limparBtn");

const EmBreve = document.getElementById("EmBreve");
const EmCartaz = document.getElementById("EmCartaz");
const clas = document.getElementsById("clas");
const res = document.getElementById("res");

document.getElementById("EnviarBtn").addEventListener("click", (e) => {
  e.preventDefault();

  if (
    (EmBreve.checked == true && EmCartaz.checked == true) ||
    (EmBreve.checked == false && EmCartaz.checked == false)
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
