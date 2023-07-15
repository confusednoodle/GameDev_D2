using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    public void switchAudioClip(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.Play();
    }

}
