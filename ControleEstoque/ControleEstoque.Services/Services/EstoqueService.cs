using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace ControleEstoque.Services {
    public class EstoqueService {

        private JavaScriptSerializer _serializer;
        private string _caminhoArquivoProdutos;

        public EstoqueService(string caminho) {
            _serializer = new JavaScriptSerializer();
            _caminhoArquivoProdutos = caminho;
        }

        public List<Dominio.Entidades.Produto> buscarTodosProdutos() {
            string arquivoProdutos = Helpers.ArquivoTxt.lerArquivo(_caminhoArquivoProdutos);
            List<Dominio.Entidades.Produto> produtos = _serializer.Deserialize<List<Dominio.Entidades.Produto>>(arquivoProdutos);
            return produtos;
        }

        public void incrementaEstoque(int idProduto) {
            string arquivoProdutos = Helpers.ArquivoTxt.lerArquivo(_caminhoArquivoProdutos);
            List<Dominio.Entidades.Produto> produtos = _serializer.Deserialize<List<Dominio.Entidades.Produto>>(arquivoProdutos);
            Dominio.Entidades.Produto produtoEncontrado = produtos.Where(x => x.id == idProduto).FirstOrDefault();
            produtoEncontrado.quantidade += 1;
            Helpers.ArquivoTxt.escreverArquivo(_caminhoArquivoProdutos, _serializer.Serialize(produtos));
        }
       
        public void decrementaEstoque(int idProduto) {
            string arquivoProdutos = Helpers.ArquivoTxt.lerArquivo(_caminhoArquivoProdutos);
            List<Dominio.Entidades.Produto> produtos = _serializer.Deserialize<List<Dominio.Entidades.Produto>>(arquivoProdutos);
            Dominio.Entidades.Produto produtoEncontrado = produtos.Where(x => x.id == idProduto).FirstOrDefault();
            produtoEncontrado.quantidade -= 1;
            Helpers.ArquivoTxt.escreverArquivo(_caminhoArquivoProdutos, _serializer.Serialize(produtos));
        }

    }
}
