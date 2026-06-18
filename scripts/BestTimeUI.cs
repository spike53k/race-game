using UnityEngine;
using UnityEngine.UI;

public class BestTimeUI : MonoBehaviour
{
    public Text bestTimeText;

    void Start()
    {
        float time = SaveManager.instance.bestTime;

        if (time > 0)
        {
            bestTimeText.text = "Best: " + time.ToString("F2") + " sec";
        }
        else
        {
            bestTimeText.text = "No record";
        }
    }
}