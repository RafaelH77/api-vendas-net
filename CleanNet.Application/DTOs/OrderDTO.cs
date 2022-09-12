using CleanNet.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CleanNet.Application.DTOs;

public class OrderDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Date is Required")]
    [DisplayName("Date")]
    public DateTime? Date { get; set; }

    [Required(ErrorMessage = "The Amount is Required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Amount")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "The Comission is Required")]
    [DisplayName("Comission")]
    public decimal Comission { get; set; }

    [MaxLength(250)]
    [DisplayName("Observation")]
    public string? Observation { get; set; }

    [JsonIgnore]
    public Seller? Seller { get; set; }

    [DisplayName("Sellers")]
    public int SellerId { get; set; }
}
