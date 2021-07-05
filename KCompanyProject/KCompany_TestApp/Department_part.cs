using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCompany_TestApp
{
    public partial class Department
    {
        /// <summary>
        /// Compares all fields except ID
        /// </summary>
        public bool Equals(Department dep)
        {
            if (dep == null) return false;
            if (ParentDepartmentID != dep.ParentDepartmentID) return false;
            if (Name != dep.Name) return false;
            if (Code != dep.Code) return false;
            return true;
        }
    }
}
