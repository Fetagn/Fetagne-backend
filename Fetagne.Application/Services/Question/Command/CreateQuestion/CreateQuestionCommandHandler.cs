namespace Fetagne.Application.Services.Question.Command.CreateQuestion;
using MediatR;
using ErrorOr;
using Fetagne.Application.Services.Question.Common;
using Fetagne.Domain.Entities;

public class CreateQuestionCommandHandler : IRequest<ErrorOr<CreateQuestionResponse>>
{
    private readonly IMediator _mediator;
    public Task<ErrorOr<CreateQuestionResponse>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Question(
            request.QuestionText,
            request.Answer,
            request.CorrectAnswer,
            request.Tag,
            request.Hint,
            request.Explanation,
            request.Reference,
            request.Image,
            request.Code
        );

        Console.WriteLine(question);
        return Task.FromResult<ErrorOr<CreateQuestionResponse>>(new CreateQuestionResponse(question));
    }
}