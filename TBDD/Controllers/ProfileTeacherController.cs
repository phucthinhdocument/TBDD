using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileTeacherController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddProfileTeacher")]
        public IActionResult Create([FromBody] ProfileTeacher _ProfileTeacher)
        {
            try{
            _ProfileTeacher.ProfileId = Guid.NewGuid() + "";
            context.ProfileTeacher.Add(_ProfileTeacher);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchProfileTeacher/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.ProfileTeacher.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.ProfileTeacher.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteProfileTeacher/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.ProfileTeacher.Find(id)==null){
                return Ok("null");
            }else{
                context.ProfileTeacher.Remove(context.ProfileTeacher.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateProfileTeacher/{id}")]
        public IActionResult Update(string id, [FromBody] ProfileTeacher _ProfileTeacher)
        {
             var tEntity= context.ProfileTeacher.FirstOrDefault(e => e.ProfileId.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.Address=_ProfileTeacher.Address;
                    tEntity.DepartmentId=_ProfileTeacher.DepartmentId;
                     tEntity.Email=_ProfileTeacher.Email;
                      tEntity.PhoneNumber=_ProfileTeacher.PhoneNumber;
                       tEntity.Specialize=_ProfileTeacher.Specialize;
                    
                    context.ProfileTeacher.Update(tEntity);
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
        [Route("ReadListProfileTeacher/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<ProfileTeacher>().
                       OrderBy(d => d.ProfileId).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListProfileTeacher/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.ProfileTeacher.
                       OrderBy(d => d.ProfileId).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListProfileTeacher")]
        public IActionResult CountAll()
        {
            return Ok(context.ProfileTeacher.Count());
        }

    }
}
