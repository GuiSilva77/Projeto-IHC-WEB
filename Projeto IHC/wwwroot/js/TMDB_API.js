const nome = document.getElementById("Nome");
const botao = document.getElementById("nomeBtn");
const tabela = document.getElementById("table");
const form = document.getElementById("form");

const modal = new bootstrap.Modal(document.getElementById("exampleModal"));

const TMDB_API_KEY = "2e06b12031eb2557fa256ed1f6fd5651";
const TMDB_API_URL = "https://api.themoviedb.org/3/";
const TMDB_API_IMG = "https://image.tmdb.org/t/p/";

window.onload = () => {
  var tooltipTriggerList = [].slice.call(
    document.querySelectorAll('[data-bs-toggle="tooltip"]')
  );
  var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
  });
};

let results = {};

botao.addEventListener("click", async () => {
  if (nome.value == "" || nome.value == null) {
    modal.hide();
    nome.style.border = "1px solid red";
    nome.focus();
    document.getElementById("Nome-sp").innerText = "Insira um nome";
    return;
  } else {
    nome.style.border = "1px solid rgba(158, 162, 166, 0.418)";
    document.getElementById("Nome-sp").innerText = "";
  }

  await tabela.classList.add("bg-dark");

  await modal.show();

  tabela.innerHTML = `
  <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Selecionar Filme</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal"
            aria-label="Close"></button>
    </div>
    <div class="modal-body">
        <div class="container">
            <div class="container d-flex justify-content-center">
                <div>
                    <i class="fa-solid fa-circle-notch fa-spin fa-xl"></i>
                    <span>Carregando</span>
                </div>
            </div>
        </div>
    </div>
            `;

  await fetch(
    `${TMDB_API_URL}search/movie?api_key=${TMDB_API_KEY}&query=${nome.value}&language=pt-BR`,
    {
      method: "GET",
    }
  )
    .then(async (response) => {
      results = await response.json();
    })
    .catch((error) => {
      console.error(error);
    });

  if (results.results.length > 0) {
    tabela.innerHTML = "";

    tabela.innerHTML = `
    <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Selecionar Filme</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal"
            aria-label="Close"></button>
    </div>
    <div class="modal-body">
        <div class="container">
            <table class="table table-striped table-hover">
                <thead>
                  <th></th>
                  <th>Nome</th>
                  <th>Ano</th>
                  <th></th>
                </thead>
                <tbody id="conteudo">
                </tbody>
            </table>
        </div>
    </div>
    <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
    </div>
    `;

    const conteudo = document.getElementById("conteudo");
    console.log(results.results);

    results.results.map((element) => {
      conteudo.innerHTML += `<tr>
        <td><img src="${TMDB_API_IMG}w500${element.poster_path}" alt="" width="200px" height="300px"></td>
        <td><p>${element.title}</p></td>
        <td><p>${element.release_date}</p></td>
        <td>
          <button class="btn btn-primary" onclick="selecionarFilme(${element.id})" >Selecionar Filme</button>
        </td>
      </tr>`;
    });
  }
});

const selecionarFilme = (id) => {
  tabela.classList.remove("bg-dark");
  tabela.style.background = "none";

  tabela.innerHTML = `
  <div class="container d-flex justify-content-center">
  <div>
    <i class="fa-solid fa-circle-notch fa-spin fa-xl"></i>
  </div>
  </div>
      `;
  fetch(
    `${TMDB_API_URL}movie/${id}?api_key=${TMDB_API_KEY}&language=pt-BR&append_to_response=videos`
  )
    .then(async (response) => {
      const filme = await response.json();
      const filmeIMDB = await fetchIMDB(filme.imdb_id);
      console.log(filme);

      await LimparCampos();

      document.getElementById("Nome").value = filme.title;
      document.getElementById(
        "urlp"
      ).value = `${TMDB_API_IMG}w500${filme.poster_path}`;
      document.getElementById(
        "urlc"
      ).value = `${TMDB_API_IMG}original${filme.backdrop_path}`;

      if (filme.videos.results.length != 0)
        document.getElementById(
          "urlt"
        ).value = `https://www.youtube.com/embed/${filme.videos.results[0].key}`;
      else {
        document.getElementById("urlt").value = filmeIMDB.trailer.linkEmbed;
      }
      console.log(filmeIMDB);

      document.getElementById("dir").value = filmeIMDB.directors;
      document.getElementById("ano").value = filme.release_date.substring(0, 4);
      document.getElementById("dur").value = filme.runtime;
      document.getElementById("res").value = filme.overview;
      await modal.hide();
    })
    .catch((error) => {
      console.error(error);
    });
};

const fetchIMDB = async (id) => {
  const response = await fetch(
    `https://imdb-api.com/pt-BR/API/Title/k_19tt7n2c/${id}/Trailer`,
    {
      method: "GET",
    }
  )
    .then(async (response) => {
      const imdb = await response.json();
      console.log(imdb);
      return imdb;
    })
    .catch((error) => {
      console.error(error);
    });
  return response;
};

const LimparCampos = () => {
  document.getElementById("Nome").value = "";
  document.getElementById("urlp").value = "";
  document.getElementById("urlc").value = "";
  document.getElementById("urlt").value = "";
  document.getElementById("dir").value = "";
  document.getElementById("ano").value = "";
  document.getElementById("dur").value = "";
  document.getElementById("res").value = "";
};
