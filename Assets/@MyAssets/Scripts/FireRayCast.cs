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

    [SerializeField]
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
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(rayOrig.position, rayOrig.forward, out hit, 10f, layerMask))
        {
            Debug.Log("Did Hit");
            instanciaWindow = Instantiate(WindowPrefab, hit.point,Quaternion.identity);
            instanciaWindow.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

            marcador = GameObject.Find("Marcador").GetComponent<TMP_Text>();
        }
    }

    public void fireGun()
    {
        int layerMask = LayerMask.NameToLayer("Impactable");
        layerMask = ~layerMask;
        RaycastHit[] hits;
        hits = Physics.RaycastAll(rayOrig.position, rayOrig.forward, 10f, layerMask);

        bool windowHit = false;
        List<Transform> globosHit = new List<Transform>();

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.tag == "Ventana")
            {
                windowHit = true;
            }
            else if (hit.transform.tag == "Globo")
            {
                globosHit.Add(hit.transform);
            }
        }

        if (windowHit)
        {
            foreach (Transform tran in globosHit)
            {
                counter++;
                Destroy(tran.gameObject);
            }

            marcador.text = counter.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
