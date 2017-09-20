using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace ControleEstoque.Controllers {
    public class ProdutoController : Controller {

        private string _caminhoArquivoProdutos;
        private Services.EstoqueService _servicoEstoque;

        public ProdutoController() {
            _caminhoArquivoProdutos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "controleEstoque.txt");
            _servicoEstoque = new Services.EstoqueService(_caminhoArquivoProdutos);
        }

        [HttpGet]
        public JsonResult buscarTodosProdutos() {
            List<Dominio.Entidades.Produto> produtos = _servicoEstoque.buscarTodosProdutos();
            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult incrementaEstoque(int idProduto) {
            _servicoEstoque.incrementaEstoque(idProduto);
            return Json(true);
        }

        [HttpPost]
        public JsonResult decrementaEstoque(int idProduto) {
            _servicoEstoque.decrementaEstoque(idProduto);
            return Json(true);
        }

    }
}