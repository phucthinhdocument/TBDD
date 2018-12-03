using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TBDD.Model;

namespace TemplateWebApiPhucThinh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
       
       TBDDContext context =new TBDDContext();

       

        [HttpPost]
        [Route("AddNotification")]
        public IActionResult Create([FromBody] Notification _Notification)
        {
            try{
            _Notification.Id = Guid.NewGuid() + "";
            context.Notification.Add(_Notification);
            context.SaveChanges();
            return Ok(true);
            }catch{

                return Ok(false);
            };
            
           
        }
     

        [HttpGet]
        [Route("SearchNotification/{keyWord}")]
        
        public IActionResult GetById(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            return Ok("Empty");
            if(context.Notification.Find(keyWord)==null){
                return Ok("Null");
            }

            return Ok(context.Notification.Find(keyWord));
        }

        [HttpDelete]
        [Route("DeleteNotification/{id}")]
        public IActionResult Delete(string id)
        {
            if(context.Notification.Find(id)==null){
                return Ok("null");
            }else{
                context.Notification.Remove(context.Notification.Find(id));
                context.SaveChanges();
                return Ok("true");
            }
           
        }
        [HttpPut]
        [Route("UpdateNotification/{id}")]
        public IActionResult Update(string id, [FromBody] Notification _Notification)
        {
             var tEntity= context.Notification.FirstOrDefault(e => e.Id.Equals(id));
                
                
            if (tEntity != null)
            {
                try
                {
                   
                    tEntity.Title=_Notification.Title;
                    tEntity.Content=_Notification.Content;
                     tEntity.DateCreate=_Notification.DateCreate;
                      tEntity.SubjectId=_Notification.SubjectId;
                      tEntity.TeacherId=_Notification.TeacherId;
                      
                    
                    context.Notification.Update(tEntity);
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
        [Route("ReadListNotification/pagesize/pageNow")]
        public IActionResult Paging(int pageSize, int pageNow)
        {
            var qry = context.Set<Notification>().
                       OrderBy(d => d.Id).Skip((pageNow - 1) * pageSize).Take(pageSize).ToList();
           
           
            return Ok(qry);
        }
        [HttpGet]
        [Route("CountListNotification/pagesize/pageNow")]
         public IActionResult CountOfPaging(int pageSize, int pageNow)
        {
          int qry = context.Notification.
                       OrderBy(d => d.Id).Skip((pageNow - 1) * pageSize).Take(pageSize).Count();
                       return Ok(qry);
        }
        [HttpGet]
        [Route("CountAllListNotification")]
        public IActionResult CountAll()
        {
            return Ok(context.Notification.Count());
        }

    }
}
