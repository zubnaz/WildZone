using Domain.Models.Entities;
using ErrorOr;

namespace Application.Interfaces;

public interface IAuthenticationRepository
{
    Task<Stalker?> IsUserExist(string Email);
    Task<bool> IsPasswordCorrect(Stalker stalker, string Password);
    Task AddNewEmailVerificationAsync(string Email, string Code);
    Task<bool> IsEmailToVerificationExistAsync(string Email);
    Task<bool> IsEmailVerificationCodeValidAsync(string Email, string Code);
    Task ConfirmVerificationAsync(string Email);
    Task<ErrorOr<Stalker>>CreateNewStalkerAsync(Stalker Stalker, string Password, string Role);
}
