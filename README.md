# TelegramBotDependencyInjection

Building Telegram bots in C# language is almost very complicated in development
Therefore, I tried to reduce this complexity with an innovative format and divide the general logic of the program into different classes (under the title of Bot Controller). This idea is taken from ASP.NET MVC projects


![ff](https://github.com/sapurtcomputer30/TelegramBotDependencyInjection/assets/26039089/8ee6abeb-7075-4d95-a118-6dbf1e58ed63)

The advantage of using this method is that in addition to being able to inject your DB Context and database services into your controllers, you can easily add the relevant module whenever you need the code. Add and remove (via DI Container)

