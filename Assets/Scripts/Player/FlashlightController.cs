using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Light Light;
    [SerializeField] AudioSource fleshlight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            fleshlight.Play();
            Light.enabled = !Light.enabled;
        }
    }
}
