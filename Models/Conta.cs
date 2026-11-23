using System.ComponentModel.DataAnnotations;

public class Conta
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "O número da conta é obrigatório.")]
    public int numero { get; set; } 
    [Required(ErrorMessage = "O tipo da conta é obrigatório.")]
    public string Tipo { get; set; }= "Corrente";
    [Range(0, double.MaxValue, ErrorMessage = "O saldo não pode ser negativo.")]
    public decimal Saldo { get; set; } 
    public bool Ativa { get; set; } = true;
}