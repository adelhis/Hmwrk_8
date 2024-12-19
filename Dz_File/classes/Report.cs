using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domashka
{
    internal class Report
    {
        public string reportInfo { get; set; }
        public DateTime dateTaskComplete { get; set; }
        public Employee employee { get; set; }
        public Report(string ReportInfo, Employee employee)
        {
            this.reportInfo = ReportInfo;
            this.dateTaskComplete = DateTime.Now;
            this.employee = employee;
        }
        public void ReportInfo()
        {
            Console.WriteLine($" Работник: {employee.employeName}\n Дата выполнения: {dateTaskComplete}\n Информация об отчете: {reportInfo}");
        }
        
    }
}
