function aplicarMascaraCPF(texto) {
    _texto = texto;
    setTimeout('executarFormatacao()', 1);
}

function executarFormatacao() {
    _texto.value = formatarCPF(_texto.value);
}

function formatarCPF(cpf) {

    //Remocpfe tudo o que não é dígito
    cpf = cpf.replace(/\D/g, "")

    if (cpf.length <= 14) { //CPF

        //Coloca um ponto entre o terceiro e o quarto dígitos
        cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")

        //Coloca um ponto entre o terceiro e o quarto dígitos
        //de nocpfo (para o segundo bloco de números)
        cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")

        //Coloca um hífen entre o terceiro e o quarto dígitos
        cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")

    } else { //CNPJ

        //Coloca ponto entre o segundo e o terceiro dígitos
        cpf = cpf.replace(/^(\d{2})(\d)/, "$1.$2")

        //Coloca ponto entre o quinto e o sexto dígitos
        cpf = cpf.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")

        //Coloca uma barra entre o oitacpfo e o nono dígitos
        cpf = cpf.replace(/\.(\d{3})(\d)/, ".$1/$2")

        //Coloca um hífen depois do bloco de quatro dígitos
        cpf = cpf.replace(/(\d{4})(\d)/, "$1-$2")

    }

    return cpf
}