using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotDependencyInjection.Contracts;

public interface IBotController
{
    public Task HandleUpdateAsync(Update update, ITelegramBotClient bot);
}