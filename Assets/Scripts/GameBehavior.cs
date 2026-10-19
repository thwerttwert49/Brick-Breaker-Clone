using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene
using System.Collections;

/*
 Art: You must create all of your own art for the following: paddle, bricks, power and powerups.  You cannot use the pre-built sprites in Unity.  You must draw your own sprites.
 You are required to submit your projects source code/assets provided via a GitHub link, a WebGL build and a link to your hosted WebGL build on itch.io on brightspace before the due date.  You are also required to create a readme file stating how to play your game.  The game builds and link to your GitHub project will be submitted on Brightspace.
 add comments
 maybe live count
 test exiting and etc
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
        player_lives -= 1; //pause the game
        PlayerControl player_behavior = GameObject.Find("Player").GetComponent<PlayerControl>();
        player_behavior.set_texture(player_lives);
        if (player_lives <= 0)
        {
            Time.timeScale = 0f;
            Scene gameover_scene = SceneManager.GetSceneByName("GameOver");
            if (gameover_scene.isLoaded == false)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
            }
            Scene hud_scene = SceneManager.GetSceneByName("HUD");
            if (hud_scene.isLoaded)
            {
                SceneManager.UnloadSceneAsync("HUD");
            }

            //player_lives = 3;
            //player_score = 0;
        }
    }

    public void start_game() {
        GameObject level = GameObject.Find("LevelScript");
        if (level != null) //check if is loaded
        {
            LevelBehavior level_behavior = level.GetComponent<LevelBehavior>();
            level_behavior.unload_level();
        }
        Scene menu_scene = SceneManager.GetSceneByName("Menu");
        if (menu_scene.isLoaded)
        {
            SceneManager.UnloadSceneAsync("Menu");
        }
        Scene gameover_scene = SceneManager.GetSceneByName("GameOver");
        if (gameover_scene.isLoaded)
        {
            SceneManager.UnloadSceneAsync("GameOver");
        }

        player_lives = 3;
        player_score = 0;
        SceneManager.LoadScene("Level" + Random.Range(1, 3), LoadSceneMode.Additive);
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        Time.timeScale = 1f; //resume game if paused
    }

    public void add_score(int add)
    {
        player_score += add;
        Scene hud_scene = SceneManager.GetSceneByName("HUD");
        if (hud_scene.isLoaded)
        {
            HUDBehavior hud_behavior = GameObject.Find("HUDScript").GetComponent<HUDBehavior>();
            hud_behavior.update_hud(player_lives, player_score);
        }
    }
    public int get_lives()
    {
        return player_lives;
    }
    public float get_score()
    {
        return player_score;
    }
}
