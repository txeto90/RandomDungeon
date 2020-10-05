using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public List<Door> doorsList;
    public BoxCollider2D box;
    
    void Awake()
    {
        doorsList = new List<Door> (GetComponentsInChildren<Door>());
        box = GetComponent<BoxCollider2D>();


    }

    
    void Update()
    {
        
    }
}
