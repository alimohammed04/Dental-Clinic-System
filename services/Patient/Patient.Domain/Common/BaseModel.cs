using System;
using System.Collections.Generic;
using System.Text;

namespace Patient.Domain.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}
