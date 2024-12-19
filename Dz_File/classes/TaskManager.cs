using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domashka
{
    internal class TaskManager
    {
        private List<Employee> employees = new List<Employee>();
        public Project project { get; set; }
        public TaskManager(Project project)
        {
            this.project = project;
        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void TaskGive()
        {
            
            while (project.projectStatus == ProjectStatus.Проект)
            {
                Console.Write("\nВведите действие(1 - добавить задачу, 2 - изменить статус проекта на исполнение):");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите описание задачи:");
                        string opis = Console.ReadLine();
                        Console.Write("Введите срок задачи(через сколько дней должна быть выполнена задача):");
                        bool isInt = uint.TryParse(Console.ReadLine(), out uint days);
                        Console.Write($"Введите номер рабочего, которому хотите выдать задачу от 1 до {employees.Count()}: "); 
                        bool isnum = int.TryParse(Console.ReadLine(), out int numR);
                        if (isInt && isnum)
                        {
                            DateTime srok = DateTime.Now.AddDays(days);
                            try
                            {
                                project.AddTask(new Task(opis, srok, employees[numR-1]));
                            }
                            catch (Exception IndexOutOfRangeException)
                            {
                                throw new Exception("Указанный работник не сущетсвует");
                            }
                            Console.WriteLine($"Работник {employees[numR - 1].employeName} получил задачу");
                            break;
                        }
                        else
                        {
                            throw new Exception("Вы ввели некорректное количество дней");
                        }

                    case "2":
                        project.projectStatus = ProjectStatus.Исполнение;
                        break;
                    default:
                        throw new Exception("Такое значение не принимается");
                }
            }

        }
        public void TaskRaspred()
        {
            while (project.projectTasks.Count > 0)
            {
                Task task = project.projectTasks.Pop();
                if (task.taskEmployee == null)
                {
                    Console.Write($"Задача {task.taskInfo} не имеет работника, что вы хотите с ней сделать(0 - удалить задачу, (1-{employees.Count()} - назначить на i работника: ");
                    bool isnum = int.TryParse(Console.ReadLine(), out int num);
                    if (isnum)
                    {
                        switch (num)
                        {
                            case 0:
                                Console.WriteLine($"Задача {task.taskInfo} удалена\n");
                                break;
                            default:
                                try
                                {
                                    project.teamLid.GiveTaskOther(task, employees[num - 1]);
                                    project.projectTasks.Push(task);
                                }
                                catch (Exception IndexOutOfRange)
                                {
                                    throw (new Exception("Такой работник не существует"));
                                }
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Вы ввели неправильные данные");
                    }
                }
                else if (task.taskStatus == TaskStatus.Назначена)
                {

                    Console.Write($"\nРаботник {task.taskEmployee.employeName} берет задачу?\nДа/Нет: ");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "да":
                            task.taskEmployee.AcceptTask(task);
                            project.projectTasks.Push(task);
                            break;
                        case "нет":
                            Console.Write($"\nКому вы хотите передать задачу(1 - {employees.Count()})(0 если никому): ");
                            bool isnum = int.TryParse(Console.ReadLine(), out int num);
                            if (isnum && num != 0)
                            {

                                task.taskEmployee.GiveTaskOther(task, employees[num - 1]);
                                project.projectTasks.Push(task);
                            }
                            else
                            {
                                task.taskEmployee.CancelTask(task);
                            }
                            project.projectTasks.Push(task);
                            break;
                        default:
                            throw new Exception("такой ответ не принимается");
                    }
                }
                else if (task.taskStatus == TaskStatus.Выполняется)
                {
                    Console.Write($"\nВыполнил ли работник {task.taskEmployee.employeName} задачу {task.taskInfo}\nДа/Нет: ");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "да":
                            task.CompleteTask();
                            project.projectTasks.Push(task);
                            break;
                        case "нет":
                            project.projectTasks.Push(task);
                            break;
                        default:
                            throw new Exception("такой ответ не принимается");
                    }
                }
                else if (task.taskStatus == TaskStatus.Проверяется)
                {
                    Console.WriteLine($"\n{project.initName} принимаете ли вы задачу {task.taskInfo}?\nОтчёты по задаче");
                    foreach (Report i in task.taskReports)
                    {
                        i.ReportInfo();
                    }
                    Console.Write("Да/Нет: ");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "да":
                            task.taskStatus = TaskStatus.Выполнена;
                            break;
                        case "нет":
                            task.taskStatus = TaskStatus.Выполняется;
                            project.projectTasks.Push(task);
                            break;
                        default:
                            throw new Exception("такого действия не существует");
                    }
                }
                
            }
            if (project.projectDeadLine > DateTime.Now)
            {
                project.projectStatus = ProjectStatus.Закрыт;
            }
            else
            {
                Console.WriteLine(project.projectDeadLine);
                throw new Exception("Вы просрочили дедлайн");
            }
        }
            
    }
}
