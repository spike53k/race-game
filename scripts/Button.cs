using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueManager : MonoBehaviour
{
    public string nextSceneName = "Garage";
    
    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}