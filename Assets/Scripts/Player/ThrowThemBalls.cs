using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// https://www.youtube.com/watch?v=OGQSFLGpiBA
public class ThrowThemBalls : MonoBehaviour
{
    [SerializeField] float Force;
    [SerializeField] Rigidbody Ball; // :3

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody BallInstance = Instantiate(Ball, transform.position, Quaternion.identity);
            BallInstance.AddForce(Camera.main.transform.forward * Force, ForceMode.Impulse);
        }
    }
}
