using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireRayCast : MonoBehaviour
{
    int counter = 0;
    [SerializeField]
    TMP_Text marcador;

    [SerializeField]
    GameObject WindowPrefab;
    GameObject instanciaWindow = null;

    Transform rayOrig;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void placeWindow()
    {
        if (instanciaWindow)
        {
            return;
        }

        int layerMask = LayerMask.NameToLayer("Wall");
        RaycastHit hit;
        if (Physics.Raycast(rayOrig.position, rayOrig.forward, out hit, 10f, layerMask))
        {
            Debug.Log("Did Hit");
            instanciaWindow = Instantiate(WindowPrefab, hit.point,Quaternion.identity);
            instanciaWindow.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
        }
    }

    public void fireGun()
    {
        RaycastHit hit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
