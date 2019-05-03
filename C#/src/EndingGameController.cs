using System;
using SwinGameSDK;

/// <summary>
/// The EndingGameController is responsible for managing the interactions at the end
/// of a game.
/// </summary>

static class EndingGameController
{

	/// <summary>
	/// Draw the end of the game screen, shows the win/lose state
	/// </summary>
    /// <remarks>
    /// Isuru: Updated to new swingame call
    /// </remarks>
	public static void DrawEndOfGame()
	{
		UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

        Rectangle toDraw = new Rectangle
        {
            X = 0,
            Y = 250,
            Width = SwinGame.ScreenWidth(),
            Height = SwinGame.ScreenHeight()
        };
        String whatShouldIPrint = "I have long variable names";
		if (GameController.HumanPlayer.IsDestroyed) {
            whatShouldIPrint = "YOU LOSE!";
        } else {
			whatShouldIPrint = "-- WINNER --";
		}
        SwinGame.DrawText(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw);
    }

	/// <summary>
	/// Handle the input during the end of the game. Any interaction
	/// will result in it reading in the highsSwinGame.
	/// </summary>
    /// <remarks>
    /// Isuru: Updated keycodes
    /// </remarks>
	public static void HandleEndOfGameInput()
	{
        if (SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey)) {
			HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
			GameController.EndCurrentState();
		}
	}

}
