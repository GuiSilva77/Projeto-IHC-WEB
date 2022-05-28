﻿const nome = document.getElementById("Nome");
const botao = document.getElementById("nomeBtn");
const tabela = document.getElementById("table");
const form = document.getElementById("form");

const modal = new bootstrap.Modal(document.getElementById("exampleModal"));

const TMDB_API_KEY = "2e06b12031eb2557fa256ed1f6fd5651";
const TMDB_API_URL = "https://api.themoviedb.org/3/";
const TMDB_API_IMG = "https://image.tmdb.org/t/p/";

let results = {};

botao.addEventListener("click", async () => {
    if (nome.value == "" || nome.value == null) {
        modal.hide()
        document.getElementById("Nome-sp").innerText = "Insira um nome";
        return;
    }
    else {
        document.getElementById("Nome-sp").innerText = "";
    }

    modal.show();

    tabela.innerHTML = `
        <div class="container d-flex justify-content-center">
            <div>
                <i class="fa-solid fa-circle-notch fa-spin fa-xl"></i>
                <span>Carregando</span>
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
        <td><img src="${TMDB_API_IMG}w500${element.poster_path}" alt="" width="200px" height="300px"></td>
        <td><p>${element.title}</p></td>
        <td><p>${element.release_date}</p></td>
        <td>
          <button class="btn btn-primary" onclick="selecionarFilme(${element.id})" data-bs-dismiss="modal">Selecionar Filme</button>
        </td>
      </tr>`;
        });
    }
});

const selecionarFilme = (id) => {
    fetch(
        `${TMDB_API_URL}movie/${id}?api_key=${TMDB_API_KEY}&language=pt-BR&append_to_response=videos`
    )
        .then(async (response) => {
            debugger
            const filme = await response.json();
            console.log(filme);

            document.getElementById("Nome").value = filme.title;
            document.getElementById("urlp").value = `${TMDB_API_IMG}w500${filme.poster_path}`;
            document.getElementById("urlc").value = `${TMDB_API_IMG}original${filme.backdrop_path}`;

            if (filme.videos.results.length != 0)
                document.getElementById("urlt").value = `https://www.youtube.com/embed/${filme.videos.results[0].key}`;

            document.getElementById("dir").value = filme.director;
            document.getElementById("ano").value = filme.release_date.substring(0, 4);
            document.getElementById("dur").value = filme.runtime;
            document.getElementById("res").value = filme.overview;
        })
        .catch((error) => {
            console.error(error);
        });
    fetch(
        `${TMDB_API_URL}movie/${id}?api_key=${TMDB_API_KEY}&language=pt-BR&append_to_response=videos`
    )
        .then(async (response) => {
            debugger
            const filme = await response.json();
            console.log(filme);

            if (filme.videos.results.length != 0)
                document.getElementById("urlt").value = `https://www.youtube.com/embed/${filme.videos.results[0].key}`;

            document.getElementById("dir").value = filme.director;
            
        })
        .catch((error) => {
            console.error(error);
        });
};