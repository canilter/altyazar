// SPDX-License-Identifier: AGPL-3.0-only

using CouchSubs.Translation;
using Xunit;

namespace CouchSubs.Translation.Tests;

public class GameNotesTests
{
    [Theory]
    [InlineData("Grand Theft Auto VI")]
    [InlineData("Grand Theft Auto® VI")]
    [InlineData("GTA VI")]
    [InlineData("gta 6")]
    public void RecognisesGta6(string game) => Assert.Equal(GameNotes.Gta6, GameNotes.For(game));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("Grand Theft Auto V")]
    [InlineData("GTA Vice City")]
    [InlineData("Red Dead Redemption 2")]
    public void IgnoresOtherGames(string? game) => Assert.Null(GameNotes.For(game));

    [Fact]
    public void UserMessageCarriesNotesOnlyForGta6()
    {
        Assert.Contains("Lucia Caminos", AiRequest.UserMessage(["Let's go."], [], "Grand Theft Auto VI"));
        Assert.DoesNotContain("Lucia Caminos", AiRequest.UserMessage(["Let's go."], [], "God of War Ragnarök"));
    }
}
