namespace Fetagne.Domain.Entities;

public class Question{

    // constractor
    public Question(
        string questionText,
        string[] answer,
        string correctAnswer,
        string[] tag,
        string?[]? hint,
        string?[]? explanation,
        string?[]? reference,
        string?[]? image,
        string?[]? code
    )
    {
        QuestionText = questionText;
        Answer = answer;
        CorrectAnswer = correctAnswer;
        Tag = tag;
        Hint = hint;
        Explanation = explanation;
        Reference = reference;
        Image = image;
        Code = code;
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string QuestionText { get; set; } = null!;
    public string[] Answer { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public string[] Tag { get; set; } = null!;
    public string?[]? Hint { get; set; } = null;
    public string?[]? Explanation { get; set; } = null;
    public string?[]? Reference { get; set; } = null;
    public string?[]? Image { get; set; } = null;
    public string?[]? Code { get; set; } = null;
}