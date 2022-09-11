
//CONTEXTO DE BANDO DE DADOS PARA USAR O ENTITY FRAMEWORK NO INTUITO DE CRIAR UM BANCO DE DADOS

using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;


public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
        
    }

    public DbSet<Person> PersonTable { get; set; }
    public DbSet<Contract> ContractsTable { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder builder){  //sobreescrevendo o método herdado da classe DbContext
        builder.Entity<Person>(table =>{    //criando uma entidade no DB baseado no modelo Person e apelidando de table
            table.HasKey(e => e.ID);  // Informando que a nova entidade table possui uma chave PRIMARIA originada da prop ID. 
            table
                .HasMany(e => e.Contracts)  //cada pessoa pode ter muitos Contracts...
                .WithOne()                  //... cada contrato possui uma ...
                .HasForeignKey(c => c.PersonID);   //... chave estrangeira baseada na prop PersonID do modelo Contracts
        });

        builder.Entity<Contract>(table =>{
            table.HasKey(e => e.ID);
        });
    }
    
}

