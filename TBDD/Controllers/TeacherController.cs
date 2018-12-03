using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddTeacher")]
        public IActionResult Create([FromBody] Teacher _Teacher)
        {
            try{
            _Teacher.TeacherId = Guid.NewGuid() + "";
            context.Teacher.Add(_Teacher);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchTeacher/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.Teacher.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.Teacher.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.Teacher.Find(id)==null){
                return Ok("null");
            }else{
                context.Teacher.Remove(context.Teacher.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateTeacher/{id}")]
        public IActionResult Update(string id, [FromBody] Teacher _Teacher)
        {
             var tEntity= context.Teacher.FirstOrDefault(e => e.TeacherId.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.ProfileId=_Teacher.ProfileId;
                   
                    context.Teacher.Update(tEntity);
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
        [Route("ReadListTeacher/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<Teacher>().
                       OrderBy(d => d.TeacherId).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListTeacher/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.Teacher.
                       OrderBy(d => d.TeacherId).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListTeacher")]
        public IActionResult CountAll()
        {
            return Ok(context.Teacher.Count());
        }

    }
}
