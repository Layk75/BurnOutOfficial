using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject Pause_Panel;

    private bool isPaused = false;
    // Start is called before the first frame update

    void Start()
    {
        Pause_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause_Panel.activeInHierarchy) { PauseGame(); }
        else { ResumeGame(); }

    }
    public void PauseGame()
    {
        Pause_Panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        Pause_Panel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public bool IsPaused()
    {
        return isPaused;
    }
}
