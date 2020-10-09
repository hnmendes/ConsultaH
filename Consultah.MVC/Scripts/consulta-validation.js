const urlSearch = "/Consultas/GetSearchCpfOrName";
const urlAllPacientes = "/Consultas/GetAllPacientes";
const urlAllExamesByTipo = "/Consultas/GetAllExamesByTipo";

$.post(urlAllPacientes, function (data) {

    if (data.length > 0) {

        for (i = 0; i < data.length; i++) {
            $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" required value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
        }

    } else {
        $("#SemCliente").show();
    }
});


$("#Buscar").keyup(function () {

    let cpfOuNome = $("#Buscar").val();

    if (cpfOuNome == '') {

        $("#table").find("td").parent().remove();

        $.post(urlAllPacientes, function (data) {

            if (data.length > 0) {

                $("#SemCliente").hide();

                for (i = 0; i < data.length; i++) {
                    $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" required value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                }


            } else {
                $("#SemCliente").show();
            }
        });


    } else {


        $.post(urlSearch, { cpfOuNome: cpfOuNome }, function (data) {

            if (data.length > 0) {

                $("#table").find("td").parent().remove();

                for (i = 0; i < data.length; i++) {

                    var index = $("#table").find("td:contains('" + data[i].Nome + "')").parent().index();

                    if (index == -1) {
                        $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" required value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                    }
                }

            } else {
                $("#table").find("td").parent().remove();
                $("#SemClienteBusca").show();
            }
        });
    }

});

var selectedTipoExame = $('#TipoExameID option:selected').val();
var oldExameValue = '';

if (selectedTipoExame != '') {

    $.post(urlAllExamesByTipo, { tipoExameId: selectedTipoExame }, function (data) {

        if (data.length == 0) {
            $("#ExameID option:selected").text("Não possui Exame para esse Tipo");
        } else {

            for (let i = 0; i < data.length; i++) {

                if (data[i].TipoExameID == selectedTipoExame) {
                    $("#ExameID").append(new Option(data[i].Nome, data[i].ID, true));
                    oldExameValue = data[i].Nome;
                } else {
                    $("#ExameID").append(new Option(data[i].Nome, data[i].ID));
                }                
            }            
        }

        $("#ExamePeloTipo").show();
    });
}

$("#TipoExameID").on('change', function () {    

    $("#ExameID option").remove();    

    var id = this.options[this.selectedIndex].value;    

    if (id != "") {

        $.post(urlAllExamesByTipo, { tipoExameId: id }, function (data) {                        

            if (data.length == 0) {
                $("#ExameID").append(new Option("Não possui Exame para esse Tipo"));
            } else {
                $("#ExameID").append(new Option("Selecione um Exame"));
                for (let i = 0; i < data.length; i++) {
                    $("#ExameID").append(new Option(data[i].Nome, data[i].ID));
                }
            }
            
            $("#ExamePeloTipo").show();

        });
    } else {
        $("#ExamePeloTipo").hide();
    }

});