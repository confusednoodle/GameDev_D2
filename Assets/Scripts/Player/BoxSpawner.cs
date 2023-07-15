using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] float DistanceFromCamera = 1;
    [SerializeField] GameObject Box;

    GameObject currentBox = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBox == null)
        {
            SpawnAndHoldTheBox();

            // TODO: check for box in direction and pick it up
        }

        // always update box position if still holding it
        if (currentBox != null)
        {
            UpdateBoxTransform();
        }


        // release the box
        if (Input.GetMouseButtonUp(0))
        {
            currentBox = null;
        }
    }

    void SpawnAndHoldTheBox()
    {
        // spawn a new box
        currentBox = Instantiate(Box, Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera, Camera.main.transform.rotation);
    }

    void UpdateBoxTransform()
    {
        currentBox.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromCamera;
        currentBox.transform.rotation = Camera.main.transform.rotation;
    }
}
