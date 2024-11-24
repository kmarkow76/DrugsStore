using Application.Interface.Repositories.DrugRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.DeleteDrugCommand;

/// <summary>
/// Обработчик DeleteDrugCommand
/// </summary>
public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand>
{
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи DrugWriteRepository.</param>
    public DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository)
    {
        _drugWriteRepository = drugWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        await _drugWriteRepository.DeleteAsync(request.DrugId, cancellationToken);
    }
}