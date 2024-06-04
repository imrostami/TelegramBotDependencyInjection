using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBotDependencyInjection.Contracts;
using TelegramBotDependencyInjection.UpdateControllers;
using TelegramBotDependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(
        token: "YOUR TOKEN HERE"))


    .AddSingleton<BotService>()
    .AddTransient<IBotController, BotCommandController>()
    .AddTransient<IBotController, BotKeyboardController>()
    .AddTransient<IBotController, BotToolsController>();

var serviceProvider = services.BuildServiceProvider();
var botService = serviceProvider.GetRequiredService<BotService>();


await botService.StartBotAsync();

botService.GetMe();

Console.ReadKey();