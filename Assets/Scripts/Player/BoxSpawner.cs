using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] float DistanceFromCamera = 1;
    [SerializeField] float PickupDistance = 2.5f;
    [SerializeField] GameObject Box;
    [SerializeField] UITextureSelection UITextureSelection;

    GameObject currentBox = null;
    Texture currentTexture = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBox == null)
        {
            if (!UITextureSelection.IsCompanionCube())
            {
                currentTexture = UITextureSelection.GetCurrentTexture();
            }

            // check if box is hit
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, PickupDistance))
            {
                if (hit.collider.gameObject.tag == "Box")
                {
                    currentTexture = hit.collider.gameObject.GetComponent<Renderer>().material.mainTexture;
                    // Destroy the hit box
                    Destroy(hit.collider.gameObject);
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
        // spawn a new box
        currentBox = Instantiate(Box, Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera, Camera.main.transform.rotation);
        currentBox.GetComponent<BoxCollider>().enabled = false;
        currentBox.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", currentTexture);
    }

    void UpdateBoxTransform()
    {
        currentBox.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera;
        currentBox.transform.rotation = Camera.main.transform.rotation;
    }
}
