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
            if (parametros.NumFrota <= 0 || parametros.RegimeTribuatrio =="" || parametros.NumFrota <= 0 || parametros.VlrFrotaTotal <= 0 || parametros.TempoPermanencia <= 0 || parametros.Desvalorizacao <= 0 || parametros.FaturamentoMensal <= 0 || (parametros.PerfilAutomoveis + parametros.PerfilUtilitarios) >100  || parametros.VlrCustosMensal <= 0 || parametros.VlrDespesasMensal <= 0 || parametros.VlrFolha <= 0 || parametros.VlrImpostosMensal <= 0 )
            {
                return BadRequest("Parametros fora do Padrão!");
            }
            switch (parametros.RegimeTribuatrio.ToUpper().Replace(" ",""))
            {
                case "SIMPLESNACIONAL":
                    SimplesNacional Simples = new SimplesNacional(parametros);
                    return Ok(new ObjectResult(Simples.SimplesN()));
                    
            }

            return BadRequest();

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
