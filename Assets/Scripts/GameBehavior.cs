using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene
using System.Collections;

/*
 Art: You must create all of your own art for the following: paddle, bricks, power and powerups.  You cannot use the pre-built sprites in Unity.  You must draw your own sprites.
 Bricks: You must create 3 different types of bricks.  These bricks should have different properties (health, defense, spawning power-ups, etc.).
 Power-ups: You must create 3 different types of collectables that spawn randomly.  How the player collects the power-ups is decided by you.  How they alter the game is also up to you.  I call these power-ups but they could also be items that negatively affect the player.
 Start Screen: You must create some kind of start screen that will allow the user to start the game or exit the game.
 Lives: The player has 3 lives to start.  If the ball goes below their paddle, they will lose a life.  If the user loses all of their lives, there will be a game over screen that shows.  This will show the player their score, ask them if they want to play again, or exit.
 Game Over Screen: You must create some kind of game over screen that will display the player’s score, ask them if they want to play again, or exit.
*/
public class GameBehavior : MonoBehaviour
{
    private int player_lives = 3;
    private int player_score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
    public void lose_life()
    {
        player_lives -= 1;
        if (player_lives <= 0)
        {
            LevelBehavior level_behavior = GameObject.Find("LevelScript").GetComponent<LevelBehavior>();
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            level_behavior.unload_level();
            SceneManager.UnloadSceneAsync("HUD");
            player_lives = 3;
            player_score = 0;
        }
    }

    public void add_score(int add)
    {
        player_score += add;
        HUDBehavior hud_behavior = GameObject.Find("HUDScript").GetComponent<HUDBehavior>();
        hud_behavior.update_hud(player_lives, player_score);
    }
    public float get_score()
    {
        return player_score;
    }
}
