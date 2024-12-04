using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Delay before starting section deletion
    public float delayBeforeDeletion = 15f; 
    // Delay between each deletion batch
    public float delayBetweenDeletes = 8f;  
    private bool canDelete = false; // Flag to enable deletion
    private List<GameObject> sectionsToDelete = new List<GameObject>(); // List of sections to be deleted
    private int deleteBatchSize = 2; // Number of sections to delete at once

    void Start()
    {
        // Start deletion process after the initial delay
        StartCoroutine(StartDeletionAfterDelay());  
    }

    // Add a section to the deletion queue if not already present
    public void AddSectionForDeletion(GameObject section)
    {
        if (!sectionsToDelete.Contains(section))
        {
            sectionsToDelete.Add(section); // Add section to delete list
        }
    }

   
    IEnumerator StartDeletionAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDeletion);  
        canDelete = true; 
        StartCoroutine(DeleteSectionsInBatches());  // Start batch deletion process
    }

    
    IEnumerator DeleteSectionsInBatches()
    {
        while (sectionsToDelete.Count > 0)
        {
            // Stop if the game is over
            if (ObstacleCollision.isGameOver)
                yield break; 

            // Determine how many sections to delete in this batch
            int countToDelete = Mathf.Min(deleteBatchSize, sectionsToDelete.Count);
            for (int i = 0; i < countToDelete; i++)
            {
                GameObject sectionToDelete = sectionsToDelete[0]; // Get the section to delete
                sectionsToDelete.RemoveAt(0); // Remove it from the list

                sectionToDelete.SetActive(false); // Disable the section before deleting it

                // Wait for a short time before permanently deleting the section
                yield return new WaitForSeconds(2f);  

                Destroy(sectionToDelete); // Destroy the section
            }

            // Wait between deletion batches
            yield return new WaitForSeconds(delayBetweenDeletes); 
        }
    }

    void Update()
    {
        
    }
}
