﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHat : MonoBehaviour
{
    public Cup cup; // Reference to the Cup

    private Vector3 offset;
    private bool isDragging = false;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        // Capture the offset between mouse position and object position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Move the object with the mouse
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0; // Keep Z axis unchanged
            transform.position = newPosition;
        }
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    private void Update()
    {
        // Check if the cup is filled
        if (cup != null && cup.IsFilled)
        {
            Debug.Log("The cup is already filled. You can't pour more coffee.");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cup"))
        {
            // Trigger the machine to show that coffee beans have been added
            if (!other.GetComponent<Cup>().IsFilled)
                return;
            other.GetComponent<Cup>().CloseCup();
            Destroy(gameObject); // Remove the coffee beans from the scene
        }
    }
}
