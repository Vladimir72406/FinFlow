using Models;
using Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase
{
    public interface IRepositoryPerson
    {
        ResultPerson addPerson(Person newPerson);

        Result updatePerson(Person modifiedPerson);

        Result deletePerson(int deletedPerson);

        ResultPerson getPerson(int person_id);

    }
}
