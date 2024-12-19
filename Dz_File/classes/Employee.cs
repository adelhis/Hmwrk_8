
namespace Domashka
{
    internal class Employee
    {
        public string employeName {  get; set; }
        public Employee()
        {

        }
        public Employee(string name)
        {
            employeName = name;
        }
        public void AcceptTask(Task task)
        {
            task.taskStatus = TaskStatus.Выполняется;
            task.taskEmployee = this;
        }
        public void GiveTaskOther(Task task, Employee employee)
        {
            task.taskStatus = TaskStatus.Назначена;
            task.taskEmployee = employee;
        }
        public void CancelTask(Task task)
        {
            task.taskStatus = TaskStatus.Назначена;
            task.taskEmployee = null;
        }
    }
    enum EmployeeStatus { Тимлид, Рабочий};
}
