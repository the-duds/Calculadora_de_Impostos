using Calculadora_de_Impostos.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Calculadora_de_Impostos
{
    public class SimplesNacional
    {
        protected Parametros parametros;

        public SimplesNacional(Parametros parametros)
        {
            this.parametros = parametros;
        }
        public object SimplesN()
        {
            Calculos c = new Calculos();
            var i = new Indicadores();
            i.FaturamentoAnual = c.FaturamentoAnual(parametros.FaturamentoMensal);
            i.VlrCustosAnual = c.VlrCustosAnual(parametros.VlrCustosMensal);
            i.VlrDespesasAnual = c.VlrDespesasAnual(parametros.VlrDespesasMensal);
            i.VlrFolhaAnual = c.VlrFolhaAnual(parametros.VlrFolha);
            i.Ant_EncargoSocialAnual = c.Ant_EncargoSocialAnual(parametros.VlrFolha);
            i.Ant_VlrMedioImpostosAnual = c.Ant_VlrMedioImpostosAnual(parametros.VlrImpostosMensal);
            i.Ant_LucroAnual = c.Ant_LucroAnual(i.FaturamentoAnual, i.VlrCustosAnual, i.VlrDespesasAnual, i.VlrFolhaAnual, i.Ant_EncargoSocialAnual, i.Ant_VlrMedioImpostosAnual);
            i.DepreciacaoAutomoveis = c.DepreciacaoAutomoveis(parametros.VlrFrotaTotal, parametros.PerfilAutomoveis);
            i.DepreciacaoUtilitarios = c.DeprecicacaoUtilitarios(parametros.VlrFrotaTotal, parametros.PerfilUtilitarios);
            i.DespesaTotalcomDeprecicacao = c.DespesaTotalcomDeprecicacao(i.DepreciacaoAutomoveis, i.DepreciacaoUtilitarios);
            i.ImpostosFolha = c.ImpostosFolha(i.VlrFolhaAnual);
            i.PisDebito = c.PisDebito(i.FaturamentoAnual);
            i.PisCredito = c.PisCredito(i.DespesaTotalcomDeprecicacao, i.VlrCustosAnual);
            i.CofinsDebito = c.CofinsDebito(i.FaturamentoAnual);
            i.CofinsCredito = c.CofinsCredito(i.DespesaTotalcomDeprecicacao, i.VlrCustosAnual);
            i.VlrRecolherPis = c.VlrRecolherPis(i.PisDebito, i.PisCredito);
            i.VlrRecolherConfins = c.VlrRecolherConfins(i.CofinsDebito, i.CofinsCredito);
            i.VlrAnualAproxdeImpostos = c.VlrAnualAproxdeImpostos(i.VlrRecolherPis, i.VlrRecolherConfins);
            i.VlrAnualAproxImpostosPorcentagem = c.VlrAnualAproxImpostosPorcentagem(i.VlrAnualAproxdeImpostos, i.FaturamentoAnual);
            i.NovoLucroAnual = c.NovoLucroAnual(i.FaturamentoAnual, i.VlrCustosAnual, i.VlrDespesasAnual, i.VlrFolhaAnual, i.ImpostosFolha, i.VlrAnualAproxdeImpostos);
            i.EconomiaTributariaAno = c.EconomiaTributariaAno(i.VlrAnualAproxdeImpostos, i.ImpostosFolha, i.Ant_VlrMedioImpostosAnual, i.Ant_EncargoSocialAnual);
            i.AumentodaLucratividadeAno = c.AumentodaLucratividadeAno(i.NovoLucroAnual, i.Ant_LucroAnual, i.EconomiaTributariaAno);


            i.Resultado = $"FaturamentoAnual: {i.FaturamentoAnual} ; VlrCustosAnual: {i.VlrCustosAnual} ; VlrDespesasAnual: {i.VlrDespesasAnual} ; " +
                        $"VlrFolhaAnual: {i.VlrFolhaAnual} ; Ant_EncargoSocialAnual: {i.Ant_EncargoSocialAnual} ; Ant_VlrMedioImpostosAnual: {i.Ant_VlrMedioImpostosAnual} , " +
                        $"Ant_LucroAnual: {i.Ant_LucroAnual} ; DepreciacaoAutomoveis: {i.DepreciacaoAutomoveis} ; DepreciacaoUtilitarios: {i.DepreciacaoUtilitarios} ; " +
                        $"DespesaTotalcomDeprecicacao: {i.DespesaTotalcomDeprecicacao}; ImpostosFolha: {i.ImpostosFolha} ; PisDebito{i.PisDebito} ; PisCredito{i.PisCredito};" +
                        $"CofinsDebito: {i.CofinsDebito} ; CofinsCredito:{i.CofinsCredito}; VlrRecolherPis: {i.VlrRecolherPis} ; VlrRecolherConfins: {i.VlrRecolherConfins} ; " +
                        $"VlrAnualAproxdeImpostos: {i.VlrAnualAproxdeImpostos} ; VlrAnualAproxImpostosPorcentagem: {i.VlrAnualAproxImpostosPorcentagem} ; " +
                        $"NovoLucroAnual: {i.NovoLucroAnual} ; EconomiaTributariaAno: {i.EconomiaTributariaAno} ; AumentodaLucratividadeAno: {i.AumentodaLucratividadeAno} ;";
            List<string> resu = new List<string>();
            resu.AddRange(i.Resultado.Split(";"));

            return resu;
        }
    }



}
