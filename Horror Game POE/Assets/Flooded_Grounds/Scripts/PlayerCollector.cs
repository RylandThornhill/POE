using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    public TMP_Text scoreText;
  
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
    }

   
}
