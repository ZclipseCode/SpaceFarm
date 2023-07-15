using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCycle : MonoBehaviour
{
    [SerializeField] float dayLength;
    [SerializeField] string resultsSceneName;
    float currentTime;

    private void Start()
    {
        currentTime = dayLength;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(resultsSceneName);
        }
    }

    public float GetCurrentTime()
    {
        return (int)currentTime;
    }
}
