using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //to use textmesh pro

public class HUDBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private TMP_Text score_ui;
    void Start()
    {
        score_ui = GameObject.Find("ScoreUI").GetComponent<TMP_Text>();
    }
    public void update_hud(int lives, int score) {
        score_ui.text = score.ToString();
    }
}
