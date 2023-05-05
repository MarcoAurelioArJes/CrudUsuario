let baseURL = "https://localhost:7217/api/Usuario";

async function requisicaoApi(endpoint, opcoesRequisicao = { method: 'GET' }) {
    return await fetch(`${baseURL}/${endpoint}`, opcoesRequisicao);
}

async function respostaApi(requisicao) {
    return requisicao.headers.get("content-type") !== null ? await requisicao.json() : null;
}