using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.NF
{
    public  class NFMasterSAFModel
    {
        public Int32 invoice_id { get; set; }
        public Int32 invoice_type_id { get; set; }
        public Decimal invoice_amount { get; set; }
        public Int32 org_id { get; set; }
        public Int32 organization_id { get; set; }
        public Int32 vendor_site_id { get; set; }
        
    }
}
