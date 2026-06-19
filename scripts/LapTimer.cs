using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapTimer : MonoBehaviour
{
    public Text timerText;
    public int totalLaps = 3;

    float time = 0f;
    int lap = 1;

    void Update()
    {
        time += Time.deltaTime;

        int m = Mathf.FloorToInt(time / 60);
        int s = Mathf.FloorToInt(time % 60);

        timerText.text = m.ToString("00") + ":" + s.ToString("00");
    }

    public void FinishLap()
    {
        // лучший результат
        if (time < SaveManager.instance.bestTime || SaveManager.instance.bestTime == 0)
        {
            SaveManager.instance.bestTime = time;
        }

        lap++;

        if (lap > totalLaps)
        {
            StartCoroutine(GoToGarage());
            return;
        }

        time = 0f;
    }

    System.Collections.IEnumerator GoToGarage()
    {
        SaveManager.instance.Save();

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Garage");
    }
}