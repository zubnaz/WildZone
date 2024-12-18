using Data;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace JwtRegisterAndLogin.Helpers;

public class VerifivationEmailCleaner : BackgroundService
{
    private IServiceScopeFactory _scopeFactory;

    public VerifivationEmailCleaner(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       while(!stoppingToken.IsCancellationRequested) // Перевірка чи сервер ще працює
        {
            try
            {
                // Створюємо нову область (scope) для отримання сервісів зі Scoped або Transient життєвим циклом.
                // Scope забезпечує, що об'єкти в межах цієї області будуть існувати лише в рамках цього блоку.
                // Використання `using` забезпечує автоматичне звільнення ресурсів після завершення області.
                using var scope = _scopeFactory.CreateScope();
                // Отримуємо сервіс StalkersDbContext зі створеного scope.
                // Метод GetRequiredService<T>() викликає помилку, якщо сервіс не зареєстровано у контейнері залежностей.
                var stalkersDbContext = scope.ServiceProvider.GetRequiredService<StalkersDbContext>();

                var deletedEmails = stalkersDbContext.EmailVerifications.Where(e => e.EndTime <= DateTime.UtcNow).ToList(); // Дістаємо список ел. пошт, в яких вийшов термін дії
                if (deletedEmails.Any()) // Якщо список не порожній то видаляємо
                {
                    stalkersDbContext.EmailVerifications.RemoveRange(deletedEmails);
                    await stalkersDbContext.SaveChangesAsync();
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); // Затримка 5хв
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in VerifivationEmailCleaner: {ex.Message}");
            }
        }
    }
}

