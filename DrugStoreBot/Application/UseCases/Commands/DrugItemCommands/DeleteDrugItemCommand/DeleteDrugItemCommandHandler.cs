using Application.Interface.Repositories.DrugItemRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.DeleteDrugItemCommand;

/// <summary>
/// Обработчик DeleteDrugItemCommand
/// </summary>
public class DeleteDrugItemCommandHandler : IRequestHandler<DeleteDrugItemCommand>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий чтения DrugItemWriteRepository.</param>
    public DeleteDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления DrugItem
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        await _drugItemWriteRepository.DeleteAsync(request.DrugItemId, cancellationToken);
    }
}