using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotDependencyInjection.Contracts;

namespace TelegramBotDependencyInjection.UpdateControllers;

public class BotCommandController : IBotController
{
    public async Task HandleUpdateAsync(Update update, ITelegramBotClient bot)
    {
        if (update.Message.Text == "/start")
        {
            await bot.SendTextMessageAsync(update.Message.Chat.Id, "Welcome to Your Bot");

        }
    }
}