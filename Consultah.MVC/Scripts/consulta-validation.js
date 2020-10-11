const urlSearch = "/Consultas/GetSearchCpfOrName";
const urlAllPacientes = "/Consultas/GetAllPacientes";
const urlAllExamesByTipo = "/Consultas/GetAllExamesByTipo";
const urlHorarioExists = "/Consultas/HorarioExists";

let exameIDError = $("#ExameId-Error");
let pacienteIDError = $("#PacienteID-Error");
let tipoExameIDError = $("#TipoExameID-Error");
let horarioError = $("Horario-Error");

let btnNovoExame = $("#btnNovoExame");


$("#Horario").on("change", function () {

    let horario = $("#Horario").val();

    $("#Horario-error").text("");

    $.post(urlHorarioExists, { date: horario }, function (data) {

        if (data) {
            $("#Horario-error").text("Esse horário já foi marcado, por favor escolha outro.")
        }
        
    });

});


$("#form").on("submit", function (event) {

    let exameID = $('#ExameID option:selected').val();
    let pacienteID = $('input[name="PacienteID"]:checked').val();
    let tipoExameID = $('#TipoExameID option:selected').val();
    let horario = $("#Horario").val();        

    if (!pacienteID) {
        pacienteIDError.text("Selecione um paciente.");
        event.preventDefault();
        console.log("paciente");
    }

    if (!tipoExameID) {
        tipoExameIDError.text("Selecione um tipo de exame.");
        event.preventDefault();       
        console.log("tipo");
    }

    if (exameID == 0) {        

        exameIDError.text("Selecione um exame.");
        exameIDError.show();
        event.preventDefault();
        console.log("exame");
    }

    if (horario == undefined) {
        horarioError.text("Preencha com um horário.");
        event.preventDefault();
        console.log("horario");
    }
    
});

$("#ExameID").on("change", function () {
    exameIDError.text("");
    btnNovoExame.hide();
});


$.post(urlAllPacientes, function (data) {

    if (data.length > 0) {

        if (getControllerName() == 'Edit') {

            let selected = $("#idPaciente").val();

            for (i = 0; i < data.length; i++) {
                if (data[i].ID == selected) {
                    $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" value="' + data[i].ID + '" checked></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                } else {
                    $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                }
                
            }

        } else {

            for (i = 0; i < data.length; i++) {

                $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
            }
        }

        $(".PacienteCpf").mask("000.000.000-00");


    } else {
        $("#SemCliente").show();
    }
});


$("#Buscar").on("keyup", function () {
    let cpfOuNome = $("#Buscar").val();
    $("#SemClienteBusca").hide();


    if (cpfOuNome == '') {

        $("#table").find("td").parent().remove();

        $.post(urlAllPacientes, function (data) {

            if (data.length > 0) {

                $("#SemCliente").hide();

                for (i = 0; i < data.length; i++) {
                    $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
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
                        $("#table").append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
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


if (getControllerName() == "Edit") {

    $.post(urlAllExamesByTipo, { tipoExameId: selectedTipoExame }, function (data) {

        if (data.length == 0) {
            
            $("#ExameID").append("<option value='0'><span class='text-danger'>O exame não é mais referenciado</span></option>");
            $("#SemExame").slideToggle();            
            $("#btnNovoExame").slideToggle();

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
} else {
    if (selectedTipoExame != '') {

        $.post(urlAllExamesByTipo, { tipoExameId: selectedTipoExame }, function (data) {

            if (data.length == 0) {
                $("#ExameID option:selected").text("Não possui Exame para esse Tipo");
                $("#SemExame").slideToggle();
                $("#btnNovoExame").slideToggle();
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
}


$("#TipoExameID").on('change', function () {        

    exameIDError.hide();
    $("#SemExame").hide();
    $("#ExameID option").remove();
    btnNovoExame.hide();

    var id = this.options[this.selectedIndex].value;    

    if (id != "") {

        $.post(urlAllExamesByTipo, { tipoExameId: id }, function (data) {                        

            if (data.length == 0) {
                $("#ExameID").append("<option value='0'>Não possui Exame para esse Tipo</option>");
                exameIDError.text("Selecione um exame.");
                btnNovoExame.show();
                $("#SemExame").show();
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


function getControllerName() {
    let str = window.location.pathname;
    str = str.split("/");

    return str[2];
}