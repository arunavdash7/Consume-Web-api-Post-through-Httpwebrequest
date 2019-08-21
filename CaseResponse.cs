using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PostCaseDataToExternalApplication.cs
{
    [DataContract]
    public class Result
    {

        [DataMember]
        public string number { get; set; }
        
    }

    public class CaseResponse
    {
        public Result result { get; set; }
    }
}
