using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora_de_Impostos.Models
{
    public class Parametros
    {
        /// <summary>
        /// STRING - Metodo utilizado para acessar os recursos da api;
        /// </summary>
        public string Metodo { get; set; }
        /// <summary>
        /// STRING - Informação que pode ser (Lucro Real, Lucro Presumido, Simples Nacional);
        /// </summary>
        public string RegimeTribuatrio { get; set; }
        /// <summary>
        /// INT - Numero de veiculos da frota;
        /// </summary>
        public int NumFrota { get; set; }
        /// <summary>
        /// DECIMAL - Valor total da Frota de Veiculos da Empresa;
        /// </summary>
        public decimal VlrFrotaTotal { get; set; }
        /// <summary>
        /// INT - O tempo medio que o veiculo permanece na frota antes de ser vendido;
        /// </summary>
        public int TempoPermanencia  { get; set; }
        /// <summary>
        /// INT - Percentual de desvalorização da frota;
        /// </summary>
        public double Desvalorizacao { get; set; }
        /// <summary>
        /// DECIMAL - Faturamento Mensal com a frota;
        /// </summary>
        public decimal FaturamentoMensal { get; set; }
        /// <summary>
        /// INT - Quantidade de veiculos da frota vendidos no mês;
        /// </summary>
        public int VeiculosVendidosMes { get; set; }
        /// <summary>
        /// INT - Pocentagem de veiculos comuns na frota.
        /// </summary>
        public int PerfilAutomoveis { get; set; }
        /// <summary>
        /// INT - Porcentagem de veiculos Uitilitarios na frota.
        /// </summary>
        public int PerfilUtilitarios { get; set; }
        /// <summary>
        /// DECIMAL - Valor refernete aos custos que conseguimos apropriar credito de PIS/COFINS.
        /// </summary>
        public decimal VlrCustosMensal { get; set; }
        /// <summary>
        /// DECIMAL - Valor referente as despesas administrativas, todo gasto que não gera credito de PIS/COFINS.
        /// </summary>
        public decimal VlrDespesasMensal { get; set; }
        /// <summary>
        /// DECIMAL - Valor referente a folha de pagamento mensal sem os valores referente aos encargos.
        /// </summary>
        public decimal VlrFolha { get; set; }
        /// <summary>
        /// DECIMAL - Valor referente a todos os impostos pagos mensalmente(VALOR DO SIMPLES NACIONAL).
        /// </summary>
        public decimal VlrImpostosMensal { get; set; }

        
    }
}