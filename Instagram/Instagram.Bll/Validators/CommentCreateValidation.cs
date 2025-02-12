using FluentValidation;
using Instagram.Bll.DTOs;
using Instagram.Repoistory.Services;

namespace Instagram.Bll.Validators;

public class CommentCreateValidation : AbstractValidator<CommentCreateDto>
{
    private readonly ICommentRepo CommentRepo;
    public CommentCreateValidation(ICommentRepo commentRepo)
    {
        CommentRepo = commentRepo;
        RuleFor(c => c.Body).MaximumLength(200).WithMessage("Body len must be less then 200");
        
    }
}
