using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollector : MonoBehaviour
{
    public Text scoreText;
  
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
       scoreText.text = points.ToString() + " ";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Bordies Collected: " + points.ToString() + " ";
        Debug.Log(scoreText.text);
    }

   
}
