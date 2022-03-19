using System.Text.Json.Serialization;

namespace MinimalApiCatalogo.Models;
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public string Imagem { get; set; }
        public string DataCompra { get; set; }
        public string Estoque { get; set; }
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }
    }
