using System;

namespace src.Models;

public class Contract
{
    public Contract()
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenID = "0000";    
    }

    public Contract(double Valor, string TokenID)
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = Valor;
        this.TokenID = TokenID;    
    }

    public int ID { get; set; }
    
    public DateTime DataCriacao { get; set; }

    public string TokenID { get; set; }

    public double Valor { get; set; }

    public bool Pago { get; set; }

    public int PersonID { get; set; }
    
    
}