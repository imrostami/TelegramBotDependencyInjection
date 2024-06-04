using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotDependencyInjection.Contracts;

namespace TelegramBotDependencyInjection.UpdateControllers;

public class BotKeyboardController : IBotController
{
    public async Task HandleUpdateAsync(Update update, ITelegramBotClient bot)
    {
        if (update.Message!=null && update.Message.Text == "/telegram")
        {
            var kbtn = new InlineKeyboardButton("Click to Send DM")
            {
                Url = "https://t.me/imetrox"
            };
            var rkm = new InlineKeyboardMarkup(kbtn);

            await bot.SendTextMessageAsync(update.Message.Chat.Id, "send me a message on Telegram👇", replyMarkup: rkm);
        }
        
    }

    public List<UpdateType> UpdateTypes => new() { UpdateType.Message };
}