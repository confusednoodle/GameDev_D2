using Unity.VisualScripting;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] float DistanceFromCamera = 1;
    [SerializeField] float PickupDistance = 2.5f;
    [SerializeField] GameObject Box;
    [SerializeField] UITextureSelection UITextureSelection;

    [SerializeField] GameObject Companion;

    GameObject currentBox = null;
    Texture currentTexture = null;

    private bool isCompanion = false;
    private GameObject bastard = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBox == null)
        {
            if (!UITextureSelection.IsCompanionCube())
            {
                currentTexture = UITextureSelection.GetCurrentTexture();
                isCompanion = false;
            }
            else
            {
                isCompanion = true;
            }

            // check if box is hit
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, PickupDistance))
            {
                
                if (hit.collider.gameObject.tag == "Box")
                {
                    
                    if (!(hit.collider.gameObject == bastard))
                    {
                        currentTexture = hit.collider.gameObject.GetComponent<Renderer>().material.mainTexture;
                        
                        // Destroy the hit box
                        Destroy(hit.collider.gameObject);
                    }
                    else if (hit.collider.gameObject == bastard)
                    {
                        
                        isCompanion = true;
                        Destroy(bastard);
                    }
                }
            }

            SpawnAndHoldTheBox();
        }

        // always update box position if still holding it
        if (currentBox != null)
        {
            UpdateBoxTransform();
        }


        // release the box
        if (Input.GetMouseButtonUp(0))
        {
            currentBox.GetComponent<BoxCollider>().enabled = true; // reenable collider
            currentBox = null;
        }
    }

    void SpawnAndHoldTheBox()
    {
        if (!isCompanion)
        {
            // spawn a new box
            currentBox = Instantiate(Box, Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera, Camera.main.transform.rotation);
            currentBox.GetComponent<BoxCollider>().enabled = false;
            currentBox.gameObject.GetComponent<Renderer>().material.mainTexture = currentTexture;
        }
        else if (isCompanion)
        {
            if (!(bastard == null))
            {
                Destroy(bastard);
            }
            //spawn companion cube that fucking bastard
            currentBox = Instantiate(Companion, Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera, Camera.main.transform.rotation);
            bastard = currentBox;
            currentBox.GetComponent<BoxCollider>().enabled = false;
        }
        
    }

    void UpdateBoxTransform()
    {
        currentBox.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera;
        currentBox.transform.rotation = Camera.main.transform.rotation;
    }
}
