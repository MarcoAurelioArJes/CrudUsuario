let sharp = location.href.indexOf("#");
let idUsuario = location.href.substring(sharp + 1);

window.addEventListener('load', async (e) => {
    e.preventDefault();
    let usuario = await obterPorId(idUsuario);
    let detalhes = document.getElementById("conteudoDetalhes");

    detalhes.innerHTML = `<h5 class="card-title">${usuario.nome}</h5>
                          <p class="card-text">Email: ${usuario.email}</p>
                          <p class="card-text">Telefone: ${usuario.telefone}</p>
                          <p class="card-text">Observação: ${usuario.observacao}</p>
                          <a href="cadastroEEditar.html#${usuario.id}" class="btn btn-primary">Editar</a>
                          <a href="#" class="btn btn-danger" data-toggle="modal" data-target="#confirmacaoExclusao">Excluir</a>
                          <a href="index.html" class="btn btn-secondary">Voltar</a>`;
                        
});

document.getElementById("confirmaExclusao").addEventListener('click', async (e) => {
    let resultadoRemocao = await remover(idUsuario);
    if (resultadoRemocao.ok) {
        var modalExclusao = document.getElementById('exclusaoSucesso');
        modalExclusao.classList.remove('show');
        modalExclusao.style.display = 'none';
        document.body.classList.remove('modal-open');
        modalExclusao.removeAttribute('aria-modal');
        modalExclusao.setAttribute('aria-hidden', true);
        var modalBackdrop = document.getElementsByClassName('modal-backdrop')[0];
        modalBackdrop.parentNode.removeChild(modalBackdrop);
    }
});