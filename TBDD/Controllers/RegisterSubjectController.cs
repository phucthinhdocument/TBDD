using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterSubjectController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddRegisterSubject")]
        public IActionResult Create([FromBody] RegisterSubject _RegisterSubject)
        {
            try{
            _RegisterSubject.RegisterId = Guid.NewGuid() + "";
            context.RegisterSubject.Add(_RegisterSubject);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchRegisterSubject/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.RegisterSubject.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.RegisterSubject.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteRegisterSubject/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.RegisterSubject.Find(id)==null){
                return Ok("null");
            }else{
                context.RegisterSubject.Remove(context.RegisterSubject.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateRegisterSubject/{id}")]
        public IActionResult Update(string id, [FromBody] RegisterSubject _RegisterSubject)
        {
             var tEntity= context.RegisterSubject.FirstOrDefault(e => e.RegisterId.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.DateEnd=_RegisterSubject.DateEnd;
                    tEntity.DateStart=_RegisterSubject.DateStart;
                     tEntity.StudentId=_RegisterSubject.StudentId;
                      tEntity.SubjectId=_RegisterSubject.SubjectId;
                      tEntity.TeacherId=_RegisterSubject.SubjectId;
                    
                    context.RegisterSubject.Update(tEntity);
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
        [Route("ReadListRegisterSubject/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<RegisterSubject>().
                       OrderBy(d => d.RegisterId).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListRegisterSubject/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.RegisterSubject.
                       OrderBy(d => d.RegisterId).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListRegisterSubject")]
        public IActionResult CountAll()
        {
            return Ok(context.RegisterSubject.Count());
        }

    }
}
