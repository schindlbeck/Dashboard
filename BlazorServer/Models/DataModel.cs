namespace BlazorServer.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cw { get; set; }

        //public TaskState State { get; set; } = TaskState.New;

    }

    //public enum TaskState { New, Scheduled, InProgress, Finished };
}
