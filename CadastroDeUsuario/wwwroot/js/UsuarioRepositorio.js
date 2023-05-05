async function criar() {

    let usuario = obterObjetoJson();

    var resposta = await requisicaoApi("Criar", {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(usuario)
    });

    if (resposta.ok)
        limparCampos();
}

async function atualizar(usuario, id) {
    await requisicaoApi(`Atualizar/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(usuario)
    });
}

async function obterPorId(id) {
    let requisicao = await requisicaoApi(`ObterPorId/${id}`);
    return await respostaApi(requisicao);
}

async function obterTodos() {
    let requisicao = await requisicaoApi("ObterUsuarios");
    return await respostaApi(requisicao);
}

async function remover(id) {
    return await requisicaoApi(`Remover/${id}`, {method: 'DELETE'});
}

function obterObjetoJson() {
    return {
        nome: document.getElementById("nome").value,
        email: document.getElementById("email").value,
        telefone: document.getElementById("telefone").value,
        observacao: document.getElementById("observacao").value,
    };
}

function limparCampos() {
    document.getElementById("nome").value = '';
    document.getElementById("email").value = '';
    document.getElementById("telefone").value = '';
    document.getElementById("observacao").value = '';
}