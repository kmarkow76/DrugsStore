using Application.Interface.Repositories.DrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.UpdateDrugStoreCommand;

/// <summary>
/// Обработчик UpdateDrugStoreCommand
/// </summary>
public class UpdateDrugStoreCommandHandler : IRequestHandler<UpdateDrugStoreCommand, DrugsStore>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий чтения DrugStoreWriteRepository.</param>
    /// <param name="drugStoreReadRepository">Репозиторий записи DrugStoreRiteRepository.</param>
    public UpdateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository, IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    
    /// <summary>
    /// Обработка обновления DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный DrugStore.</returns>
    public async Task<DrugsStore> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);
        drugStore.Update(
            request.DrugNetwork,
            request.Number,
            request.Address,
            request.PhoneNumber);
        await _drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
        return drugStore;
    }
}