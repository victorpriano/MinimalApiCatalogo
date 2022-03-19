using System.Text.Json.Serialization;

namespace MinimalApiCatalogo.Models;
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore] //Permite não exibir a coleção de produtos no Swagger
        public IReadOnlyCollection<Produto> Produtos { get; set; }
    }
