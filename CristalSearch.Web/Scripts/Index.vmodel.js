var objIdCristal;
var objNomeCristal;
var objCorCristal;
var objPlanetaCristal;
var objSignificadoCristal;
var idCristal;

var CristalModel = function (id, nome, cor, planeta, significado) {
    var cristal = {
        Id: id,
        Nome: nome,
        Cor: cor,
        Planeta: planeta,
        Significado: significado
    };

    return cristal;
}

$(document).ready(function () {
    carregarDados();
});

function filtrar() {
    var filtro = toFiltro();

    $("table tbody").empty();

    $.ajax({
        url: "/Home/Filtrar",
        data: filtro,
        contentType: "application/json",
        dataType: "json",
        success: function (retorno) {
            var tr;
            $.each(retorno.Dados, function (id, cristal) {
                tr = gerarCorpoDaTabela(cristal);
                $("table tbody").append(tr);
            });
        },
        error: function (retorno) {
            alert("Algum erro ocorreu ao filtrar, tente novamente!");
        }
    });
}

function toFiltro() {
    var filtro = {
        Nome: $("#filtroNome").val(),
        Cor: $("#filtroCor").val(),
    }
    return filtro;
}

function salvar() {
    if (!camposEstaoValidos()) {
        alert("Preencha os dados corretamente!");
        $("#myModalConfirmation").modal("hide");
        return;
    }

    var cristal = new CristalModel(
        objIdCristal,
        objNomeCristal,
        objCorCristal,
        objPlanetaCristal,
        objSignificadoCristal
    );

    var cristalToSend = JSON.stringify(cristal);

    $.ajax({
        type: "POST",
        url: "/Home/SalvarCristal",
        data: cristalToSend,
        contentType: "application/json",
        dataType: "json",
        success: function (retorno) {
            if (retorno.NomeDoCristalJaExiste) {
                alert("O cristal não foi salvo, pois já existe um cristal cadastrado com esse nome.");
                return;
            }
            carregarDados();
            $("#myModal").modal("hide");
            $("#myModalConfirmation").modal("hide");
            limparCampos();
            alert('Salvo com sucesso! :)');
        }
    });
}

function carregarDados() {
    $("table tbody").empty();

    $.ajax({
        url: "/Home/CarregarCristais",
        success: function (retorno) {
            var tr;
            $.each(retorno.Dados, function (id, cristal) {
                tr = gerarCorpoDaTabela(cristal);
                $("table tbody").append(tr);
            });
        },
        error: function (retorno) {
            alert("Falha ao carregar os cristais. Por favor recarregue a página!");
        }
    });
}

function gerarCorpoDaTabela(cristal) {
    var tr = "<tr>" +
        '<td style=' + '"display: none;" id = "' + cristal.Id + '"></td>' +
        "<td>" + cristal.Nome + "</td>" +
        "<td>" + cristal.Cor + "</td>" +
        "<td> " + cristal.Planeta + "</td>" +
        "<td>" + cristal.Significado + "</td>" +
        '<td><button type="button" data-toggle="modal" data-target="#myModal" onclick="editar(this)" class="btn input-button__acoes-item">Editar</button>' +
        '<button type="button" data-toggle="modal" data-target="#myModalConfirmationDelete" onclick="indicarQualCristalSeraExcluido(this)" class="btn input-button__acoes-item">Excluir</button></td>' +
        "</tr>";

    return tr;
}

function editar(self) {
    $('#titulo-modal').text("EDIÇÃO DE UM CRISTAL");
    var cristal = $(self).parent().parent();

    $('#idCristal').val(cristal.children(0)[0].id);
    $('#nomeCristal').val(cristal.children(0)[1].innerText);
    $('#corCristal').val(cristal.children(0)[2].innerText);
    $('#planetaCristal').val(cristal.children(0)[3].innerText);
    $('#significadoCristal').val(cristal.children(0)[4].innerText);
}

function indicarQualCristalSeraExcluido(self) {
    idCristal = self.parentElement.parentElement.children[0].id;
}

function excluir() {
    
    $.ajax({
        url: "/Home/Excluir",
        data: { id: idCristal },
        contentType: "application/json",
        dataType: "json",
        success: function (retorno) {
            carregarDados();
            $("#myModalConfirmationDelete").modal("hide");
            alert('Excluído com sucesso! :)');
        },
        error: function (retorno) {
            $("#myModalConfirmationDelete").modal("hide");
            alert("Não foi possível deletar esse cristal, tente novamente!");
        }
    });
}

function adicionar() {
    $('#titulo-modal').text("CADASTRO DE NOVO CRISTAL");
}

function camposEstaoValidos() {
    var camposValidos = true;

    objIdCristal = $("#idCristal").val();

    if (ehCampoValido($("#nomeCristal").val())) {
        objNomeCristal = $("#nomeCristal").val();
    } else {
        $("#nomeCristal").addClass("input__validacao--erro");
        camposValidos = false;
    }

    if (ehCampoValido($("#corCristal").val())) {
        objCorCristal = $("#corCristal").val();
    } else {
        $("#corCristal").addClass("input__validacao--erro");
        camposValidos = false;
    }

    if (ehCampoValido($("#planetaCristal").val())) {
        objPlanetaCristal = $("#planetaCristal").val();
    } else {
        $("#planetaCristal").addClass("input__validacao--erro");
        camposValidos = false;
    }

    if (ehCampoValido($("#significadoCristal").val())) {
        objSignificadoCristal = $("#significadoCristal").val();
    } else {
        $("#significadoCristal").addClass("input__validacao--erro");
        camposValidos = false;
    }

    return camposValidos;
}

function ehCampoValido(campo) {
    if (campo == null || campo == undefined || campo == "" || campo == '' || campo == []) {
        return false;
    }
    return true;
}

function limparCampos() {
    $("#idCristal").val("");
    $("#nomeCristal").val("");
    $("#corCristal").val("");
    $("#planetaCristal").val("");
    $("#significadoCristal").val("");

    $("#nomeCristal").removeClass("input__validacao--erro");
    $("#corCristal").removeClass("input__validacao--erro");
    $("#planetaCristal").removeClass("input__validacao--erro");
    $("#significadoCristal").removeClass("input__validacao--erro");
}
