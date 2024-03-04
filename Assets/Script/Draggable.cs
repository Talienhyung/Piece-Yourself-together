using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private bool locked = false;
    private Vector3 offset;
    private Vector3 endpos;
    private bool isRightButtonDown = false;
    public GameObject gridObject;

    public List<Vector3> blockPositions = new List<Vector3>();
    public List<GameObject> gameObjectList = new List<GameObject>();

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPos();
        }
    }

    private void OnMouseUp()
    {
        if (!locked) {
            isDragging = false;
            blockdetect();
            if (onTile())
            {
                switch (name)
                {
                    case string n when n.Contains("cube"):
                        endpos = blockPositions[0];
                        break;

                    case string n when n.Contains("(0)"):
                        endpos = blockPositions[0] + new Vector3(-0.2f, -0.2f, 0f);
                        break;

                    case string n when n.Contains("(4)"):
                        switch (gameObject.transform.rotation.eulerAngles.z)
                        {
                            case 0:
                            case 180:
                                endpos = blockPositions[0] + new Vector3(-0.2f, 0f, 0f);
                                break;

                            case 90:
                            case 270:
                                endpos = blockPositions[0] + new Vector3(0f, -0.2f, 0f);
                                break;
                        }
                        break;

                    case string n when n.Contains("(1)"):
                        switch (gameObject.transform.rotation.eulerAngles.z)
                        {
                            case 0:
                            case 180:
                                endpos = blockPositions[0] + new Vector3(0f, -0.6f, 0f);
                                break;

                            case 90:
                            case 270:
                                endpos = blockPositions[0] + new Vector3(0.6f, 0f, 0f);
                                break;
                        }
                        break;

                    case string n when n.Contains("(3)"):
                        switch (gameObject.transform.rotation.eulerAngles.z)
                        {
                            case 0:
                                endpos = blockPositions[0] + new Vector3(0.2f, -0.4f, 0f);
                                break;
                            case 90:
                                endpos = blockPositions[0] + new Vector3(0.4f, 0.2f, 0f);
                                break;

                            case 180:
                                endpos = blockPositions[0] + new Vector3(0.2f, -0.4f, 0f);
                                break;
                            case 270:
                                endpos = blockPositions[0] + new Vector3(-0.4f, -0.2f, 0f);
                                break;
                        }
                        break;

                    case string n when n.Contains("(2)"):
                        switch (gameObject.transform.rotation.eulerAngles.z)
                        {
                            case 0:
                                endpos = blockPositions[0] + new Vector3(0f, 0.2f, 0f);
                                break;
                            case 90:
                                endpos = blockPositions[0] + new Vector3(-0.2f, 0f, 0f);
                                break;
                            case 180:
                                endpos = blockPositions[0] + new Vector3(0f, -0.2f, 0f);
                                break;
                            case 270:
                                endpos = blockPositions[0] + new Vector3(0.2f, 0f, 0f);
                                break;
                        }
                        break;
                }
                locked = true;
                gameObject.transform.SetParent(gridObject.transform);
            }
        }
    }

    private void Update()
    {
        if (isDragging && !locked)
        {
            Vector3 mousePos = GetMouseWorldPos();
            gameObject.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, gameObject.transform.position.z);
            if (Input.GetMouseButtonDown(1)) // Bouton droit de la souris enfoncé
            {
                StartCoroutine(WaitAndRotate());
            }
            else if (Input.GetMouseButtonUp(1)) // Bouton droit de la souris relâché
            {
                StopCoroutine(WaitAndRotate());
            }
            onOtherSame();
        }
        else if (locked)
        {
            gameObject.transform.position = endpos;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.forward, 90f);
    }

    IEnumerator WaitAndRotate()
    {
        isRightButtonDown = true;
        yield return new WaitForSeconds(0.2f); // Attendre 1 seconde

        // Vérifier à nouveau si le bouton droit de la souris est enfoncé après 1 seconde
        if (isRightButtonDown)
        {
            RotateObject();
        }
    }

    private void blockdetect()
    {
        Vector3 center = gameObject.transform.position;
        switch (name)
        {
            case string n when n.Contains("cube"):
                blockPositions.Add(center);
                break;
            case string n when n.Contains("(0)"):
                blockPositions.Add(center + new Vector3(0.2f, 0.2f, 0f));
                blockPositions.Add(center + new Vector3(-0.2f, -0.2f, 0f));
                blockPositions.Add(center + new Vector3(-0.2f, 0.2f, 0f));
                blockPositions.Add(center + new Vector3(0.2f, -0.2f, 0f));
                break;

            case string n when n.Contains("(4)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                    case 180:
                        blockPositions.Add(center + new Vector3(0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, 0.4f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, -0.4f, 0f));
                        break;

                    case 90:
                    case 270:
                        blockPositions.Add(center + new Vector3(0f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(-0.4f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0.4f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, -0.2f, 0f));
                        break;
                }
                break;

            case string n when n.Contains("(1)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                    case 180:
                        blockPositions.Add(center + new Vector3(0f, 0.6f, 0f));
                        blockPositions.Add(center + new Vector3(0f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, -0.6f, 0f));
                        break;

                    case 90:
                    case 270:
                        blockPositions.Add(center + new Vector3(-0.6f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(0.6f, 0f, 0f));
                        break;
                }
                break;

            case string n when n.Contains("(3)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                        blockPositions.Add(center + new Vector3(-0.2f, 0.4f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, -0.4f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, -0.4f, 0f));
                        break;
                    case 90:
                        blockPositions.Add(center + new Vector3(-0.4f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0.4f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0.4f, 0.2f, 0f));
                        break;

                    case 180:
                        blockPositions.Add(center + new Vector3(-0.2f, 0.4f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, 0.4f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, -0.4f, 0f));
                        break;
                    case 270:
                        blockPositions.Add(center + new Vector3(0.4f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(-0.4f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(-0.4f, -0.2f, 0f));
                        break;
                }
                break;

            case string n when n.Contains("(2)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                        blockPositions.Add(center + new Vector3(0f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(-0.4f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0.4f, 0.2f, 0f));
                        break;
                    case 90:
                        blockPositions.Add(center + new Vector3(0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, 0.4f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(-0.2f, -0.4f, 0f));
                        break;

                    case 180:
                        blockPositions.Add(center + new Vector3(0f, 0.2f, 0f));
                        blockPositions.Add(center + new Vector3(-0.4f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0f, -0.2f, 0f));
                        blockPositions.Add(center + new Vector3(0.4f, -0.2f, 0f));
                        break;
                    case 270:
                        blockPositions.Add(center + new Vector3(-0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, 0.4f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, 0f, 0f));
                        blockPositions.Add(center + new Vector3(0.2f, -0.4f, 0f));
                        break;
                }
                break;
        }

        foreach (Vector3 position in blockPositions)
        {
            Debug.Log("Position du bloc : " + position);
        }
    }

    public bool onTile()
    {
        Transform parentTransform = gridObject.transform;
        int good = 0;

        foreach (Transform childTransform in parentTransform)
        {
        
            GameObject childObject = childTransform.gameObject;

            if (childObject.name.Contains("Tile")){ 
                foreach (Vector3 position in blockPositions)
                {
                    // Créer des vecteurs de position en ne tenant compte que des composantes X et Y
                    Vector2 childPosXY = new Vector2(childTransform.position.x, childTransform.position.y);
                    Vector2 blockPosXY = new Vector2(position.x, position.y);

                    // Calculer la distance uniquement sur les axes X et Y
                    float distanceXY = Vector2.Distance(childPosXY, blockPosXY);
                    Debug.Log("position : " + childTransform.position);
                    Debug.Log("Distance XY : " + distanceXY);

                    // Si la distance XY est inférieure à 0.2, incrémenter le compteur good
                    if (distanceXY < 0.2f)
                    {
                        blockPositions[blockPositions.IndexOf(position)] = childTransform.position;
                        good++;
                        gameObjectList.Add(childTransform.gameObject);
                        break; // Sortir de la boucle interne si une position correspond
                    }
                }
            }

            if (good == 4 || (good==1 && name.Contains("cube")))
            {
                foreach (GameObject item in gameObjectList)
                {
                    Destroy(item);
                }
                gameObjectList.Clear();
                return true;
            }
        }
        gameObjectList.Clear();
        return false;
    }

    public void onOtherSame()
    {
        Transform parentTransform = gridObject.transform;

        foreach (Transform childTransform in parentTransform)
        {

            GameObject childObject = childTransform.gameObject;
            string cname = childObject.name;
            if (!cname.Contains("Tile"))
            {
                if (samePiece(cname, childObject))
                {
                    Vector2 childPosXY = new Vector2(childTransform.position.x, childTransform.position.y);
                    Vector2 blockPosXY = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

                    // Calculer la distance uniquement sur les axes X et Y
                    float distanceXY = Vector2.Distance(childPosXY, blockPosXY);

                    // Si la distance XY est inférieure à 0.4, incrémenter le compteur good
                    if (distanceXY < 0.4f)
                    {
                        endpos = childTransform.position;
                        Destroy(childObject);
                        gameObject.transform.SetParent(gridObject.transform);
                        locked = true;
                        return;
                    }
                }
            }
        }
    }

    public bool samePiece(string namePiece, GameObject gameOb)
    {
        switch (name)
        {
            case string n when n.Contains("cube"):
                return namePiece.Contains("cube");
                break;
            case string n when n.Contains("(0)"):
                return namePiece.Contains("(0)");
                break;

            case string n when n.Contains("(4)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                    case 180:
                        return (namePiece.Contains("(4)") && gameOb.transform.rotation.eulerAngles.z == 0)||( namePiece.Contains("(4)") && gameOb.transform.rotation.eulerAngles.z == 180);
                        break;

                    case 90:
                    case 270:
                        return (namePiece.Contains("(4)") && gameOb.transform.rotation.eulerAngles.z == 90) || (namePiece.Contains("(4)") && gameOb.transform.rotation.eulerAngles.z == 270);   
                }
                break;

            case string n when n.Contains("(1)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                    case 180:
                        return (namePiece.Contains("(1)") && gameOb.transform.rotation.eulerAngles.z == 0) || (namePiece.Contains("(1)") && gameOb.transform.rotation.eulerAngles.z == 180);
                        break;  

                    case 90:
                    case 270:
                        return (namePiece.Contains("(1)") && gameOb.transform.rotation.eulerAngles.z == 90) || (namePiece.Contains("(1)") && gameOb.transform.rotation.eulerAngles.z == 270);   
                }
                break;

            case string n when n.Contains("(3)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                        return namePiece.Contains("(3)") && gameOb.transform.rotation.eulerAngles.z == 0;
                        break;
                    case 90:
                        return namePiece.Contains("(3)") && gameOb.transform.rotation.eulerAngles.z == 90;
                        break;

                    case 180:
                        return namePiece.Contains("(3)") && gameOb.transform.rotation.eulerAngles.z == 180;
                        break;
                    case 270:
                        return namePiece.Contains("(3)") && gameOb.transform.rotation.eulerAngles.z == 270;
                        break;
                }
                break;

            case string n when n.Contains("(2)"):
                switch (gameObject.transform.rotation.eulerAngles.z)
                {
                    case 0:
                        return namePiece.Contains("(2)") && gameOb.transform.rotation.eulerAngles.z == 0;
                        break;
                    case 90:
                        return namePiece.Contains("(2)") && gameOb.transform.rotation.eulerAngles.z == 90;
                        break;

                    case 180:
                        return namePiece.Contains("(2)") && gameOb.transform.rotation.eulerAngles.z == 180;
                        break;
                    case 270:
                        return namePiece.Contains("(2)") && gameOb.transform.rotation.eulerAngles.z == 270; 
                        break;
                }
                break;
        }
        return false;
    }
    
}

