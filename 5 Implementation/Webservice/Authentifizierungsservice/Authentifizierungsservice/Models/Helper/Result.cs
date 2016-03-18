using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models.Helper
{
  public class Result
    { 
         public Result()
         { 
             Success = false; 
             ErrorMessage = ""; 
         } 
         public bool Success { get; set; } 
         public string ErrorMessage { get; set; } 
         public Exception InnerException { get; set; } 
     } 

}