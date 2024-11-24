using Application.Interface.Repositories.DrugStoreRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.DeleteDrugStoreCommand;

/// <summary>
/// Обработчик DeleteDrugStoreCommand
/// </summary>
public class DeleteDrugStoreCommandHandler : IRequestHandler<DeleteDrugStoreCommand>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий чтения DrugStoreWriteRepository.</param>
    public DeleteDrugStoreCommandHandler(
        IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        await _drugStoreWriteRepository.DeleteAsync(request.DrugStoreId, cancellationToken);
    }
}