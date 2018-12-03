using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendanceRollCallController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddAttendanceRollCall")]
        public IActionResult Create([FromBody] AttendanceRollCall _AttendanceRollCall)
        {
            try{
            _AttendanceRollCall.Id = Guid.NewGuid() + "";
            context.AttendanceRollCall.Add(_AttendanceRollCall);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchAttendanceRollCall/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.AttendanceRollCall.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.AttendanceRollCall.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteAttendanceRollCall/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.AttendanceRollCall.Find(id)==null){
                return Ok("null");
            }else{
                context.AttendanceRollCall.Remove(context.AttendanceRollCall.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateAttendanceRollCall/{id}")]
        public IActionResult Update(string id, [FromBody] AttendanceRollCall _AttendanceRollCall)
        {
             var tEntity= context.AttendanceRollCall.FirstOrDefault(e => e.Id.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.CheckAttendance=_AttendanceRollCall.CheckAttendance;
                    tEntity.DateCheck=_AttendanceRollCall.DateCheck;
                     tEntity.RegisterId=_AttendanceRollCall.RegisterId;
                     
                    
                    context.AttendanceRollCall.Update(tEntity);
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
        [Route("ReadListAttendanceRollCall/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<AttendanceRollCall>().
                       OrderBy(d => d.Id).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListAttendanceRollCall/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.AttendanceRollCall.
                       OrderBy(d => d.Id).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListAttendanceRollCall")]
        public IActionResult CountAll()
        {
            return Ok(context.AttendanceRollCall.Count());
        }

    }
}
