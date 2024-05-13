using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int lifeTime;
    [SerializeField] int speed;
    [SerializeField] int points = 100;
    private float counter;
     private static AudioSource deathAudio;
    
    void Start()
    {
        counter = lifeTime;
        deathAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (counter <= 0) {
            destroyByTime();
        }
        counter -= Time.deltaTime;
    }




  
    
    public void destroyByTime() {
        
        Destroy(gameObject);
    }

    public static void playDeathSound(Vector3 position) { 
        AudioSource.PlayClipAtPoint(deathAudio.clip, position);
    
    }
}
