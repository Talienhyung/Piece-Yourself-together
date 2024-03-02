using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;
    public float Dropdistance;
    private List<Image> gameObjectList = new List<Image>();

    public bool isLocked;

    Vector2 objectinitPos;

    // Start is called before the first frame update
    void Start()
    {
        objectinitPos = objectToDrag.transform.position;
        foreach (Transform child in ObjectDragToPos.transform)
        {
            Image subImage = child.GetComponent<Image>();

            ProcessSubImage(subImage);
        }
    }

    public void DragObject()
    {
        if (isLocked)
        {
            return;
        }
        objectToDrag.transform.position = Input.mousePosition;
        
    }

    public void DropObject()
    {
        float Distance = 80;
        Image imageGood = null;
        foreach (Image image in gameObjectList)
        {
            float NewDistanceToImage = Vector3.Distance(objectToDrag.transform.position, image.transform.position);
            if (NewDistanceToImage < Distance)
            {
                Distance = NewDistanceToImage;
                imageGood = image;
            }
        }

        if (Distance < Dropdistance)
        {
            objectToDrag.transform.position = imageGood.transform.position;
            isLocked = true;
            return;
        }
        else
        {
            objectToDrag.transform.position = objectinitPos;
        }
    }

    public void Update()
    {
        if (isLocked)
        {
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
        }
    }

    void ProcessSubImage(Image subImage)
    {
        gameObjectList.Add(subImage);
    }
}
