namespace Fetagne.Application.Services.Question.Command.CreateQuestion;
using MediatR;
using ErrorOr;
using Fetagne.Application.Services.Question.Common;

public record CreateQuestionCommand(
    string QuestionText,
    string[] Answer,
    string CorrectAnswer,
    string[] Tag,
    string?[]? Hint,
    string?[]? Explanation,
    string?[]? Reference,
    string?[]? Image,
    string?[]? Code
): IRequest<ErrorOr<CreateQuestionResponse>>;
