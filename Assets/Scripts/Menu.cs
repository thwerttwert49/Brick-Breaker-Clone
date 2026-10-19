using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene
using System.Collections;

public class Menu : MonoBehaviour
{
    private GameBehavior game_behavior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
    }

    public void play_button_clicked() { //playbutton
        //SceneManager.UnloadSceneAsync(gameObject.scene);
        game_behavior.start_game();
        //StartCoroutine(waitload(5));
    }
    public void exit_button_clicked() { //playbutton
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
