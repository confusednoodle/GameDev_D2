using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadW1()
    {
        SceneManager.LoadScene("World 1");
    }

    public void LoadW2()
    {
        SceneManager.LoadScene("World 2");
    }

    public void LoadW3()
    {
        SceneManager.LoadScene("World 3");
    }
}
