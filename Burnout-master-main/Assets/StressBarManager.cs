using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StressBarManager : MonoBehaviour
{
    public static StressBarManager instance;
    public Slider stressBar;      // Reference to the Slider UI
    public float stressDuration = 180f;  // 3 minutes = 180 seconds
    private float stressTimeLeft; // Time left for the bar to empty

    private void Awake()
    {
        // Singleton pattern to ensure only one StressBarManager instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist the Canvas with the stress bar
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate Canvas instances
            return;
        }
    }

    private void Start()
    {
        // Initialize the stress bar at full value
        stressTimeLeft = stressDuration;
        if (stressBar != null)
        {
            stressBar.maxValue = stressDuration;
            stressBar.value = stressDuration;
        }
    }

    private void Update()
    {
        // Countdown the stress time
        if (stressTimeLeft > 0)
        {
            stressTimeLeft -= Time.deltaTime;
            if (stressBar != null)
            {
                stressBar.value = stressTimeLeft;
            }
        }
        else
        {
            if (stressBar != null)
            {
                stressBar.value = 0f;
                // Add logic for "You Lose" here if needed
            }
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-assign the stressBar reference in the new scene if needed
        Slider newStressBar = FindObjectOfType<Slider>();
        if (newStressBar != null && newStressBar != stressBar)
        {
            stressBar = newStressBar;
            stressBar.maxValue = stressDuration;
            stressBar.value = stressTimeLeft;
        }
    }
}
