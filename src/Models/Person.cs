using System;
using System.Collections.Generic;

namespace src.Models;

#nullable enable

    public class Person
    {

        public Person()
        {
            this.ID = 1;
            this.Nome = "New_User";
            this.Idade = 0;
            this.Ativa = true;
            this.Contracts = new List<Contract>();
        }

        public Person(int ID, string Nome, int Idade)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.Idade = Idade;
            this.Ativa = true;
            this.Contracts = new List<Contract>();
        }

        public int ID { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string? Cpf { get; set; }   // o sinal de ? do lado do tipo de variável indica que ela pode ser nula

        public bool Ativa { get; set; }

        public List<Contract> Contracts { get; set; }

    }


