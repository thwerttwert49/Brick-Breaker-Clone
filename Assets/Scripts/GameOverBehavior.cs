using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene
using System.Collections;
using TMPro;

public class GameOverBehavior : MonoBehaviour
{
    private GameBehavior game_behavior;
    private TMP_Text score_ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
        score_ui = GameObject.Find("GameOverScore").GetComponent<TMP_Text>();
        score_ui.text = game_behavior.get_score().ToString();
    }

    public void restart_button_clicked() { //playbutton
        //SceneManager.UnloadSceneAsync(gameObject.scene);
        game_behavior.start_game();
        //StartCoroutine(waitload(5));
    }
    public void exit_button_clicked()
    { //playbutton
        Application.Quit();
    }
    /*
    private IEnumerator waitload(int time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level1");
        Debug.Log("reloaded");
    }
    */
}
