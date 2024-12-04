using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 59;
    public bool creatingSection = false;
    public int secNum;
    private Destroy destroyScript; 
    void Start()
    {
     
        destroyScript = FindObjectOfType<Destroy>();
    }

    void Update()
    {
         if (ObstacleCollision.isGameOver)
            return;
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 1);
        GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 59;

        destroyScript.AddSectionForDeletion(newSection);

        yield return new WaitForSeconds(5);
        creatingSection = false;
    }
}
