using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    [SerializeField] AudioSource villageTrack;
    [SerializeField] AudioSource forrestTrack;
    [SerializeField] AudioSource thePitTMTrack;

    [SerializeField] GameObject test;
    [SerializeField] GameObject villageTrigger;
    [SerializeField] GameObject forrestTrigger;
    [SerializeField] GameObject forrestTrigger2;
    [SerializeField] GameObject forrestTrigger3;
    [SerializeField] GameObject thePitTMTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == villageTrigger)
        {
            villageTrack.Play();
        }
        else if (collision.gameObject == forrestTrigger | collision.gameObject == forrestTrigger2 | collision.gameObject == forrestTrigger3)
        {
            forrestTrack.Play();
        }
        else if (collision.gameObject == thePitTMTrigger)
        {
            thePitTMTrack.Play();
        }
        else if (collision.gameObject == test)
        {
            thePitTMTrack.Play();
        }
    }
}
