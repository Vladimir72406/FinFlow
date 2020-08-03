using Models;
using Models.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase.MSSQLEF
{
    class RepositoryPerson : IRepositoryPerson
    {
        public ResultPerson addPerson(Person newPerson)
        {
            ResultPerson resultPerson = new ResultPerson();
            int code = 0;
            string str_result = "";
            FinflowEntities ge = new FinflowEntities();

            ObjectParameter sp_objectParam_person_id = new ObjectParameter("person_id", newPerson.person_id);
            ObjectParameter sp_objectParam_code = new ObjectParameter("code", code);
            ObjectParameter sp_objectParam_str_result = new ObjectParameter("str_result", code);

            ge.iud_person(  1,
                            sp_objectParam_person_id,
                            newPerson.Name,
                            newPerson.Surname,
                            newPerson.DateOfBirth,
                            sp_objectParam_code,
                            sp_objectParam_str_result);
            
            code = Convert.ToInt32(sp_objectParam_code.Value);
            str_result = Convert.ToString(sp_objectParam_str_result.Value);

            if (code < 0)
            {
                resultPerson.code = -1;
                resultPerson.error = str_result;
            }
            else
            {
                resultPerson.code = 0;
                resultPerson.error = "";
                newPerson.person_id = Convert.ToInt32(sp_objectParam_person_id.Value);
            }
            
            return resultPerson;
        }

        public Result deletePerson(int _person_id)
        {
            ResultPerson resultPerson = new ResultPerson();
            int code = 0;
            string str_result = "";
            FinflowEntities ge = new FinflowEntities();

            ge.iud_person(3,
                            new ObjectParameter("person_id", _person_id),
                            null,
                            null,
                            null,
                            new ObjectParameter("code", code),
                            new ObjectParameter("str_result", str_result));

            if (code < 0)
            {
                resultPerson.code = -1;
                resultPerson.error = str_result;
            }
            else
            {
                resultPerson.code = 0;
                resultPerson.error = "ok";
            }

            return resultPerson;
        }

        public ResultPerson getPerson(int person_id)
        {
            get_person_Result pers;
            ResultPerson resultPerson = new ResultPerson();
            Person searchedPerson;

            FinflowEntities fe = new FinflowEntities();
                        
            var dataResultStoredProcedure = fe.get_person(person_id).GetEnumerator();

            if (dataResultStoredProcedure.MoveNext())
            {
                pers = dataResultStoredProcedure.Current;

                if (pers != null)
                {
                    searchedPerson = new Person();
                    searchedPerson.person_id = pers.person_id;
                    searchedPerson.Name = pers.Name;
                    searchedPerson.Surname = pers.Surname;
                    searchedPerson.DateOfBirth = pers.DateOfBirth;

                    resultPerson.person = searchedPerson;
                    resultPerson.code = 0;
                }
            }
            else
            {
                resultPerson.code = -1;
                resultPerson.error = "Запись не найдена.";
            }
            
            return resultPerson;
        }
        
        public Result updatePerson(Person modifiedPerson)
        {
            ResultPerson resultPerson = new ResultPerson();
            int code = 0;
            string str_result = "";
            FinflowEntities ge = new FinflowEntities();

            ge.iud_person(2,
                            new ObjectParameter("person_id", modifiedPerson.person_id),
                            modifiedPerson.Name,
                            modifiedPerson.Surname,
                            modifiedPerson.DateOfBirth,
                            new ObjectParameter("code", code),
                            new ObjectParameter("str_result", str_result));

            if (code < 0)
            {
                resultPerson.code = -1;
                resultPerson.error = str_result;
            }
            else
            {
                resultPerson.code = 0;
                resultPerson.error = "ok";
            }

            return resultPerson;
        }
    }
}
