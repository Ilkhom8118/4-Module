using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram
{
    internal class Program
    {
        private static string BotToken = "8054982411:AAEpJB8lYlm9Lb8TOzI7az9wwqq5SePHqDI";
        private static TelegramBotClient BotClient = new TelegramBotClient(BotToken);
        private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "UsersId.txt");
        private static HashSet<long> Ids = new HashSet<long>();
        static async Task Main(string[] args)
        {
            var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var botListenerService = new BotListenerService();
            await botListenerService.StartBot();
            Console.ReadKey();
        }
        public static void Go()
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
            }
            Console.WriteLine("Your bot is starting!");
            var receiverOptions = new ReceiverOptions { AllowedUpdates = new[] { UpdateType.Message, UpdateType.InlineQuery } };
            BotClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
            Console.ReadKey();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            Ids = await GetAllIds();
            var message = update.Message;
            var user = message.Chat;

            Console.WriteLine($"Id: {user.Id}, UserName: {user.FirstName}, Chat: {message.Text} ");
            if (message.Text == "/start")
            {
                Ids.Add(user.Id);
                await SaveUserId();
                await bot.SendTextMessageAsync(user.Id, "Botga xush kelibsiz !", cancellationToken: cancellationToken);
                return;
            }
        }
        static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
        public static async Task SaveUserId()
        {
            var json = JsonSerializer.Serialize(Ids);
            await File.WriteAllTextAsync(FilePath, json);
        }
        public static async Task<HashSet<long>> GetAllIds()
        {
            var ids = File.ReadAllText(FilePath);
            var txt = JsonSerializer.Deserialize<HashSet<long>>(ids);
            return txt ?? new HashSet<long>();
        }
    }
}
