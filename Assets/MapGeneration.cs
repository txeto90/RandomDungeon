using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public List<Room> roomListPrefabs;
    public int manyRooms;  //quantes habitacions vuic que tinga la mazmorra

    private List<Room> roomList = new List<Room>();

    void Start()
    {
        LevelGeneration();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LevelGeneration();
        }
    }


    void LevelGeneration()
    {
        //borrar per si hi ha un altre lvl.
        //destrueix el objecte i despres netejem el llistat
        foreach (var room in roomList)
        {
            Destroy(room.gameObject);
        }
        roomList.Clear();

        //triar habitacio inicial i espamejarla
        {
            int random = Random.Range(0, roomListPrefabs.Count);

            Room roomInit = roomListPrefabs[random];
            GameObject roomObject = Instantiate(roomInit.gameObject, transform);
            Room newRoom = roomObject.GetComponent<Room>();
            roomList.Add(newRoom);
        }

        //anar posant rooms fins a X
        while (roomList.Count < manyRooms)
        {
            int random = Random.Range(0, roomList.Count);
            Room roomOld = roomList[random];    //la habitació que s'ha creat abans i que crearà una nova
            
            int randomDoorIndex = Random.Range(0, roomOld.doorsList.Count);
            Door doorOld = roomOld.doorsList[randomDoorIndex];

            if (doorOld.door != null)
            {
                continue;
            }

            int randomPrefabs = Random.Range(0, roomListPrefabs.Count);
            Room roomNewPrefab = roomListPrefabs[randomPrefabs];
            GameObject roomNewObject = Instantiate(roomNewPrefab.gameObject, transform);
            Room newRoom = roomNewObject.GetComponent<Room>();
            roomList.Add(newRoom);

            //mirar si hi ha algo on va la habitacio




            //posar la nova hab en la posicio correcte
            Vector3 doorOldDirection = (roomOld.transform.position - doorOld.transform.position).normalized;

            newRoom.transform.position = doorOld.transform.position;
            
            //si les habitacions estan centrades mirar el posicionament de X i Y

            Door closestDoor = null;
            float minDist = float.MaxValue;
            foreach (var door in newRoom.doorsList)
            {
                var dist = Vector3.Distance(roomOld.transform.position, door.transform.position);

                if(dist < minDist)
                {
                    minDist = dist;
                    closestDoor = door;
                }

            }

            newRoom.transform.position += (newRoom.transform.position - closestDoor.transform.position);
            doorOld.door = closestDoor;
            closestDoor.door = doorOld;

            //Debug.Log(n);

        }


       


    }
}
