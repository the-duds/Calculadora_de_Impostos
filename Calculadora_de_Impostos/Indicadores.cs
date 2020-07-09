namespace Calculadora_de_Impostos
{
    public class Indicadores
    {
        public decimal FaturamentoAnual { get; set; }
        public decimal VlrCustosAnual { get; set; }
        public decimal VlrDespesasAnual { get; set; }
        public decimal VlrFolhaAnual { get; set; }
        public decimal Ant_EncargoSocialAnual { get; set; }
        public decimal Ant_VlrMedioImpostosAnual { get; set; }
        public decimal Ant_LucroAnual { get; set; }
        public decimal DepreciacaoAutomoveis { get; set; }
        public decimal DepreciacaoUtilitarios { get; set; }
        public decimal DespesaTotalcomDeprecicacao { get; set; }
        public decimal ImpostosFolha { get; set; }
        public decimal PisDebito { get; set; }
        public decimal PisCredito { get; set; }
        public decimal CofinsDebito { get; set; }
        public decimal CofinsCredito { get; set; }
        public decimal VlrRecolherPis { get; set; }
        public decimal VlrRecolherConfins { get; set; }
        public decimal VlrAnualAproxdeImpostos { get; set; }
        public decimal VlrAnualAproxImpostosPorcentagem { get; set; }
        public decimal NovoLucroAnual { get; set; }
        public decimal EconomiaTributariaAno { get; set; }
        public decimal AumentodaLucratividadeAno { get; set; }
        public string Resultado { get; internal set; }
    }
}
