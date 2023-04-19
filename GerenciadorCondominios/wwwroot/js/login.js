document.addEventListener('DOMContentLoaded', () => {
    const camposEntrada = document.querySelectorAll('input');
    camposEntrada.forEach(campo => {
        const mensagemValidacao = campo.parentElement.querySelector('.mensagem-validacao');
        if (mensagemValidacao && mensagemValidacao.textContent) {
            campo.classList.add('campo-invalido');
        }
    });

    camposEntrada.forEach(campo => {
        campo.addEventListener('input', () => {
            campo.classList.remove('campo-invalido');
            const mensagemValidacao = campo.parentElement.querySelector('.mensagem-validacao');
            if (mensagemValidacao) {
                mensagemValidacao.textContent = '';
            }
        });
    });
});
