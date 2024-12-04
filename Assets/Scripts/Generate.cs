using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    // Array to store different sections that can be generated
    public GameObject[] section;
    // Initial position on the z-axis for generating sections
    public int zPos = 59;
    
    public bool creatingSection = false;
    // Variable to store the selected section index
    public int secNum;
    private Destroy destroyScript; // Reference to the Destroy script

    void Start()
    {
        // Find and assign the Destroy script to handle section deletion
        destroyScript = FindObjectOfType<Destroy>();
    }

    void Update()
    {
        // Stop execution if the game is over
        if (ObstacleCollision.isGameOver)
            return;

        // Generate a new section if one is not currently being created
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        // Randomly select a section to instantiate
        secNum = Random.Range(0, 1);
        GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 59; // Update the z position for the next section

        // Add the newly created section to the deletion queue
        destroyScript.AddSectionForDeletion(newSection);

        // Wait for 5 seconds before generating another section
        yield return new WaitForSeconds(5);
        creatingSection = false;
    }
}
