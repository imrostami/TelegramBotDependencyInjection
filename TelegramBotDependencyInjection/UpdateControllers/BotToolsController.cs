using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotDependencyInjection.Contracts;

namespace TelegramBotDependencyInjection.UpdateControllers;

public class BotToolsController : IBotController
{
    public async Task HandleUpdateAsync(Update update, ITelegramBotClient bot)
    {
        if (update.Message.Text == "/date")
        {
            await bot.SendTextMessageAsync(update.Message.Chat.Id, $"Date Time : {DateTime.Now.ToString("D")}");
        }
    }

    public List<UpdateType> UpdateTypes => new() { UpdateType.Message };
}