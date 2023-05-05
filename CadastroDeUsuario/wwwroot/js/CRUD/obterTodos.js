window.addEventListener('load', async () => {
    let usuarios = await obterTodos();
    let corpoDaTabela = document.getElementById("corpoDaLista");
    
    usuarios.forEach(usuario => {
       let linhaTabela = `<tr>
                            <td>${usuario.nome}</td>
                            <td align="right">
                                <a href="detalhes.html#${usuario.id}" class="btn-sm btn-primary detalhes">Detalhes</a>
                            </td>
                        </tr>`

        corpoDaTabela.innerHTML += linhaTabela;
    });
});