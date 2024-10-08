using System.IO;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("8185729203:AAGUCqztf9aJlAD4u4MRxk4s1NCQBeChY48", cancellationToken: cts.Token);
var me = await bot.GetMeAsync();
bot.OnMessage += OnMessage;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); // stop the bot

// method that handle messages received by the bot:
async Task OnMessage(Message msg, UpdateType type)
{
    await bot.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: (IReplyMarkup?)GetButtons());
    if (msg.Text == "/start")
    {
        await bot.SendTextMessageAsync(msg.Chat, "Добро пожаловать на клининговый мастер-класс. Это бот-коуч по тому, как превратить уборку в марафон с препятствиями");
        await bot.SendStickerAsync(msg.Chat, "CAACAgIAAxkBAAEJCipnBUTpzU1tswtb1GY3JI6Dp4GvPAACBwADJVClGScdybtFdNFRNgQ");

    }
    switch (msg.Text)
    {
        case "Мыть полы":
            await bot.SendTextMessageAsync(msg.Chat, "Возьми в руки швабру и расставь по дому препятсвия, а затем начни бежать с ней, перепрыгивая через препятствия");
            await bot.SendStickerAsync(msg.Chat, "CAACAgIAAxkBAAEJCrNnBVvqYB8axNlocrI32OpeB0HOzwACmwADJVClGZ5cxFxgn16CNgQ");
            break;
        case "Мыть посуду":
            await bot.SendTextMessageAsync(msg.Chat, "Моя посуду строй башню из тарелок, попытайся выставить её как можно выше, а главное не урони её)");
            await bot.SendStickerAsync(msg.Chat, "CAACAgIAAxkBAAEJCr9nBV0cOl7iRBG-Jz5U7UtenBEVXAACngADJVClGayadb09m-yQNgQ");
            break;
        case "Протирать полки":
            await bot.SendTextMessageAsync(msg.Chat, "Представь, что тряпка, это крутой паркурист😎, и протирая делай вид, что он крутит кульбиты в воздухе");
            await bot.SendStickerAsync(msg.Chat, "CAACAgIAAxkBAAEJCsFnBV3lzClTVInFGU-ZT6r2nfLw8AACnAADJVClGQ_5afDWFNe6NgQ");
            break;
        case "Выкинуть мусор":
            await bot.SendTextMessageAsync(msg.Chat, "Добегая до мусорки, перепригивая через все лавочки, заборы и т.д. Чем меньше мусора вылетит тем больше очков ты заработаешь");
            await bot.SendStickerAsync(msg.Chat, "CAACAgIAAxkBAAEJCsNnBV6UzFxWB4zmxtbhJYNorh6MpwACdAADJVClGXLcUx7zNz9VNgQ");
            break;
        case "Вытряхивать пыль":
            await bot.SendTextMessageAsync(msg.Chat, "Возьми палку для выбивания пыли с чего-нибудь, и представь, что это что-то это самый злой человек на планете(разрешаю представить меня), и начинай, что есть сил бить по ней");
            await bot.SendStickerAsync(msg.Chat, "CAACAgIAAxkBAAEJCsdnBV8myp_QiPM4ZWX_Tacb2rHWlAACoAADJVClGXHrUwHY2uNYNgQ");
            break;
    }
}

object GetButtons()
{
    return new ReplyKeyboardMarkup
    {
        Keyboard = new List<List<KeyboardButton>>
        {
            new List<KeyboardButton> { new KeyboardButton { Text = "Мыть полы" }, new KeyboardButton { Text = "Мыть посуду" }, new KeyboardButton { Text = "Протирать полки" }},
            new List<KeyboardButton> { new KeyboardButton { Text = "Выкинуть мусор" }, new KeyboardButton { Text = "Вытряхивать пыль" } }
        }
    };
}