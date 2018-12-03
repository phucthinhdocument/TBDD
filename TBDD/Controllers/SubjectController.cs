using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddSubject")]
        public IActionResult Create([FromBody] Subject _Subject)
        {
            try{
            _Subject.SubjectId = Guid.NewGuid() + "";
            context.Subject.Add(_Subject);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchSubject/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.Subject.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.Subject.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteSubject/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.Subject.Find(id)==null){
                return Ok("null");
            }else{
                context.Subject.Remove(context.Subject.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateSubject/{id}")]
        public IActionResult Update(string id, [FromBody] Subject _Subject)
        {
             var tEntity= context.Subject.FirstOrDefault(e => e.SubjectId.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.SubjectName=_Subject.SubjectName;
                   
                    
                    context.Subject.Update(tEntity);
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
        [Route("ReadListSubject/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<Subject>().
                       OrderBy(d => d.SubjectId).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListSubject/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.Subject.
                       OrderBy(d => d.SubjectId).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListSubject")]
        public IActionResult CountAll()
        {
            return Ok(context.Subject.Count());
        }

    }
}
