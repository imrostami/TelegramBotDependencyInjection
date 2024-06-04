using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBotDependencyInjection.Contracts;
using TelegramBotDependencyInjection.UpdateControllers;
using TelegramBotDependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(
        token: "6303822898:AAGGZw5r7XBaTsrj-J61-VNObupqAEYdhWM"))
    .AddSingleton<BotService>()
    .AddTransient<IBotController, BotCommandController>()
    .AddTransient<IBotController, BotKeyboardController>()
    .AddTransient<IBotController, BotToolsController>();

var serviceProvider = services.BuildServiceProvider();
var botService = serviceProvider.GetRequiredService<BotService>();


await botService.StartBotAsync();

botService.GetMe();

Console.ReadKey();