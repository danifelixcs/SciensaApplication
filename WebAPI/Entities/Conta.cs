using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Conta
    {
        public Conta()
        {

        }
        public Conta(Guid id,Guid clientId, Conta conta)
        {
            Id = id;
            ClientId = clientId;
            Agencia = conta.Agencia;
            NumeroConta = conta.NumeroConta;
            TipoConta = conta.TipoConta;
        }
        public Conta(Guid id, Conta conta)
        {
            Id = id;
            ClientId = conta.ClientId;
            Agencia = conta.Agencia;
            NumeroConta = conta.NumeroConta;
            TipoConta = conta.TipoConta;
        }
        public Conta(Guid id, Guid clientId, string agencia, string conta, string tipoConta)
        {
            Id = id;
            ClientId = clientId;
            Agencia = agencia;
            NumeroConta = conta;
            TipoConta = tipoConta;
        }
        [Key, Column("IdConta"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        [Column("Agencia"), MaxLength(100), Required]
        public string Agencia { get; set; }
        [Column("NumeroConta"), MaxLength(100), Required]
        public string NumeroConta { get; set; }
        [Column("TipoContaId"), MaxLength(100), Required]
        public string TipoConta { get; set; }
        [Column("Saldo"), Required]
        public decimal Saldo { get; set; }


        [Column("ClienteId")]
        public Guid ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Cliente Cliente { get; set; }
    }
}
