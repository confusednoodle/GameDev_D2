using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextureSelection : MonoBehaviour
{
    [SerializeField] Transform Selector;
    [SerializeField] Transform[] SelectionPositions;
    [SerializeField] Texture[] Textures;

    Texture currentTexture;
    bool companionCube;

    void Start()
    {
        currentTexture = Textures[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            companionCube = false;
            currentTexture = Textures[0];
            Selector.position = SelectionPositions[0].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            companionCube = false;
            currentTexture = Textures[1];
            Selector.position = SelectionPositions[1].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            companionCube = false;
            currentTexture = Textures[2];
            Selector.position = SelectionPositions[2].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            companionCube = false;
            currentTexture = Textures[3];
            Selector.position = SelectionPositions[3].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            companionCube = true;
            Selector.position = SelectionPositions[4].position;
        }
    }

    public bool IsCompanionCube()
    {
        return companionCube;
    }

    public Texture GetCurrentTexture()
    {
        return currentTexture;
    }
}
