using Application.Interface.Repositories.CountryRepositories;
using Application.Interface.Repositories.DrugItemRepositories;
using Application.UseCases.Commands.CountryCommands.CreateCountryCommand;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateDrugItemCommand;

/// <summary>
/// Обработчик команды на создание нового объекта сущности DrugItem
/// </summary>
public class CreateDrugItemCommandHandler : IRequestHandler<CreateDrugItemCommand,DrugItem>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий записи DrugItemWriteRepository</param>
    public CreateDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;

    }
    public async Task<DrugItem> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = new DrugItem(request.DrugId, request.Drug, request.DrugStore, request.DrugStoreId, request.Count,request.Cost);
            
        // Добавление нового DrugItem в репозиторий
        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);
            
        return drugItem;
    }
}