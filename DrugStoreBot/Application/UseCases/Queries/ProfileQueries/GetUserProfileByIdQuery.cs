using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;
/// <summary>
/// Получение UserProfile по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetUserProfileByIdQuery(Guid Id) : IRequest<Profile>;
