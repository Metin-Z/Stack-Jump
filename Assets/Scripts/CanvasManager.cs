using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject retry_BTN;
    public TextMeshProUGUI score_TMPRO;
    public int score=0;
    public void Update()
    {
        score_TMPRO.text = score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
