using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batch_WebAPI1.Models;
using Attribute = Batch_WebAPI1.Models.Attribute;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Batch.Controllers
{


   
    [Route("/")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        BatchContext Context;
        public BatchController(BatchContext _db)
        {
            Context = _db;
        }


       
        [HttpPost]
        [Route("~/batch")]
        public string batch(VwModel vw)
        {
            ErrorMsgClass errorObj = new ErrorMsgClass();
            Errors errors = new Errors();
           



            if (vw.BusinessUnit == "")
            {
                errorObj.CorrelationID = "400";
                errors.source = "AddbatchDeatils";
                errors.description = "business unit should not be blank";

                errorObj.errors = errors;
                return JsonConvert.SerializeObject(errorObj);
            }


            List<AttributeShow> lst = new List<AttributeShow>();
            lst = vw.attribute;


            if (lst.Count <= 0)
            {
              
                errorObj.CorrelationID = "400";
                errors.source = "AddbatchDeatils";
                errors.description = "attribute should not be blank.";
                errorObj.errors= errors;

              return  JsonConvert.SerializeObject(errorObj);

            }


            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Key == "" || lst[i].Value == "")
                { 
                    errorObj.CorrelationID = "400"; 
                    errors.source = "AddbatchDeatils";
                    errors.description = "Key and Value should not be blank.";
                    errorObj.errors= errors;
                    return  JsonConvert.SerializeObject(errorObj);
                   
                }
            }

            Guid obj = Guid.NewGuid();
            String batchId = obj.ToString();
            DateTime dt = new DateTime();
            dt = System.DateTime.Now;


            //save batchDetails
            var batchDtl = new BatchDetail()
            {
                BusinessUnit = vw.BusinessUnit,
                BatchId1 = batchId,
                BatchPublishDate = dt,
                ExpiryDate = vw.ExpiryDate


            };
            Context.BatchDetails.Add(batchDtl);




           for (int i = 0; i < lst.Count; i++)
          
            {
                var attribute = new Attribute()
                {
                    Key = lst[i].Key,
                    Value = lst[i].Value,
                    BatchId = batchId
                };

                Context.Attributes.Add(attribute);

            }

            //save ACL
            AclShow acl = new AclShow();
            acl = vw.acl;

            
           
            List<string> lstReadUsers = new List<string>();
            lstReadUsers = vw.acl.ReadUsers;

            for (int i = 0; i < lstReadUsers.Count; i++)
            {
                var acl1 = new Acl()
                {
                    
                    ReadUsers = lstReadUsers[i].ToString(),
                    BatchId = batchId
                };
                Context.Acls.Add(acl1);
            }


            List<string> lstReadGroups = new List<string>();
            lstReadGroups = vw.acl.ReadGroups;

            for (int i = 0; i < lstReadGroups.Count; i++)
            {
                var acl1 = new Acl()
                {
                   
                    ReadGroups = lstReadGroups[i].ToString(),
                    BatchId = batchId
                };
                Context.Acls.Add(acl1);
            }



          




            Context.SaveChanges();

            Batch objBatch = new Batch();
            objBatch.batchId = batchId;

            return JsonConvert.SerializeObject(objBatch);

        }

        
        [HttpGet]
        [Route("~/batch/{batchId}")]

        public string batch(string batchId)
        {
            ErrorMsgClass errorObj = new ErrorMsgClass();
            Errors errors = new Errors();
            
            List<BatchViewModel> lstBatchViewModels = new List<BatchViewModel>();
             if (batchId != null)
            {

              
                var batchList = (from batch in Context.BatchDetails 
                                where batch.BatchId1 == batchId
                                select new
                                {
                                    batch.BatchId1,
                                    batch.BusinessUnit,
                                    batch.BatchPublishDate,
                                    batch.Status,
                                    batch.ExpiryDate                                   
                                }).ToList();

               


                var attrList = (from attr in Context.Attributes
                                where attr.BatchId == batchId
                                select new { attr.Key, attr.Value }).ToList();

                FileShow objFile = new FileShow();


                if (batchList.Count == 0)
                {
                    errorObj.CorrelationID = "400";
                    errors.source = "GetbatchDeatils";
                    errors.description = "This batchId doesn't exist";

                    errorObj.errors = errors;
                    return JsonConvert.SerializeObject(errorObj);

                }



                foreach (var item in batchList)
                {

                    BatchViewModel objBatchVm = new BatchViewModel();
                    objBatchVm.BatchId1 = item.BatchId1;
                    objBatchVm.BusinessUnit = item.BusinessUnit;
                    objBatchVm.BatchPublishDate = item.BatchPublishDate;
                    objBatchVm.Status = item.Status;
                    objBatchVm.ExpiryDate = item.ExpiryDate;
                   



                    if (objBatchVm.ExpiryDate <=  System.DateTime.Now )
                    {
                        errorObj.CorrelationID = "400";
                        errors.source = "GetbatchDeatils";
                        errors.description = "This batch has been expired";

                        errorObj.errors = errors;
                        return JsonConvert.SerializeObject(errorObj);
                    }
                   

                    objBatchVm.attribute = new List<AttributeShow>();
                    foreach (var item_a in attrList)
                    {
                        AttributeShow obj = new AttributeShow();
                        obj.Key = item_a.Key;
                        obj.Value = item_a.Value;
                        objBatchVm.attribute.Add(obj);
                    }

                    objBatchVm.fileShow = new List<FileShow>();
                    objBatchVm.fileShow.Add(objFile);
                    


                    lstBatchViewModels.Add(objBatchVm);

                }

            }
           
            return JsonConvert.SerializeObject(lstBatchViewModels);
        }


        //[HttpGet] 
        //[Route("~/Test/{name}")]
        //public string Test(string name)
        //{
        //    return "My name is  :" + name;

        //}


    }
}
