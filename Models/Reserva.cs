using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de cadastrar os hóspedes.");
            }

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new InvalidOperationException("A capacidade da suíte é menor que o número de hóspedes.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada para calcular o valor da diária.");
            }

            decimal valorDiaria = Suite.ValorDiaria * DiasReservados;

            // Aplicar desconto de 10% se a reserva for de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valorDiaria *= 0.9m; // 10% de desconto
            }

            return valorDiaria;
        }
    }
}
