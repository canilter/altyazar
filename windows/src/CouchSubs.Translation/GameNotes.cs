// SPDX-License-Identifier: AGPL-3.0-only
// Altyazar: CouchSubs (Sinan Yorulmaz, https://github.com/yorulmazsinan/couchsubs) temel alınarak değiştirildi, 2026-11-17.

namespace CouchSubs.Translation;

/// <summary>
/// Belirli oyunlar için yapay zekâ çevirisine eklenen notlar: karakter ve yer adları, argo ve üslup. Oyun adı PS5'in
/// bildirdiği "o an çalışan oyun"dan gelir; tanınmayan oyunlarda hiçbir şey eklenmez.
/// </summary>
public static class GameNotes
{
    /// <summary>GTA 6 (Grand Theft Auto VI) için çeviri notları.</summary>
    public const string Gta6 =
        "Notes for this game (Grand Theft Auto VI): a crime story set in Leonida, a parody of Florida, and its city Vice City. " +
        "The leads are Lucia Caminos and Jason Duval, a criminal couple; they talk to each other warmly and casually. " +
        "Never translate or change names of people, places, gangs, brands, vehicles, weapons, radio stations or shops " +
        "(e.g. Lucia, Jason, Cal, Boobie, Dre'Quan, Raul, Brian, Real Dimez, Vice City, Leonida, Port Gellhorn, Ambrosia, " +
        "Grassrivers, Leonida Keys, Mount Kalaga, Ammu-Nation, Cluckin' Bell). " +
        "Dialogue is street talk full of slang, jokes and swearing: translate it into equally natural Turkish street talk " +
        "and keep swear words just as strong (do not soften or censor them). Use \"sen\" between characters; cops and " +
        "strangers may use \"siz\" only when the English is clearly formal. " +
        "Short on-screen texts are mission objectives, help tips, phone messages or menu items: keep them short, use the " +
        "imperative for objectives (\"Go to the bank.\" → \"Bankaya git.\") and keep money amounts like $500 as they are. " +
        "Satirical ads, radio and social media posts should stay funny in Turkish.";

    /// <summary>Oyunun adına göre notlar; tanınmayan oyunda null.</summary>
    public static string? For(string? game)
    {
        if (string.IsNullOrWhiteSpace(game)) return null;
        // "GTA Vice City" ya da "Grand Theft Auto V" GTA 6 sayılmasın: VI / 6 tek başına bir kelime olmalı.
        return Gta6Name.IsMatch(game.Replace("™", "").Replace("®", "")) ? Gta6 : null;
    }

    private static readonly System.Text.RegularExpressions.Regex Gta6Name = new(
        @"\b(GRAND\s+THEFT\s+AUTO|GTA)\s*(VI|6)\b",
        System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.CultureInvariant);
}
