using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddContact")]
        public IActionResult Create([FromBody] Contact _Contact)
        {
            try{
            _Contact.Id = Guid.NewGuid() + "";
            context.Contact.Add(_Contact);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchContact/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.Contact.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.Contact.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.Contact.Find(id)==null){
                return Ok("null");
            }else{
                context.Contact.Remove(context.Contact.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateContact/{id}")]
        public IActionResult Update(string id, [FromBody] Contact _Contact)
        {
             var tEntity= context.Contact.FirstOrDefault(e => e.Id.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.Title=_Contact.Title;
                    tEntity.Content=_Contact.Content;
                     tEntity.StudentId=_Contact.StudentId;
                      tEntity.SubjectId=_Contact.SubjectId;
                    
                    context.Contact.Update(tEntity);
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
        [Route("ReadListContact/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<Contact>().
                       OrderBy(d => d.Id).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListContact/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.Contact.
                       OrderBy(d => d.Id).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListContact")]
        public IActionResult CountAll()
        {
            return Ok(context.Contact.Count());
        }

    }
}
