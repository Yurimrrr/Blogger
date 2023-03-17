﻿using Bava.Domain.Commands.CategoryCommands;
using Bava.Domain.Entities;
using Bava.Domain.Handlers.Contracts;
using Bava.Domain.Repositories;
using Bava.Domain.Utils;

namespace Bava.Domain.Handlers;

public class CategoryHandler : IHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryHandler
        (ICategoryRepository categoryRepository) =>
        (_categoryRepository) =
        (categoryRepository);
    public CommandResult<Category> Handle(CreateCategoryCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid)
        {
            return new CommandResult<Category>(Status.Invalid, "Usuário inválido!");
        }

        var category = Category.CreateFactory(command.Name);
        
        _categoryRepository.Create(category);

        return new CommandResult<Category>(Status.Created, "Usuário criado com sucesso!", category);
    }
}