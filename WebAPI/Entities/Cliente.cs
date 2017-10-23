using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            this.Contas = new HashSet<Conta>();
        }

        public Cliente(string nome, string cpf, string endereco)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Endereco = endereco;
        }


        [Key, Column("IdCliente"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("Nome"), MaxLength(100), Required]
        public string Nome { get; set; }
        [Column("Cpf"), MaxLength(100), Required]
        public string Cpf { get; set; }
        [Column("Endereco"), MaxLength(255), Required]
        public string Endereco { get; set; }
        public virtual ICollection<Conta> Contas { get; set; }
    }
}
