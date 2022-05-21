const API_Key = '2e06b12031eb2557fa256ed1f6fd5651';

var obj = {};
const Nome = document.getElementById("Nome");
const Botao = document.getElementById("nomeBtn");

Botao.addEventListener("click", () => {
    $.ajax({
        url: `https://api.themoviedb.org/3/search/movie?api_key=${API_Key}&query=${Nome.value}`,
        type: 'GET',
        contentType: "application/json",
        success: (Response) => {
            obj = Response;
        }
    })

    console.log(obj);

    $.ajax({
        url: "https://api.themoviedb.org/3/movie/550?api_key=2e06b12031eb2557fa256ed1f6fd5651",
        type: 'GET',
        contentType: "application/json",
        success: (Response) => {
            console.log(Response);
        }
    })
});
