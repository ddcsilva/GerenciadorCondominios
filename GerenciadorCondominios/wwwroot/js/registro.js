// Função para exibir a pré-visualização da imagem selecionada
function previewFile() {
    const file = document.getElementById("foto").files[0];
    const preview = document.querySelector(".image-preview");
    const icon = document.querySelector(".material-icons");
    const message = document.querySelector(".image-preview + span");

    const reader = new FileReader();
    reader.addEventListener("load", function () {
        preview.src = reader.result;
        preview.classList.remove("hidden");
        icon.classList.add("hidden");
        message.classList.add("hidden");
    }, false);

    if (file) {
        reader.readAsDataURL(file);
    }
}

// Função para adicionar máscaras de input e lidar com a força da senha
$(document).ready(function () {
    $('#CPF').mask('000.000.000-00', { reverse: true });
    $('#Telefone').mask('(00) 00000-0000');

    $('#Senha').on('input', function () {
        const passwordStrength = zxcvbn(this.value);
        const progressBar = $('#password-strength-bar');
        const strengthText = $('#password-strength-text');

        if (this.value.length > 0) {
            progressBar.removeClass("hidden");
        } else {
            progressBar.addClass("hidden");
        }

        let strengthColor = '';
        let strengthLabel = '';

        switch (passwordStrength.score) {
            case 0:
                strengthColor = 'bg-red-500';
                strengthLabel = 'Muito fraca';
                break;
            case 1:
                strengthColor = 'bg-red-500';
                strengthLabel = 'Fraca';
                break;
            case 2:
                strengthColor = 'bg-yellow-500';
                strengthLabel = 'Regular';
                break;
            case 3:
                strengthColor = 'bg-green-500';
                strengthLabel = 'Boa';
                break;
            case 4:
                strengthColor = 'bg-blue-500';
                strengthLabel = 'Excelente';
                break;
        }

        progressBar
            .attr('class', `h-2 rounded-md ${strengthColor}`)
            .css('width', `${(passwordStrength.score / 4) * 100}%`);

        strengthText.text(strengthLabel);
    });
});

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