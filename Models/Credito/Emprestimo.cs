public class Emprestimo
{
    public int Id {get;set;}
    public decimal Valor {get;set;}
    public int Prazo {get;set;}
    public int TaxaJuros {get;set;}
    public DateTime DataSolicitacao {get;set;}
    public DateTime DataVencimento {get;set;}
    public string Status {get;set;}
    public Cliente? Cliente {get;set;}
    public int ClienteId {get;set;}
}