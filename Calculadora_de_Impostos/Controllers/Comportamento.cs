using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora_de_Impostos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calculadora_de_Impostos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Comportamento : ControllerBase
    {
        //// GET: api/<Comportamento>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<Comportamento>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Comportamento>
        [HttpPost]
        public IActionResult Post([FromBody]Parametros parametros)
        {
            if (parametros.Metodo != "get")
            {
                return BadRequest("Metodo não implementado");
                
            }
            if (parametros.NumFrota == 0 || parametros.RegimeTribuatrio =="" || parametros.NumFrota == 0 || parametros.VlrFrotaTotal == 0 || parametros.TempoPermanencia == 0 || parametros.Desvalorizacao == 0 || parametros.FaturamentoMensal == 0 || (parametros.PerfilAutomoveis + parametros.PerfilUtilitarios) >100  || parametros.VlrCustosMensal == 0 || parametros.VlrDespesasMensal == 0 || parametros.VlrFolha == 0 || parametros.VlrImpostosMensal == 0 )
            {
                return BadRequest("Parametros fora do Padrão!");
            }
            Calculos c = new Calculos();

            var FaturamentoAnual = c.FaturamentoAnual(parametros.FaturamentoMensal);
            var VlrCustosAnual = c.VlrCustosAnual(parametros.VlrCustosMensal);
            var VlrDespesasAnual = c.VlrDespesasAnual(parametros.VlrDespesasMensal);
            var VlrFolhaAnual = c.VlrFolhaAnual(parametros.VlrFolha);
            var Ant_EncargoSocialAnual = c.Ant_EncargoSocialAnual(parametros.VlrFolha);
            var Ant_VlrMedioImpostosAnual = c.Ant_VlrMedioImpostosAnual(parametros.VlrImpostosMensal);
            var Ant_LucroAnual = c.Ant_LucroAnual(FaturamentoAnual, VlrCustosAnual, VlrDespesasAnual, VlrFolhaAnual, Ant_EncargoSocialAnual, Ant_VlrMedioImpostosAnual);
            var DepreciacaoAutomoveis = c.DepreciacaoAutomoveis(parametros.VlrFrotaTotal, parametros.PerfilAutomoveis);
            var DepreciacaoUtilitarios = c.DeprecicacaoUtilitarios(parametros.VlrFrotaTotal, parametros.PerfilUtilitarios);
            var DespesaTotalcomDeprecicacao = c.DespesaTotalcomDeprecicacao(DepreciacaoAutomoveis, DepreciacaoUtilitarios);
            var ImpostosFolha = c.ImpostosFolha(VlrFolhaAnual);
            var PisDebito = c.PisDebito(parametros.FaturamentoMensal);
            var PisCredito = c.PisCredito(DespesaTotalcomDeprecicacao, VlrCustosAnual);
            var CofinsDebito = c.CofinsDebito(parametros.FaturamentoMensal);
            var CofinsCredito = c.CofinsCredito(DespesaTotalcomDeprecicacao, VlrCustosAnual);
            var VlrRecolherPis = c.VlrRecolherPis(PisDebito, PisCredito);
            var VlrRecolherConfins = c.VlrRecolherConfins(CofinsDebito, CofinsCredito);
            var VlrAnualAproxdeImpostos = c.VlrAnualAproxdeImpostos(VlrRecolherPis, VlrRecolherConfins);
            var VlrAnualAproxImpostosPorcentagem = c.VlrAnualAproxImpostosPorcentagem(VlrAnualAproxdeImpostos, FaturamentoAnual);
            var NovoLucroAnual = c.NovoLucroAnual(FaturamentoAnual, VlrCustosAnual, VlrDespesasAnual, VlrFolhaAnual, ImpostosFolha, VlrAnualAproxdeImpostos);
            var EconomiaTributariaAno = c.EconomiaTributariaAno(VlrAnualAproxdeImpostos, ImpostosFolha, Ant_VlrMedioImpostosAnual, Ant_EncargoSocialAnual);
            var AumentodaLucratividadeAno = c.AumentodaLucratividadeAno(NovoLucroAnual, Ant_LucroAnual);




            return Ok($"FaturamentoAnual:{FaturamentoAnual}, VlrCustosAnual: {VlrCustosAnual}, VlrDespesasAnual:{VlrDespesasAnual}");
                 


            
                
                        //VlrFolhaAnual 
                        //Ant_EncargoSocialAnual 
                        //Ant_VlrMedioImpostosAnual
                        //Ant_LucroAnual 
                        //DepreciacaoAutomoveis 
                        //DepreciacaoUtilitarios 
                        //DespesaTotalcomDeprecicacao
                        //ImpostosFolha
                        //PisDebito
                        //PisCredito
                        //CofinsDebito
                        //CofinsCredito
                        //VlrRecolherPis
                        //VlrRecolherConfins
                        //VlrAnualAproxdeImpostos
                        //VlrAnualAproxImpostosPorcentagem
                        //NovoLucroAnual
                        //EconomiaTributariaAno
                        //AumentodaLucratividadeAno 
               
               

            //var resultado = c.DespesaTotalcomDeprecicacao();
            //if (resultado <= 0)
            //{
            //    return BadRequest("Parametros incorretos. O calculo não foi preciso!");
            //}
            //return Ok ($"O valor do lucro anual é: {resultado}");

        }

        //// PUT api/<Comportamento>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Comportamento>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
