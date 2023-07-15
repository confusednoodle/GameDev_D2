using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class determineClip : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<MusicManagement>().switchAudioClip(clip);
        }
    }
}
