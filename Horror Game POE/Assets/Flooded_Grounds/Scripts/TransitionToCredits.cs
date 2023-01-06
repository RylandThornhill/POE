using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionToCredits : MonoBehaviour
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
        if (playerScript.points > 7)
        {
            Debug.Log("yujjhyjyjyj"+playerScript.points);
            SceneManager.LoadScene("credits");
        }

    }

    public void BordyCounter(int SceneID)
    {
        
        
     
       
       
    }
}
