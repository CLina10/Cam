using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public const string level101name = "15.06.2018";

    void OnEnable()
    {
        MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
    }

    //void OnDisable()
    //{
    //    MenuEvents.Instance.StartPlaying.RemoveListener(ChangeScene);
    //}

    public void ChangeScene()
    {
        SceneManager.LoadScene("15.06.2018");
    }

    public void ChangeScene(string sceneName)
    {
    }
}
