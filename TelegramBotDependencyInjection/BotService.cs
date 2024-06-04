using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotDependencyInjection.Contracts;

namespace TelegramBotDependencyInjection;

public class BotService
{
    private readonly IEnumerable<IBotController> _botControllers;
    private readonly ITelegramBotClient _botClient;
    private CancellationTokenSource cts;
    private ReceiverOptions receiverOptions;
    public BotService(IEnumerable<IBotController> botControllers, ITelegramBotClient botClient)
    {
        _botControllers = botControllers;
        _botClient = botClient;
        cts = new();

        receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };
    }

    public async Task StartBotAsync()
    {
        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );
    }

    public async void GetMe()
    {
        var me = await _botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
    }


    async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        foreach (var botController in _botControllers)
        {
            await botController.HandleUpdateAsync(update, botClient);
        }
    }

    Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }

}