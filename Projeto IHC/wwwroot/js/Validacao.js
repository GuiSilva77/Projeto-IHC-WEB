const limparBTN = document.getElementById("limparBtn");

document.getElementById("EnviarBtn").addEventListener("click", async () => {
  //get all inputs
  const inputs = document.querySelectorAll("input");

  inputs.forEach((input) => {
    if (input.value == "") {
      document.querySelector(`${input.id}-sp`).innerText = "Campo obrigatório";
      return;
    } else {
      document.querySelector(`${input.id}-sp`).innerText = "";
    }
  });
});
