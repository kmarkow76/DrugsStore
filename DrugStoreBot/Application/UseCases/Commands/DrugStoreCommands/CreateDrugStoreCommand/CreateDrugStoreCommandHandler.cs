using Application.Interface.Repositories.DrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.CreateDrugStoreCommand;

/// <summary>
/// Обработчик CreateDrugStoreCommand
/// </summary>
public class CreateDrugStoreCommandHandler : IRequestHandler<CreateDrugStoreCommand, DrugsStore>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий чтения DrugStoreWriteRepository.</param>
    public CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }
    /// <summary>
    /// Обработка создания DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный DrugStore.</returns>
    public async Task<DrugsStore> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new DrugsStore(request.DrugNetwork, request.Number, request.Address, request.PhoneNumber);
        await _drugStoreWriteRepository.AddAsync(drugStore,cancellationToken);
        return drugStore;
    }
}