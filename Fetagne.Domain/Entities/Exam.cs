namespace Fetagne.Domain.Entities;
using Fetagne.Domain.Entities;

public class Exam{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ExamName { get; set; } = null!;
    public string ExamDescription { get; set; } = null!;
    public string[] ExamTag { get; set; } = null!;
    public Question[] Questions { get; set; } = null!;
    public string?[]? ExamReference { get; set; } = null;
    public string?[]? ExamImage { get; set; } = null;
    public User ExamCreator { get; set; } = null!;
}