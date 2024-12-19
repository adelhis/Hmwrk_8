using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domashka
{
    internal class Task
    {
        public string taskInfo {  get; set; }
        public DateTime taskDeadLine { get; set; }
        //тимлид
        public Employee taskEmployee { get; set; }
        public TaskStatus taskStatus { get; set; }
        public List<Report> taskReports { get; set; } = new List<Report>();
        public Task(string opis, DateTime deadLine, Employee employee)
        {
            taskStatus = TaskStatus.Назначена;
            taskInfo = opis;
            taskDeadLine = deadLine;
            taskEmployee = employee;
        }
        private string GetTaskInfo()
        {
            return $"\n  Задача: {taskInfo}\n  Срок сдачи: {taskDeadLine}\n  Работник: {taskEmployee.employeName}";
        }
        public void CompleteTask()
        {
            taskStatus = TaskStatus.Проверяется;
            Report rep = new Report(this.GetTaskInfo(), taskEmployee);        
            taskReports.Add(rep);
        }


    }
    enum TaskStatus { Назначена, Выполняется, Проверяется, Выполнена}
}
