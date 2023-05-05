let sharp = location.href.indexOf("#");
let idUsuario = location.href.substring(sharp + 1);
let ehEditar = !isNaN(idUsuario);

window.onload = async () => {
    if (ehEditar) {
        let usuario = await obterPorId(idUsuario);
        preencherCampos(usuario);
        document.getElementById("botaoCadastrarEditar").innerText = "Editar";
    }
};

document.getElementById("botaoCadastrarEditar").addEventListener('click', async (e) => {
    e.preventDefault();

    if (ehEditar) {
        let usuarioAtualizado = obterObjetoJson();
        atualizar(usuarioAtualizado, idUsuario);
    } else {
        criar();
    }
});

function preencherCampos({nome, email, telefone, observacao}) {
    document.getElementById("nome").value = nome;
    document.getElementById("email").value = email;
    document.getElementById("telefone").value = telefone;
    document.getElementById("observacao").value = observacao;
}