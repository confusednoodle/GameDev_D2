using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightHandler : MonoBehaviour
{
    [SerializeField] Material DaySkybox;
    [SerializeField] Material NightSkybox;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            RenderSettings.skybox = DaySkybox;
        }
        if (Input.GetKeyDown("q"))
        {
            RenderSettings.skybox = NightSkybox;
        }
    }
}
