function dataFormatada(d) {
    var x = d;
    var re = /-?\d+/;
    var m = re.exec(x);
    var data = new Date(parseInt(m[0], 10));
    return data.getDate() + '/' + (data.getMonth() + 1) + '/' + data.getFullYear();
    ;
}

function set_dados_form(dados) {
    $('#id_cadastro').val(dados.Id);
    $('#txt_Nome').val(dados.Nome),
   $('#txt_Telefone').val(dados.Telefone),
    $('#txt_Endereco').val(dados.Endereco),
   $('#txt_Data').val(dataFormatada(dados.DataNascimento)),
   $('#cbx_Ativo').prop('checked', dados.Ativo);
}


function set_focus_form() {
    $('#txt_nome').focus();
}

function set_dados_grid(dados) {
    return '<td>' + dados.Nome + '</td>' +
            '<td>' + dados.Telefone + '</td>' +
            '<td>' + dados.Endereco + '</td>' +
            '<td>' + dataFormatada(dados.DataNascimento) + '</td>' +
           '<td>' + (dados.Ativo ? 'SIM' : 'NÃO') + '</td>';
}

function get_dados_inclusao() {
    return {
        Id: 0,
        Nome: '',
        Telefone: '',
        Endereco: '',
        DataNascimento:Date.now().toString,
        Ativo: true
    };
}

function get_dados_form() {
   
    return {
        Id: $('#id_cadastro').val(),
        Nome: $('#txt_Nome').val(),
        Telefone: $('#txt_Telefone').val(),
        Endereco: $('#txt_Endereco').val(),
        DataNascimento: $('#txt_Data').val(),
        Ativo: $('#cbx_Ativo').prop('checked')
    };
}

function preencher_linha_grid(param, linha) {
    linha
        .eq(0).html(param.Nome).end()
        .eq(1).html(param.Telefone).end()
        .eq(2).html(param.Endereco).end()
        .eq(3).html(param.DataNascimento).end()
        .eq(4).html(param.Ativo ? 'SIM' : 'NÃO');
}