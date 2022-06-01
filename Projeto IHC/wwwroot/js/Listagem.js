const modal = new bootstrap.Modal(document.getElementById("exampleModal"));

const removerSessao = (id) => {
  modal.show();
  document.getElementById("btn-confirmar").onclick = () => {
    window.location.href = `/Admin/RemoverSessao/${id}`;
  };
};

const removerFilme = (id) => {
  modal.show();
  document.getElementById("btn-confirmar").onclick = () => {
    window.location.href = `/Admin/RemoverFilme/${id}`;
  };
};
