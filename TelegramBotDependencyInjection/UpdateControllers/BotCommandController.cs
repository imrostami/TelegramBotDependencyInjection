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
        else if (update.Message != null && update.Message.Text == "/loop")
        {
            for (int i = 1; i < 999999; i++)
            {
                await bot.SendTextMessageAsync(update.Message.Chat.Id, $"this is item {i}");

            }
        }
        else if (update.Poll != null)
        {
            
        }
        else
        {
            await bot.SendPollAsync(update.Message.Chat.Id, "Hello How are you ?", new List<string>()
            {
                "چته ناوار یو",
                "تو رفیق نا رفیق",
                "ممنون مرسی"
            }, isAnonymous: true, type: PollType.Quiz, correctOptionId: 0);
        }
    }

    public List<UpdateType> UpdateTypes => new()
    {
        UpdateType.Poll,
        UpdateType.Message
    };
}