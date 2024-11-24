using Application.Interface.Repositories.DrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.UpdateDrugItemCommand;

/// <summary>
/// Обработчик UpdateDrugItemCommand
/// </summary>
public class UpdateDrugItemCommandHandler : IRequestHandler<UpdateDrugItemCommand, DrugItem>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    private readonly IDrugItemReadRepository _drugItemReadRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий чтения DrugItemWriteRepository.</param>
    public UpdateDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository, IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugItemReadRepository = drugItemReadRepository;
    }
    
    /// <summary>
    /// Обработка обновления DrugItem
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный DrugItem.</returns>
    public async Task<DrugItem> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await _drugItemReadRepository.GetByIdAsync(request.DrugItemId, cancellationToken);
        
        drugItem.Update(request.DrugId, request.Drug, request.DrugStore, request.DrugStoreId, request.Count,request.Cost);
        
        await _drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);
        
        return drugItem;
    }
}