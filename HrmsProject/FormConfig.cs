using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsProject
{
    public static class FormConfig
    {
        public static EmployeeAddEditView employeeAddEditView = null;

        static FormConfig()
        {
            employeeAddEditView = new EmployeeAddEditView();
        }
    }
}
