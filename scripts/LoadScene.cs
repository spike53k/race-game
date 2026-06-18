using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadRace()
    {
        SceneManager.LoadScene("Race");
    }

    public void LoadGarage()
    {
        SceneManager.LoadScene("Garage");
    }
    public void QuitGame()
    {
        Debug.Log("Игра закрывается");
        Application.Quit();
    }
}