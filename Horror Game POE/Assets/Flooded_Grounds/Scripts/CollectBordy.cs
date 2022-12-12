using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBordy : MonoBehaviour
{
    public PlayerCollector playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerCollector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Player")
        {
            playerScript.points+=1;
            Destroy(gameObject);
            
        }
    }
}
