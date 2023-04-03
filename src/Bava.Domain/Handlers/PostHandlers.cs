using Bava.Domain.Commands.PostCommands;
using Bava.Domain.Entities;
using Bava.Domain.Handlers.Contracts;
using Bava.Domain.Repositories;

namespace Bava.Domain.Handlers;

public class PostHandlers : IHandler<CreatePostCommand, Post>, IHandler<DeletePostCommand>
{
    private readonly IPostRepository _postRepository;

    public PostHandlers(IPostRepository postRepository) =>
        (_postRepository) =
        (postRepository);

    public CommandResult<Post> Handle(CreatePostCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid)
        {
            return new CommandResult<Post>(Status.Invalid, "Dados incorretos!");
        }

        var post = Post.Create(command.Title, command.Description, command.BlogId);

        _postRepository.Create(post);

        return new CommandResult<Post>(Status.Created, "Post criado com sucesso!", post);
    }

    public CommandResult Handle(DeletePostCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid)
        {
            return new CommandResult(Status.Invalid, "Dados incorretos!");
        }

        var post = _postRepository.GetById(command.PostId);
        if (post == null || post.Blog.OwnerId != command.UserId)
        {
            return new CommandResult(Status.NotFound, "Post não encontrado!");
        }

        _postRepository.Delete(post);

        return new CommandResult(Status.Ok, "Post deletado com sucesso!");
    }
}