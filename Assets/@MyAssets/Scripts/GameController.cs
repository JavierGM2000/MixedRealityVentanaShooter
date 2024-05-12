using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool gameRunning;
    [SerializeField] private List<Transform> spawnPointList;
    [SerializeField] int spawnCoolDown;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning) { 
        
        
        }
        
    }
}
