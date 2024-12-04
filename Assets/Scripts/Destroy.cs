using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float delayBeforeDeletion = 15f; 
    public float delayBetweenDeletes = 8f;  
    private bool canDelete = false;      
    private List<GameObject> sectionsToDelete = new List<GameObject>(); 
    private int deleteBatchSize = 2; 

    void Start()
    {
        StartCoroutine(StartDeletionAfterDelay());  
    }

   
    public void AddSectionForDeletion(GameObject section)
    {
        if (!sectionsToDelete.Contains(section))
        {
            sectionsToDelete.Add(section); 
        }
    }

    
    IEnumerator StartDeletionAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDeletion);  
        canDelete = true;  
        StartCoroutine(DeleteSectionsInBatches());  
    }

    
    IEnumerator DeleteSectionsInBatches()
    {
        while (sectionsToDelete.Count > 0)
        {
            if (ObstacleCollision.isGameOver)
            yield break; 

          
            int countToDelete = Mathf.Min(deleteBatchSize, sectionsToDelete.Count);
            for (int i = 0; i < countToDelete; i++)
            {
                GameObject sectionToDelete = sectionsToDelete[0]; 
                sectionsToDelete.RemoveAt(0); 

               
                sectionToDelete.SetActive(false); 

               
                yield return new WaitForSeconds(2f);  

                Destroy(sectionToDelete); 
            }

           
            yield return new WaitForSeconds(delayBetweenDeletes); 
        }
    }

    void Update()
    {
        
    }
}