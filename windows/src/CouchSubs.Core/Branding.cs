// SPDX-License-Identifier: AGPL-3.0-only
// Altyazar: CouchSubs (Sinan Yorulmaz, https://github.com/yorulmazsinan/couchsubs) temel alınarak değiştirildi, 2026-11-17.

namespace CouchSubs.Core;

/// <summary>
/// Uygulamanın kullanıcıya görünen adı. Kod içindeki ad alanları ve dosya adları CouchSubs olarak kalır;
/// ekranda görünen her "CouchSubs" metni bu ada çevrilir.
/// </summary>
public static class Branding
{
    public const string Name = "Altyazar";
    public const string Repository = "https://github.com/canilter/altyazar";

    /// <summary>AGPL-3.0 bölüm 5a: değiştirilmiş sürüm olduğunu ve aslını belirten not.</summary>
    public const string Attribution =
        "Altyazar, Sinan Yorulmaz'ın CouchSubs uygulaması (https://github.com/yorulmazsinan/couchsubs) temel alınarak " +
        "geliştirilmiştir; 17 Kasım 2026'dan itibaren değiştirilmiştir. GNU AGPL-3.0 ile lisanslıdır.";

    /// <summary>Ekran metnindeki eski adı yeni adla değiştirir.</summary>
    /// Türkçe ekler sert ünsüzden (CouchSubs'ta) yumuşağa (Altyazar'da) uyarlanır.
    public static string Apply(string text) => text
        .Replace("CouchSubs'tan", Name + "'dan", StringComparison.Ordinal)
        .Replace("CouchSubs'ta", Name + "'da", StringComparison.Ordinal)
        .Replace("CouchSubs", Name, StringComparison.Ordinal);
}
