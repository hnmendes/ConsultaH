const urlChecarCPF = "/Pacientes/CPFExists";

const cpf = $("#CPF");
const telefone = $("#Telefone");
const cpfError = $("#CPF-error");

let controller = getControllerName();

cpf.mask("000.000.000-00", { reverse: true });
telefone.mask("(00) 9 0000-0000");


cpf.on("keyup", function () {

    let strCpf = removerCaracteresEspeciais(cpf.val());

    if (strCpf.length == 11 && controller == 'Create')
    {

        $.post(urlChecarCPF, { CPF: strCpf }, function (data)
        {
            if (data)
            {
                cpfError.text("CPF já cadastrado, por favor adicione outro CPF.");
            }
        });

    }
    else
    {
        cpfError.text("");
    }
});


