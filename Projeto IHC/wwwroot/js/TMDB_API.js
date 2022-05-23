const nome = document.getElementById("Nome");
const botao = document.getElementById("nomeBtn");
const tabela = document.getElementById("table");
const form = document.getElementById("form");

const TMDB_API_KEY = "2e06b12031eb2557fa256ed1f6fd5651";
const TMDB_API_URL = "https://api.themoviedb.org/3/";
const TMDB_API_IMG = "https://image.tmdb.org/t/p/";

let results = {};

botao.addEventListener("click", async () => {
  await fetch(
    `${TMDB_API_URL}search/movie?api_key=${TMDB_API_KEY}&query=${nome.value}&language=pt-br`,
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
    tabela.innerHTML = `<table class="table table-striped table-hover">
        <thead>
          <th></th>
          <th>Nome</th>
          <th>Ano</th>
          <th></th>
        </thead>
        <tbody id="conteudo">
        </tbody>
      </table>`;

    const conteudo = document.getElementById("conteudo");
    console.log(results.results);

    results.results.map((element) => {
      conteudo.innerHTML += `<tr>
        <td><img src="${TMDB_API_IMG}w500${element.poster_path}" alt="${element.title}" width="200px" height="300px"></td>
        <td>${element.title}</td>
        <td>${element.release_date}</td>
        <td>
          <button class="btn btn-primary" onclick="selecionarFilme(${element.id})">Selecionar Filme</button>
        </td>
      </tr>`;
    });
  }
});

const selecionarFilme = (id) => {
  tabela.innerHTML = "";
  fetch(
    `${TMDB_API_URL}movie/${id}?api_key=${TMDB_API_KEY}&language=pt-br&append_to_response=videos`
  )
    .then(async (response) => {
      const filme = await response.json();
      console.log(filme);
      tabela.innerHTML += `<div class="card">
        <div class="card-body">
          <h5 class="card-title">${filme.title}</h5>
          <p class="card-text">${filme.overview}</p>
          <img src="${TMDB_API_IMG}w500${filme.poster_path}" alt="${filme.title}" width="200px" height="300px">
          </div>
      </div>`;
      debugger;
      if (filme.videos.results.length == 0) {
        var key = await adicionarLinkTrailer();
      }

      var key = filme.videos.results[0].key;
      inserirTrailer(key);
    })
    .catch((error) => {
      console.error(error);
    });
};

const inserirTrailer = (videoKey) => {
  tabela.innerHTML += `<div class="card">
    <div class="card-body">
      <h5 class="card-title">Trailer</h5>
      <iframe width="560" height="315" src="https://www.youtube.com/embed/${videoKey}" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
    </div>
  </div>`;
};

const adicionarLinkTrailer = () => {
  //create a modal to the user to enter the link of the trailer
  tabela.innerHTML += `<div class="card">
    <div class="card-body">
      <h5 class="card-title">Adicionar Trailer</h5>
      <form id="formTrailer">
        <div class="form-group">
          <label for="trailer">Link do Trailer</label>
          <input type="text" class="form-control" id="trailer" placeholder="Link do Trailer">
        </div>
        <button type="submit" class="btn btn-primary">Adicionar</button>
      </form>
    </div>
  </div>`;

  const formTrailer = document.getElementById("formTrailer");
  formTrailer.addEventListener("submit", async (e) => {});
};
