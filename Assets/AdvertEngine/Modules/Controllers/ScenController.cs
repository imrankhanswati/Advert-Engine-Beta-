using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenController : MonoBehaviour
{
    public int TotalScenes = 4;
    public int currentScene = 0;
    public UnityEngine.UI.Text sceneNo;

    private void OnEnable()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        sceneNo.text = SceneManager.GetActiveScene().name + "-" + currentScene.ToString();
    }
    public void LoadNextScene()
    {
        currentScene++;
        if (currentScene >= TotalScenes)
        {
            currentScene = 0;
        }
        sceneNo.text = currentScene.ToString();
        SceneManager.LoadScene(currentScene);
    }

    public void LoadPreviousScene()
    {
        currentScene--;
        if (currentScene < 0)
        {
            currentScene = 0;
        }
        sceneNo.text = sceneNo.ToString();
        SceneManager.LoadScene(currentScene);
    }
}
