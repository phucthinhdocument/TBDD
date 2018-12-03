using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileStudentController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddProfileStudent")]
        public IActionResult Create([FromBody] ProfileStudent _ProfileStudent)
        {
            try{
            _ProfileStudent.ProfileId = Guid.NewGuid() + "";
            context.ProfileStudent.Add(_ProfileStudent);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchProfileStudent/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.ProfileStudent.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.ProfileStudent.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteProfileStudent/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.ProfileStudent.Find(id)==null){
                return Ok("null");
            }else{
                context.ProfileStudent.Remove(context.ProfileStudent.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateProfileStudent/{id}")]
        public IActionResult Update(string id, [FromBody] ProfileStudent _ProfileStudent)
        {
             var tEntity= context.ProfileStudent.FirstOrDefault(e => e.ProfileId.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.Address=_ProfileStudent.Address;
                    tEntity.DepartmentId=_ProfileStudent.ClassId;
                     tEntity.Email=_ProfileStudent.DepartmentId;
                      tEntity.ClassId=_ProfileStudent.Email;
                       tEntity.PhoneNumber=_ProfileStudent.PhoneNumber;
                      
                    
                    context.ProfileStudent.Update(tEntity);
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
        [Route("ReadListProfileStudent/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<ProfileStudent>().
                       OrderBy(d => d.ProfileId).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListProfileStudent/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.ProfileStudent.
                       OrderBy(d => d.ProfileId).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListProfileStudent")]
        public IActionResult CountAll()
        {
            return Ok(context.ProfileStudent.Count());
        }

    }
}
