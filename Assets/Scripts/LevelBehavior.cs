using UnityEngine;
using UnityEngine.SceneManagement; //for loading scene

public class LevelBehavior : MonoBehaviour
{
    private int brick_count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject child in gameObject.scene.GetRootGameObjects()) {
            if (child.CompareTag("Brick")){
                brick_count += 1;
                Debug.Log("bricks: " + brick_count);
            }
        }
    }

    public void on_brick_destroyed() {
        brick_count -= 1;
        if (brick_count <= 0) {
            unload_level();
            SceneManager.LoadScene("Level" + Random.Range(1, 3), LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
    public void unload_level() {
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
