using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool gameRunning;
    public static int score;

    [SerializeField] private List<Transform> spawnPointList;
    [SerializeField] int spawnCoolDown;
    [SerializeField] GameObject targetPrefab;
    [SerializeField] public GameObject muzzleFash;
 
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning) {
            if (counter >= spawnCoolDown) {
                
                int randomIndex = UnityEngine.Random.Range(0, 7);
                spawnTarget(randomIndex);
                counter = 0;
            }
            
            counter += Time.deltaTime;
        }
        
    }

 

    private void spawnTarget(int index)
    {

        Vector3 position =  spawnPointList[index].position;
        GameObject spawnedPrefab = Instantiate(targetPrefab, position, transform.rotation);
        spawnedPrefab.transform.Rotate(new Vector3(0,180,0));
        
    }


}
