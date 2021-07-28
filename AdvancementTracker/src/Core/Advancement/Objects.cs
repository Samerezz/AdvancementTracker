namespace AdvancementTracker.src.Core.Advancement
{
    public class AdvancementObject
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public AdvancementObject(string name,bool isCompleted)
        {
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
