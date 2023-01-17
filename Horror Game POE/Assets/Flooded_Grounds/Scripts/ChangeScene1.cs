using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene1 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10.0f;
    private float timeElapsed;
    [SerializeField]
    public string sceneNameToLoad;

  

    private void Update()
    {
        timeElapsed += Time.deltaTime;


        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }



}
