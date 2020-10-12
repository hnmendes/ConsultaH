//Endpoints
const urlSearch = "/Consultas/GetSearchCpfOrName";
const urlAllPacientes = "/Consultas/GetAllPacientes";
const urlAllExamesByTipo = "/Consultas/GetAllExamesByTipo";
const urlHorarioExists = "/Consultas/HorarioExists";
const controller = getControllerName();

//Elementos do form
let exame = $("#Exame option:selected");
let exameAppend = $("#Exame");
let exameEdit = $("#ExameID");
let horario = $("#Horario");
let paciente = $("input[name='PacienteRadio']:checked");
let pacienteEdit = $("#PacienteID");
let tipoExame = $("#TipoExame option:selected");
let tipoExameEdit = $("#TipoExameID");

//Erros
let exameError = $("#ExameID-Error");
let pacienteError = $("#PacienteID-Error");
let tipoExameError = $("#TipoExameID-Error");
let horarioError = $("#Horario-Error");
let semCliente = $("#SemCliente");
let semClienteBusca = $("#SemClienteBusca");
let semExame = $("#SemExame");

//Elementos
let table = $("#table");
let form = $("#form");
let buscar = $("#Buscar");
let examePeloTipo = $("#ExamePeloTipo");
let btnNovoExame = $("#btnNovoExame");


horario.on("change", function ()
{
    let horarioValue = horario.val();        

    horarioError.hide();

    let request = $.ajax({
        url: urlHorarioExists,
        type: "POST",
        data: { date: horarioValue }
    });

    request.done(function (data) {        

        if (data) {
            horarioError.append('&nbsp;<svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-calendar-x" fill="currentColor" xmlns="http://www.w3.org/2000/svg">  <path fill-rule="evenodd" d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z"></path>  <path fill-rule="evenodd" d="M6.146 7.146a.5.5 0 0 1 .708 0L8 8.293l1.146-1.147a.5.5 0 1 1 .708.708L8.707 9l1.147 1.146a.5.5 0 0 1-.708.708L8 9.707l-1.146 1.147a.5.5 0 0 1-.708-.708L7.293 9 6.146 7.854a.5.5 0 0 1 0-.708z"></path></svg>');
            horarioError.text("Esse horário já foi marcado, por favor escolha outro.");            
            horarioError.show();    
        }
    });            
    
});


$("#fakeSubmit").on("click", function (event)
{
    let exameValue = exameEdit.val();
    let pacienteValue = pacienteEdit.val();
    let tipoExameValue = tipoExameEdit.val();
    let horarioValue = horario.val();

    let syncValues = true;

    if (pacienteValue == 0)
    {        
        pacienteError.text("Selecione um paciente.");
        pacienteError.show();
        syncValues = false;
    }

    if (tipoExameValue == 0)
    {        
        tipoExameError.text("Selecione um tipo de exame.");
        tipoExameError.show();        
        syncValues = false;
    }

    if (exameValue == 0)
    {
        exameError.text("Selecione um exame.");
        exameError.show();            
        syncValues = false;
    }

    if (horarioValue == '') {

        horarioError.text("Preencha com um horário.");
        horarioError.show();
        syncValues = false;

    } else {       

        let request = $.ajax({
            url: urlHorarioExists,
            type: "POST",
            data: { date: horarioValue }
        });

        request.done(function (data) {                        

            if (data && syncValues) {
                horarioError.append('&nbsp;<svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-calendar-x" fill="currentColor" xmlns="http://www.w3.org/2000/svg">  <path fill-rule="evenodd" d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z"></path>  <path fill-rule="evenodd" d="M6.146 7.146a.5.5 0 0 1 .708 0L8 8.293l1.146-1.147a.5.5 0 1 1 .708.708L8.707 9l1.147 1.146a.5.5 0 0 1-.708.708L8 9.707l-1.146 1.147a.5.5 0 0 1-.708-.708L7.293 9 6.146 7.854a.5.5 0 0 1 0-.708z"></path></svg>');
                horarioError.text("Esse horário já foi marcado, por favor escolha outro.");                
                horarioError.show();                
            } else {                
                $("#submit").click();
            }
        });
       
    }    
    
});


$("body").on("change","#Exame", function (event)
{    
    exameEdit.val(event.target.value);    
    exameError.hide();
    btnNovoExame.hide();
});

$("body").on("change", "#table input[type=radio]", function (event) {        
    pacienteEdit.val(event.target.value);
    pacienteError.hide();
});

$.post(urlAllPacientes, function (data)
{
    if (data.length > 0)
    {
        if (controller == 'Edit') {

            let selected = pacienteEdit.val();

            for (i = 0; i < data.length; i++) {                

                if (data[i].ID == selected) {
                    $("#table").append('<tr><td><input name="PacienteRadio" type="radio" value="' + data[i].ID + '" checked></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                } else {
                    $("#table").append('<tr><td><input name="PacienteRadio" type="radio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                }
            }
        } else {            

            for (i = 0; i < data.length; i++)
            {
                for (i = 0; i < data.length; i++) {

                    $("#table").append('<tr><td><input name="PacienteRadio" type="radio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                }
            }
        }                                
    }
    else
    {
        semCliente.show();
    }
});


buscar.on("keyup", function ()
{
    let cpfOuNome = buscar.val();
    semClienteBusca.hide();

    if (cpfOuNome == '')
    {
        table.find("td").parent().remove();

        $.post(urlAllPacientes, function (data)
        {
            if (data.length > 0)
            {
                semCliente.hide();

                for (i = 0; i < data.length; i++)
                {
                    table.append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" class="pacienteRadio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                }
            }
            else
            {
                semCliente.show();
            }
        });
    }
    else
    {
        $.post(urlSearch, { cpfOuNome: cpfOuNome }, function (data)
        {
            if (data.length > 0)
            {
                table.find("td").parent().remove();

                for (i = 0; i < data.length; i++)
                {
                    var index = table.find("td:contains('" + data[i].Nome + "')").parent().index();

                    if (index == -1)
                    {
                        table.append('<tr><td><input id="PacienteID" name="PacienteID" type="radio" class="pacienteRadio" value="' + data[i].ID + '"></td><td>' + data[i].Nome + '</td><td><input class="form-control PacienteCpf" data-mask="000.000.000-00" value="' + data[i].CPF + '" disabled /></td></tr>');
                    }
                }
            }
            else
            {
                table.find("td").parent().remove();
                semClienteBusca.show();
            }
        });
    }
});


$(document).ready(function () {

    let tipoExameValue = tipoExameEdit.val();

    if (controller == "Edit") {

        $.post(urlAllExamesByTipo, { tipoExameId: tipoExameValue }, function (data)
        {
            if (data.length == 0)
            {
                exameAppend.append("<option value='0'><span class='text-danger'>O exame não é mais referenciado</span></option>");
                semExame.show();
                btnNovoExame.show();
            }
            else
            {
                for (let i = 0; i < data.length; i++)
                {
                    if (data[i].TipoExameID == tipoExameValue)
                    {
                        exameAppend.append(new Option(data[i].Nome, data[i].ID, true));
                    }
                    else
                    {
                        exameAppend.append(new Option(data[i].Nome, data[i].ID));
                    }
                }
            }

            examePeloTipo.show();
        });
    }
    else
    {        
        let tipoExameId = tipoExameEdit.val();        

        if (tipoExameId != 0)
        {
            $.post(urlAllExamesByTipo, { tipoExameId: tipoExameId }, function (data) {                

                if (data.length == 0)
                {
                    exame.text("Não possui Exame para esse Tipo");
                    semExame.show();
                    btnNovoExame.show();
                }
                else
                {
                    exameAppend.append("<option value='0'>Selecione Um Exame</option>");

                    for (let i = 0; i < data.length; i++)
                    {
                        if (data[i].TipoExameID == tipoExameId)
                        {
                            exameAppend.append(new Option(data[i].Nome, data[i].ID, true));
                        }
                        else
                        {
                            exameAppend.append(new Option(data[i].Nome, data[i].ID));
                        }
                    }
                }

                examePeloTipo.hide();
            });
        }
    }
});


$("#TipoExame").on('change', function ()
{        
    exameError.hide();
    semExame.hide();
    tipoExameError.hide();
    $("#Exame option").remove();
    btnNovoExame.hide();

    let id = this.options[this.selectedIndex].value;
    tipoExameEdit.val(id);

    if (id != 0)
    {        
        $.post(urlAllExamesByTipo, { tipoExameId: id }, function (data) {                        

            if (data.length == 0)
            {
                exameAppend.append("<option value='0'>Não possui Exame para esse Tipo</option>");

                exameError.text("Selecione um exame.");
                exameError.show();

                btnNovoExame.show();
                semExame.show();
            }
            else
            {             
                for (let i = 0; i < data.length; i++)
                {
                    exameAppend.append(new Option(data[i].Nome, data[i].ID));
                }
            }
            
            examePeloTipo.show();
        });
    }
    else
    {
        examePeloTipo.hide();
    }

});
