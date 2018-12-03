using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddStudent")]
        public IActionResult Create([FromBody] Student _Student)
        {
            try{
            _Student.StudentId = Guid.NewGuid() + "";
            context.Student.Add(_Student);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchStudent/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.Student.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.Student.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.Student.Find(id)==null){
                return Ok("null");
            }else{
                context.Student.Remove(context.Student.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateStudent/{id}")]
        public IActionResult Update(string id, [FromBody] Student _Student)
        {
             var tEntity= context.Student.FirstOrDefault(e => e.StudentId.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.FaceId=_Student.FaceId;
                    tEntity.PersonId=_Student.PersonId;
                    tEntity.StudentId=_Student.StudentId;
                    
                    context.Student.Update(tEntity);
                    context.SaveChanges();
                    return Ok(true);
                }
                catch (Exception)
                {
                    return Ok(false);
                }
               
            }
            return Ok(false);
           
        }
        [HttpGet]
        [Route("ReadListStudent/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<Student>().
                       OrderBy(d => d.StudentId).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListStudent/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.Student.
                       OrderBy(d => d.StudentId).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListStudent")]
        public IActionResult CountAll()
        {
            return Ok(context.Student.Count());
        }

    }
}
