using Application.Interfaces;
using Domain.Models.Entities;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace Data.Repositories;

public class AuthenticationRepository(UserManager<Stalker> userManager, StalkersDbContext stalkersDbContext) : IAuthenticationRepository
{
    public async Task<bool> IsPasswordCorrect(Stalker stalker, string Password)
    {
        return await userManager.CheckPasswordAsync(stalker, Password); 
    }
    public async Task<Stalker?> IsUserExist(string Email)
    {
        return await userManager.FindByEmailAsync(Email);
    }
    public async Task AddNewEmailVerificationAsync(string Email, string Code)
    {
        if(stalkersDbContext.EmailVerifications.Any(e => e.Email == Email)) 
        {
            var removeEmailVerification = await stalkersDbContext.EmailVerifications.FirstAsync(e => e.Email == Email);
            stalkersDbContext.Remove(removeEmailVerification);
        }

        await stalkersDbContext.EmailVerifications.AddAsync(new EmailVerification { Id = Guid.NewGuid(), Email = Email, Code = Code });
        await stalkersDbContext.SaveChangesAsync();
    }
    public async Task<bool> IsEmailToVerificationExistAsync(string Email)
    {
        return await stalkersDbContext.EmailVerifications.AnyAsync(ev => ev.Email == Email);
    }
    public async Task<bool> IsEmailVerificationCodeValidAsync(string Email, string Code)
    {
        return await stalkersDbContext.EmailVerifications.AnyAsync(ev => ev.Email == Email && ev.Code == Code);
    }
    public async Task ConfirmVerificationAsync(string Email)
    {
        if(await IsEmailToVerificationExistAsync(Email))
        {
            var confirmedVerification = await stalkersDbContext.EmailVerifications.FirstAsync(e => e.Email == Email);
            stalkersDbContext.EmailVerifications.Remove(confirmedVerification);
            await stalkersDbContext.SaveChangesAsync();
        }
    }
    public async Task<ErrorOr<Stalker>> CreateNewStalkerAsync(Stalker Stalker,string Passwword, string Role)
    {
        var result = await userManager.CreateAsync(Stalker,Passwword);
        if (result.Succeeded)
            await userManager.AddToRoleAsync(Stalker, Role);
        else
            return Error.Conflict(description: result.Errors.FirstOrDefault()!.Description);

        await stalkersDbContext.SaveChangesAsync();

        return Stalker;
    }
}
