using Application.Interface.Repositories.DrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateDrugCommand;
/// <summary>
/// Обработчик CreateDrugCommand
/// </summary>
public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Drug>
{
    private readonly IDrugWriteRepository _drugWriteRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи DrugWriteRepository.</param>
    public CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository)
    {
        _drugWriteRepository = drugWriteRepository;
    }
    /// <summary>
    /// Обработка создания Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Drug.</returns>
    public async Task<Drug> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = new Drug(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);
        await _drugWriteRepository.AddAsync(drug,cancellationToken);
        return drug;
    }
}