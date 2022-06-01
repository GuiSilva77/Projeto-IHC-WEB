const EnviarBtn = document.getElementById("EnviarBtn");
// selecionar todas as checkboxes
const checkboxes = document.querySelectorAll('input[type="checkbox"]');
const filme = document.getElementById("inputGroupSelect01");
const horario = document.getElementById("hor");

EnviarBtn.addEventListener("click", function (event) {
  event.preventDefault();
  // criar um array com os valores dos checkboxes
  const checkboxesValues = Array.from(checkboxes).map(
    (checkbox) => checkbox.checked
  );

  let DiasSemana = "";
  checkboxesValues.map((value, index) => {
    if (value) {
      DiasSemana += "1";
    } else {
      DiasSemana += "0";
    }
  });

  if (filme.value == "") {
    alert("Preencha o campo filme");
    return;
  }

  if (horario.value == "") {
    alert("Preencha o campo horário");
    return;
  }

  // validação dos campos
  if (DiasSemana == "0000000") {
    alert("Selecione pelo menos um dia da semana");
    return;
  }

  const sala = document.querySelector("input[id=sala]:checked");
  if (sala == null) {
    alert("Selecione uma sala.");
    return;
  }

  const audio = document.querySelector("input[id=audio]:checked");
  if (audio == null) {
    alert("Selecione um tipo de áudio.");
    return;
  }

  const video = document.querySelector("input[id=video]:checked");
  if (video == null) {
    alert("Select o video.");
    return;
  }

  document.getElementById("diassemena").value = DiasSemana;
  document.querySelector("form").submit();
});
