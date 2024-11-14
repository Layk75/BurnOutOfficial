using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class CustomLoadBar : MonoBehaviour
{
    public Image loadBarFill;  // Reference to the Image component that fills the bar
    public float loadAmountPerPress = 0.05f;  // The amount the bar fills per space press
    public float unloadSpeed = 0.3f;  // The speed at which the bar decreases over time

    private float currentFillAmount = 0f;  // Tracks the current fill amount

    void Update()
    {
        // Increase the fill amount when the space button is pressed, but only if the bar is not full
        if (Input.GetKeyDown(KeyCode.Space) && currentFillAmount < 1f)
        {
            currentFillAmount += loadAmountPerPress; // Increase fill amount
        }

        // Decrease the fill amount over time when the space button is not pressed
        if (currentFillAmount > 0f && currentFillAmount < 1f)
        {
            currentFillAmount -= unloadSpeed * Time.deltaTime; // Decrease fill amount
        }

        // Clamp the value between 0 and 1 to avoid overflow or underflow
        currentFillAmount = Mathf.Clamp(currentFillAmount, 0f, 1f);

        // Update the Image fillAmount property to visually represent the current fill level
        loadBarFill.fillAmount = currentFillAmount;

        // Check if the load bar is full
        if (currentFillAmount >= 1f)
        {
            // Load the minigames_table scene
            SceneManager.LoadScene("CoffeeMiniGameScene");
        }
    }

    // Optionally, you can call this to disable the load bar or any other cleanup
    public void DisableLoadingBar()
    {
        // Additional cleanup logic if needed
    }
}
