﻿using Calculadora_de_Impostos.Models;
using Microsoft.VisualBasic;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Calculadora_de_Impostos
{
    public class Calculos : Parametros
    {
        //CALCULOS PARA VALORES ANUAIS
        /// <summary>
        /// Metodo para o calculo do faturamento anual.
        /// </summary>
        /// <param name="FaturamentoMensal"> Valor referente ao valor de faturamento mensal.</param>
        /// <returns> Retorno (FaturamentoMensal * 12)</returns>
        public decimal FaturamentoAnual(decimal FaturamentoMensal)
        {
            return FaturamentoMensal * 12;
        }

        /// <summary>
        /// Metodo para o calculo dos custos anual.
        /// </summary>
        /// <param name="CustosMensais"> Valor referente aos custos mensais</param>
        /// <returns> Retorna: (CustosMensais * 12)</returns>
        public decimal VlrCustosAnual(decimal VlrCustosMensal)
        {
            return VlrCustosMensal * 12;
        }

        /// <summary>
        /// Metodo para o calculo das despesas anual.
        /// </summary>
        /// <param name="DespesasMensais"> Valor referente as despesas mensais</param>
        /// <returns> Retorna (DespesasMensais * 12)</returns>
        public decimal VlrDespesasAnual(decimal DespesasMensais)
        {
            return DespesasMensais * 12;
        }

        /// <summary>
        /// Metodo para o calculo das folha anual.
        /// </summary>
        /// <param name="FolhaMensal"> Valor referente a folha mensal.</param>
        /// <returns>Retorna (FolhaMensal * 12)</returns>
        public decimal VlrFolhaAnual(decimal VlrFolha)
        {
            return VlrFolha * 12;
        }


        /// <summary>
        /// Metodo para o calculo dos impostos anual.
        /// </summary>
        /// <param name="ImpostosMensais"> Valor referente aos impostos mensais.</param>
        /// <returns> Retorna (ImpostosMensais*12)</returns>
        public decimal Ant_VlrMedioImpostosAnual(decimal ImpostosMensais)
        {
            return ImpostosMensais * 12;
        }

        /// <summary>
        ///  Metodo para o calculo dos Encargos Sociais Anual
        /// </summary>
        /// <param name="FolhadePagamento"> Valor referente a Folha de Pagamento</param>
        /// <returns>Retorna ((FolhadePagamento * 0.08M) * 12)</returns>
        public decimal Ant_EncargoSocialAnual(decimal VlrFolha)
        {
            return (VlrFolha * 0.080M) * 12;
        }

        /// <summary>
        /// Metodo para o calculo do lucro anual.
        /// </summary>
        /// <param name="FaturamentoAnual">Valor referente ao calculo para o faturamento anual.</param>
        /// <param name="VlrCustosAnual">Valor referente ao calculo para o custos anual.</param>
        /// <param name="VlrDespesasAnual">Valor referente ao calculo para a despesa anual.</param>
        /// <param name="VlrFolhaAnual"> Valor referente ao calculo para a folha anual.</param>
        /// <param name="VlrEncargosAnual"> Valor referente ao calculo para o encargo social anual.</param>
        /// <param name="VlrMedioImpostosAnual"> Valor referente ao calculo para os impostos anual.</param>
        /// <returns> Retorna ((FaturamentoAnual - VlrCustosAnual - VlrDespesasAnual - VlrFolhaAnual - VlrEncargosAnual - VlrMedioImpostosAnual))</returns>
        public decimal Ant_LucroAnual(decimal FaturamentoAnual, decimal VlrCustosAnual, decimal VlrDespesasAnual, decimal VlrFolhaAnual, decimal VlrEncargosAnual, decimal VlrMedioImpostosAnual)
        {
            return (FaturamentoAnual - VlrCustosAnual - VlrDespesasAnual - VlrFolhaAnual - VlrEncargosAnual - VlrMedioImpostosAnual);
        }
        // FIM DOS CALCULOS PARA VALORES ANUAIS



        //CALCULOS DE DEPRECIAÇÃO
        /// <summary>
        /// Metodo para o calculo da Deprecicação de Veiculos Comuns.
        /// </summary>
        /// <param name="ValortotaldaFrota"> Valor de entrada referente ao total de veiculos na frota</param>
        /// <param name="ValordaFrotaemAutomoveis">Valor em PORCENTAGEM referente a quota de carros comuns na frota</param>
        /// <returns> Retorna (ValortotaldaFrota * (ValordaFrotaemAutomoveis /*percentual*/ * 0.20M)) </returns>
        public decimal DepreciacaoAutomoveis(decimal ValortotaldaFrota, decimal ValordaFrotaemAutomoveis)
        {
            return (ValortotaldaFrota * ((ValordaFrotaemAutomoveis/100) /*percentual*/ * 0.20M));
        }

        /// <summary>
        /// Metodo para o calculo de Deprecicação de Veiculos Utilitarios.
        /// </summary>
        /// <param name="ValortotaldaFrota"> Valor de entrada referente ao total de veiculos na frota</param>
        /// <param name="ValordaFrotaemUtilitarios">Valor em PORCENTAGEM  referente a quota de carros utilitarios na frota</param>
        /// <returns> Retorna (ValortotaldaFrota * (ValordaFrotaemUtilitarios /*percentual*/ * 0.25M))</returns>
        public decimal DeprecicacaoUtilitarios(decimal ValortotaldaFrota, decimal ValordaFrotaemUtilitarios)
        {
            return (ValortotaldaFrota * ((ValordaFrotaemUtilitarios/100) /*percentual*/ * 0.250M));
        }

        /// <summary>
        /// Metodo que realiza a soma das depreciações de frota.
        /// </summary>
        /// <param name="DepreciacaoAutomoveis"> Valor referente ao metodo DepreciacaoAutomoveis. </param>
        /// <param name="DeprecicacaoUtilitarios"> Valor referente ao metodo DeprecicacaoUtilitarios.</param>
        /// <returns> Retorna (DepreciacaoAutomoveis + DeprecicacaoUtilitarios)</returns>
        public decimal DespesaTotalcomDeprecicacao(decimal DepreciacaoAutomoveis, decimal DeprecicacaoUtilitarios)
        {
            var RESULTADO = DepreciacaoAutomoveis + DeprecicacaoUtilitarios;
            return RESULTADO;
        }
        // FIM DOS CALCULOS DE DEPRECIAÇÃO



        // CALCULOS DE FOLHA
        /// <summary>
        /// Metodo para calculo dos encargos socias mensais.
        /// </summary>
        /// <param name="Folha">Parametro Valor da Folha de Pagamento</param>
        /// <returns>Retorna (Folha * 0.08)</returns>
        public decimal EncargosSociaisMensais(decimal Folha)
        {
            return Folha * 0.08M;
        }
        /// <summary>
        /// Metodo para o calculo dos Impostos Anuais.
        /// </summary>
        /// <param name="ValorFolhaAnual"> Valor referente ao metodo de folha de pagamento anual.</param>
        /// <returns> Retorna (ValorFolhaAnual * 0.3580m)</returns>
        public decimal ImpostosFolha(decimal ValorFolhaAnual)
        {
            return ValorFolhaAnual * 0.3580m;
        }
        // FIM DOS CALCULOS DE FOLHA



        //CALCULO LUCRO MENSAL
        /// <summary>
        /// Metodo para o calculo do Lucro Mensal.
        /// </summary>
        /// <param name="FaturamentoMensal"> Valor referente ao faturamento da empresa.</param>
        /// <param name="Valormediomensaldoscustos"> Valor referente a media mensal de custos da empresa.</param>
        /// <param name="ValorMedioMensaldasdespesas"> Valor referente a media mensal de despesas da empresa.</param>
        /// <param name="Folhadepagamentodesalarios"> Valor referente ao valor da folha de pagamento</param>
        /// <param name="Encargossociais"> Valor referente ao calculo realizado pelo Metodo EncargosSociaisMensais</param>
        /// <param name="Valormediomensaldosimpostos"> Valor referente a media mensal de impostos</param>
        /// <returns> Retorna (FaturamentoMensal - Valormediomensaldoscustos - ValorMedioMensaldasdespesas - Folhadepagamentodesalarios - Encargossociais - Valormediomensaldosimpostos)</returns>
        public decimal Ant_LucroMensal(decimal FaturamentoMensal, decimal Valormediomensaldoscustos, decimal ValorMedioMensaldasdespesas, decimal Folhadepagamentodesalarios, decimal Encargossociais, decimal Valormediomensaldosimpostos)
        {
            return (FaturamentoMensal - Valormediomensaldoscustos - ValorMedioMensaldasdespesas - Folhadepagamentodesalarios - Encargossociais - Valormediomensaldosimpostos);
        }
        public decimal Ant_LucroAnual(decimal Ant_LucroMensal)
        {
            return Ant_LucroMensal * 12;
        }
        // FIM DO CALCULO LUCRO MENSAL


        //CALCULO DO PIS
        /// <summary>
        /// Metodo que realiza calculo referente ao Débito de PIS de aliquota 1,65%
        /// </summary>
        /// <param name="FaturamentoAnual"> Valor referente ao metodo de faturamento anual.</param>
        /// <returns>Retorna (FaturamentoAnual * 1.650m)</returns>
        public decimal PisDebito(decimal FaturamentoAnual)
        {
            return FaturamentoAnual * 1.650m;
        }

        /// <summary>
        /// Metodo para o calculo referente ao Crédito de PIS;
        /// </summary>
        /// <param name="DespesaTotalcomDeprecicacao"> Valor referente ao metodo de Despesas totais com depreciação</param>
        /// <param name="VlrCustosAnual"> Valor referente ao metodo de Custos totais anual.</param>
        /// <returns>Retorna ((DespesaTotalcomDeprecicacao + VlrCustosAnual) * 1.650M)</returns>
        public decimal PisCredito(decimal DespesaTotalcomDeprecicacao, decimal VlrCustosAnual)
        {
            return (DespesaTotalcomDeprecicacao + VlrCustosAnual) * 1.650M;
        }
        //FIM DO CALCULO DO PIS


        //CALCULO DO COFINS
        /// <summary>
        /// Metodo que realiza calculo referente ao Débito de COFINS de aliquota 7,60%
        /// </summary>
        /// <param name="FaturamentoAnual"> Valor referente ao metodo de faturamento anual.</param>
        /// <returns>Retorna (FaturamentoAnual * 7.60m)</returns>
        public decimal CofinsDebito(decimal FaturamentoAnual)
        {
            return FaturamentoAnual * 7.60m;
        }

        /// <summary>
        /// Metodo para o calculo referente ao Crédito de COFINS;
        /// </summary>
        /// <param name="DespesaTotalcomDeprecicacao"> Valor referente ao metodo de Despesas totais com depreciação</param>
        /// <param name="VlrCustosAnual"> Valor referente ao metodo de Custos totais anual.</param>
        /// <returns>Retorna ((DespesaTotalcomDeprecicacao + VlrCustosAnual) * 7.60M)</returns>
        public decimal CofinsCredito(decimal DespesaTotalcomDeprecicacao, decimal VlrCustosAnual)
        {
            return (DespesaTotalcomDeprecicacao + VlrCustosAnual) * 7.60M;
        }
        //FIM DO CALCULO DO COFINS

        //IMPOSTOS A RECOLHER (PENDENTE)
        public decimal VlrRecolherPis(decimal PisDebito, decimal PisCredito)
        {
            return PisDebito-PisCredito;
        }
        public decimal VlrRecolherConfins(decimal CofinsDebito, decimal CofinsCredito)
        {
            return CofinsDebito - CofinsCredito;
        }
        public decimal VlrAnualAproxdeImpostos(decimal VlrRecolherPis, decimal VlrRecolherConfins)
        {
            return VlrRecolherConfins + VlrRecolherPis;
        }
        public decimal VlrAnualAproxImpostosPorcentagem(decimal VlrAnualAproxdeImpostos, decimal FaturamentoAnual)
        {
            return VlrAnualAproxdeImpostos / FaturamentoAnual;
        }
        //FIM DOS IMPOSTOS A RECOLHER (PENDENTE)


        //CALCULO DE LUCRO NOVO REGIME //CALCULO DE VANTAGENS
        public decimal NovoLucroAnual(decimal FaturamentoAnual, decimal VlrCustosAnual, decimal VlrDespesasAnual, decimal VlrFolhaAnual, decimal ImpostosFolha, decimal VlrAnualAproxdeImpostos)
        {
            return FaturamentoAnual - VlrCustosAnual - VlrDespesasAnual - VlrFolhaAnual - ImpostosFolha - VlrAnualAproxdeImpostos;
        }

        public decimal EconomiaTributariaAno(decimal VlrAnualAproxdeImpostos, decimal ImpostosFolha, decimal Ant_VlrMedioImpostosAnual, decimal Ant_EncargoSocialAnual)
        {
            return (Ant_VlrMedioImpostosAnual + Ant_EncargoSocialAnual) - (VlrAnualAproxdeImpostos + ImpostosFolha);
        }
        public decimal AumentodaLucratividadeAno(decimal NovoLucroAnual, decimal Ant_LucroAnual)
        {
            return NovoLucroAnual - Ant_LucroAnual;
        }
        //FIM DO CALCULO DE VANTAGENS




        //CALCULO DO GANHO DE CAPITAL
        /// <summary>
        /// Metodo que calcula o valor medio dos veiculos presente na frota.
        /// </summary>
        /// <param name="VlrdaFrota">Valor referente ao valor total da frota de veiculos.</param>
        /// <param name="QuantidadeVeiculos">Valor referente ao numero total de veiculos na frota</param>
        /// <returns> Retorna (VlrdaFrota / QuantidadeVeiculos)</returns>
        private decimal ValorMedioVeiculos(decimal VlrdaFrota, int QuantidadeVeiculos)
        {
            return VlrdaFrota / QuantidadeVeiculos;
        }

        /// <summary>
        /// Metodo que calcula a depreciacao (por veiculo.
        /// </summary>
        /// <param name="ValorMedioVeiculo">Valor referente ao metodo ValorMedioVeiculos</param>
        /// <param name="Desvalorizacao"> Valor referente a porcentagem de desvalorização do veiculo na frota</param>
        /// <param name="TempodePermanencia">  Valor referente ao tempo de permanencia do veiculo na frota</param>
        /// <returns>Retorna (((ValorMedioVeiculo * Desvalorizacao) / 12) * TempodePermanencia)</returns>
        private decimal DepreciacaoporVeiculo(decimal ValorMedioVeiculo,int Desvalorizacao, int TempodePermanencia )
        {
            
            return ((ValorMedioVeiculo * Desvalorizacao) / 12) * TempodePermanencia;
        }

        /// <summary>
        /// Metodo para calcular o saldo do veiculo depreciado
        /// </summary>
        /// <param name="ValorMedioVeiculos"> Valor referente ao metodo ValorMedioVeiculos</param>
        /// <param name="DepreciacaoporVeiculo">Valor referente ao metodo DepreciacaoporVeiculo</param>
        /// <returns>Retorna (ValorMedioVeiculos - DepreciacaoporVeiculo) </returns>
        private decimal SaldoVeiculoDepreciado(decimal ValorMedioVeiculos, decimal DepreciacaoporVeiculo)
        {
            return ValorMedioVeiculos - DepreciacaoporVeiculo;
        }

        /// <summary>
        /// Metodo para calcular o valor estipulado de venda dos veiculos.
        /// </summary>
        /// <param name="ValorMedioVeiculos"> Valor referente ao metodo ValorMedioVeiculos</param>
        /// <param name="Desvalorizacao"> Valor referente a porcentaagem de desvalorização do veiculo</param>
        /// <returns>Retorna (ValorMedioVeiculos * (Desvalorizacao / 100))</returns>
        private decimal ValordaVenda(decimal ValorMedioVeiculos, int Desvalorizacao)
        {
            return ValorMedioVeiculos * (Desvalorizacao / 100);
        }
        //FIM DO CALCULO DO GRANHO DE CAPITAL (PENDENTE)




    }
}
