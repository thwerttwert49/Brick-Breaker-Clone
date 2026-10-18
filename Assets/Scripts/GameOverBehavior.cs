using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene
using System.Collections;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void play_button_clicked() { //playbutton
        SceneManager.LoadScene("Level" + Random.Range(1, 3), LoadSceneMode.Additive);
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(gameObject.scene);
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
