
namespace Domashka
{
    internal class Project
    {
        public string projectInfo { get; set; }
        public DateTime projectDeadLine { get; set; }
        public string initName { get; set; }
        public Employee teamLid { get; set; }
        public Stack<Task> projectTasks { get; } = new Stack<Task>();
        public ProjectStatus projectStatus { get; set; }

        public Project(DateTime srok, Employee teamlid, string init)
        {
            projectDeadLine = srok;
            projectStatus = ProjectStatus.Проект;
            teamLid = teamlid;
            initName = init;
        }
        public void AddTask(Task task)
        {
            projectTasks.Push(task);
        }
        public void PrintProjectInfo()
        {
            Console.WriteLine($"\nПроект: {projectInfo}\nСрок сдачи: {projectDeadLine}\nТекущее время: {DateTime.Now}\nСтасут: {projectStatus}");
        }
    }
    enum ProjectStatus { Проект, Исполнение, Закрыт}
}
