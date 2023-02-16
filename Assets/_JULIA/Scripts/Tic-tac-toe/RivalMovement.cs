using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RivalMovement : MonoBehaviour
{
    [SerializeField] Transform upLeft;
    [SerializeField] Transform upMid;
    [SerializeField] Transform upRight;
    [SerializeField] Transform midLeft;
    [SerializeField] Transform midMid;
    [SerializeField] Transform midRight;
    [SerializeField] Transform downLeft;
    [SerializeField] Transform downMid;
    [SerializeField] Transform downRight;   
    private List<Vector3> positionsList; //lista de posiciones del tablero
    private List<Collider> colliderList;
    [SerializeField] GameObject cross1;
    [SerializeField] GameObject cross2;
    [SerializeField] GameObject cross3;
    [SerializeField] GameObject circle1;
    [SerializeField] GameObject circle2;
    [SerializeField] GameObject circle3;

    // Start is called before the first frame update
    void Start()
    {
        //añadir valores a las listas
        positionsList.Add(upLeft.position);
        positionsList.Add(upMid.position);
        positionsList.Add(upRight.position);
        positionsList.Add(midLeft.position);
        positionsList.Add(midMid.position);
        positionsList.Add(midRight.position);
        positionsList.Add(downLeft.position);
        positionsList.Add(downMid.position);
        positionsList.Add(downRight.position);

        colliderList.Add(upLeft.GetComponent<Collider>());
        colliderList.Add(upMid.GetComponent<Collider>());
        colliderList.Add(upRight.GetComponent<Collider>());
        colliderList.Add(midLeft.GetComponent<Collider>());
        colliderList.Add(midMid.GetComponent<Collider>());
        colliderList.Add(midRight.GetComponent<Collider>());
        colliderList.Add(downLeft.GetComponent<Collider>());
        colliderList.Add(downMid.GetComponent<Collider>());
        colliderList.Add(downRight.GetComponent<Collider>());

    }
    public void Update()
    {
        foreach (Vector3 position in positionsList)
        {
            foreach(Collider collider in colliderList)
            {
                if (collider.bounds.Contains(cross1.transform.position))
                {
                    Debug.Log("dentro de cross 1");
                    positionsList.Remove(position);
                    int randomIndex = Random.Range(0, positionsList.Count);
                    circle1.transform.position = positionsList[randomIndex];
                }
                else if (collider.bounds.Contains(cross2.transform.position))
                {
                    Debug.Log("dentro de cross 2");
                    positionsList.Remove(position);
                    int randomIndex = Random.Range(0, positionsList.Count);
                    circle2.transform.position = positionsList[randomIndex];
                }
                else if (collider.bounds.Contains(cross3.transform.position))
                {
                    Debug.Log("dentro de cross 3");
                    positionsList.Remove(position);
                    int randomIndex = Random.Range(0, positionsList.Count);
                    circle3.transform.position = positionsList[randomIndex];
                }
            }
        }
    }
}
