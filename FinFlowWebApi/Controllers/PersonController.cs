using BusinessLogic.DataBase;
using Models;
using Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinFlowWebApi.Controllers
{
    public class PersonController : ApiController
    {
        IRepositoryPerson repositoryPerson = InstanceDB.getInstancePerson();
        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        public ResultPerson Get(int person_id)
        {
            ResultPerson resultPerson = new ResultPerson();
            resultPerson = repositoryPerson.getPerson(person_id);
            return resultPerson;
        }

        // POST: api/Person
        public ResultPerson Post([FromBody]Person newPerson)
        {//create
            ResultPerson resultPerson = new ResultPerson();
            resultPerson = repositoryPerson.addPerson(newPerson);
            return resultPerson;
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {//edit
        }

        // DELETE: api/Person/5
        public Result Delete(int person_id)
        {
            Result resultDeletePerson = new Result();

            if (person_id <= 0)
            {
                resultDeletePerson.code = -1;
                resultDeletePerson.error = "Неверные входные параметры";
                return resultDeletePerson;
            }

            resultDeletePerson = repositoryPerson.deletePerson(person_id);

            return resultDeletePerson;

        }
    }
}
