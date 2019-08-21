using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PostD365CaseDataToExternalApplication.cs
{
    [DataContract]
    public class CaseRequest
    {
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ServiceNowAssignmentGroup { get; set; }
        [DataMember]
        public string ServiceNowCatalogueName { get; set; }
        [DataMember]
        public string ServiceNowCategory { get; set; }
        [DataMember]
        public string ServiceNowSubCategory { get; set; }
        [DataMember]
        public int ServiceNowIncidentImpact { get; set; }
        [DataMember]
        public int ServiceNowIncidentPriority { get; set; }
        [DataMember]
        public string ServiceNowContactType { get; set; }
        [DataMember]
        public string ServiceNowCallerId { get; set; }
        [DataMember]
        public string ServiceNowTicketShortDescription { get; set; }


    }
}
