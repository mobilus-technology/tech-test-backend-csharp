using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTest.Application.DTOs;

public class ProdutoDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Informe o preço")]
    [Column(TypeName = "decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }

    //[Required(ErrorMessage = "Informe o preço")]
    [Column(TypeName = "decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal ValorTotal { get; set; }

    [Required(ErrorMessage = "Qauntidade de estoque é obrigatório")]
    [Range(1, 9999)]
    public int QuantidadeEstoque { get; set; }

    [Required(ErrorMessage = "Informe a data da criação do propduto")]
    public DateTime DataCriacao { get; set; }
}
