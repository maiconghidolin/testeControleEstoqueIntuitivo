var viewModel;

$(document).ready(function () {
    function produtosViewModel() {
        var self = this;

        self.produtos = ko.observableArray();

        self.incrementarEstoque = function (produto) {
            $.ajax({
                type: "POST",
                data: { idProduto: produto.id() },
                url: "/Produto/incrementaEstoque",
                dataType: "json",
                success: function (data) {
                    produto.quantidade(produto.quantidade() + 1);
                }
            });
        };

        self.decrementarEstoque = function (produto) {
            $.ajax({
                type: "POST",
                data: {idProduto: produto.id()},
                url: "/Produto/decrementaEstoque",
                dataType: "json",
                success: function (data) {
                    produto.quantidade(produto.quantidade() - 1);
                }
            });
        }
    }
    viewModel = new produtosViewModel()
    ko.applyBindings(viewModel);
    buscarProdutos();
});

function produto(objeto) {
    this.id = ko.observable(objeto.id);
    this.nome = ko.observable(objeto.nome);
    this.quantidade = ko.observable(objeto.quantidade);
}

function buscarProdutos() {
    $.ajax({
        type: "GET",
        url: "/Produto/buscarTodosProdutos",
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var produtos = data.map(function (item) { return new produto(item) });
            viewModel.produtos(produtos);
        }
    });
}
