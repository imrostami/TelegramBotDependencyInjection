using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotDependencyInjection.Contracts;
using Telegram.Bot.Types.Enums;

namespace TelegramBotDependencyInjection.UpdateControllers;

public class BotCommandController : IBotController
{

    public async Task HandleUpdateAsync(Update update, ITelegramBotClient bot)
    {
        if (update.Message != null && update.Message.Text == "/start")
        {
            await bot.SendTextMessageAsync(update.Message.Chat.Id, "Welcome to Your Bot");

        }
       
    }

    public List<UpdateType> UpdateTypes => new()
    {
        
        UpdateType.Message
    };
}