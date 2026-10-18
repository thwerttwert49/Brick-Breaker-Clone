using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene
using System.Collections;

public class GameBehavior : MonoBehaviour
{
    private int player_lives = 3;
    private int player_score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
    public void lose_life() {
        player_lives -= 1;
        if (player_lives <= 0) {
            LevelBehavior level_behavior = GameObject.Find("LevelScript").GetComponent<LevelBehavior>();
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            level_behavior.unload_level();
            SceneManager.UnloadSceneAsync("HUD");
            player_lives = 3;
            player_score = 0;
        }
    }

    public void add_score(int add) {
        player_score += add;
        HUDBehavior hud_behavior = GameObject.Find("HUDScript").GetComponent<HUDBehavior>();
        hud_behavior.update_hud(player_lives, player_score);
    }
    public float get_score() {
        return player_score;
    }
}
