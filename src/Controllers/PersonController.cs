using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using src.Models;
using src.Persistence;


namespace src.Controllers
{

    [ApiController]
    [Route("MyFirstAPI/[controller]")]
   

    public class PersonController : ControllerBase{

        private DataBaseContext _repository { get; set; }  //por convenção underline na frente indica que este é privado

        public PersonController(DataBaseContext repository)
        {
            this._repository = repository;
        }

        [HttpGet]    //requisicao HTTP que consulta/busca informacoes no DB
        public ActionResult<List<Person>> Get(){

            if (!_repository.PersonTable.Any<Person>())
            {
                return NoContent();
            }
     
            return _repository.PersonTable.Include(p => p.Contracts).ToList();  // Include é para que o atributo contratos (que é um array) tbm apareça no GET. Pelo contrário só listaria os atributos simples da do DBSet PersonTable.
        }

        [HttpPost]    //requisicao HTTP que salva novos conteúdos no DB

        public ActionResult<object> Post(Person pessoa)
        {
            _repository.PersonTable.Add(pessoa);
            _repository.SaveChanges();

            return Ok(new {
                msg = "Objeto criado e salvo com sucesso!",
                status = HttpStatusCode.OK
            });
        }


        [HttpPut]     //requisicao HTTP que atualiza conteúdos no DB

        public ActionResult<object> Update(int ID, Person person){

            try
            {
                _repository.PersonTable.Update(person);
                _repository.SaveChanges();
            }
            catch (System.Exception)
            {
                return BadRequest(new {
                    msg = $"ID {ID} não encontrado. Favor fornecer um ID válido",
                    status = HttpStatusCode.BadRequest
                });
            }            
    
            return Ok(new {
                msg = $"Dados do ID {ID} atualizados.",
                status = HttpStatusCode.OK
            });            
        }


        [HttpDelete]

        public ActionResult<object> Delete(int ID, Person person){  //ActionResult é nativo do .Net para retornar os status HTTP. NO caso está retornando um objeto (criado dentro do OK, lá no return)

            var PersonID = _repository.PersonTable.SingleOrDefault(p => p.ID == ID);

            if (PersonID == null)
            {
                return BadRequest(new {
                    msg = $"ID {ID} não encontrado. Favor fornecer um ID válido",
                    status = HttpStatusCode.BadRequest
                });
            }

            _repository.PersonTable.Remove(PersonID);
            _repository.SaveChanges();

            return Ok(new {
                msg = $"O ID {ID} foi deletado com sucesso!",
                status = HttpStatusCode.OK
            });
        }

    }
}