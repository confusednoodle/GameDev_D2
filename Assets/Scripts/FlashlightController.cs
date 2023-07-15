using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Light Light;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Light.enabled = !Light.enabled;
        }
    }
}
