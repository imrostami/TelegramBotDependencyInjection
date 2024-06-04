using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotDependencyInjection.Contracts;

public interface IBotController
{
    public Task HandleUpdateAsync(Update update, ITelegramBotClient bot);
    public List<UpdateType> UpdateTypes { get; }
}