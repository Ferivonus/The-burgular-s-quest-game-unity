using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objected
{
    private string RoomName;
    GameObject[] Objects;

    public Objected(GameObject[] objects, string roomName) 
    {
        RoomName = roomName;
        Objects = objects;
    }
    public void SetFully(GameObject[] objects, string roomName )
    {
        RoomName = roomName;
        Objects = objects;
    }
    public void SetObject(GameObject[] objects)
    {
        Objects = objects;
    }
    public GameObject[] GetObject()
    {
        return Objects;
    }
    public string GetRoomName()
    {
        return RoomName;
    }
    public int GetLength()
    {
        return Objects.Length;
    }
    
}


public class newMapAndGameGenerator : MonoBehaviour
{
    public GameObject[] houses;
    public GameObject[] RandomObjectsAndHouses;

    public string[] house_names = new string[7];



    public GameObject[] Kitchen_Objects;
    public GameObject[] Office_objects;
    public GameObject[] Room3_objects;
    public GameObject[] Room4_objects;
    public GameObject[] Room5_objects;
    public GameObject[] Room6_objects;
    public GameObject[] Room7_objects;


    LinkedList<Objected> ListedGameObject = new();

    private GameObject[] Adaptor(GameObject[] objects, int[] AdaptedNumArr, GameObject[] ToAdopt)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            int j = AdaptedNumArr[i];
            ToAdopt[i] = objects[j];
        }
        return ToAdopt;
    }

    private void Start()
    {
        LinkedListAdaptation();
        GameObject[] Objacts_arr;
        GameObject[] Room_arr = new GameObject[7];
        GameObject[] RandomBulding_arr = new GameObject[10];


        int[] roomIntArr = new int[7];
        int[] RandomItemIntArr = new int[10];

        RandomItemIntArr = Calculator(objects: RandomObjectsAndHouses, maxSize: RandomObjectsAndHouses.Length);
        RandomBulding_arr = Adaptor(objects: RandomObjectsAndHouses, AdaptedNumArr: RandomItemIntArr, ToAdopt: RandomBulding_arr);
        Place(wanted: RandomBulding_arr, MaxSize: RandomBulding_arr.Length, WhatItIs: "Bulding");


        roomIntArr = Calculator(objects: houses, maxSize: houses.Length);
        Room_arr = Adaptor(objects: houses, AdaptedNumArr: roomIntArr, ToAdopt: Room_arr);
        Place(wanted: Room_arr, MaxSize: Room_arr.Length, WhatItIs: "house");





        foreach (Objected i in ListedGameObject)
        {
            //I literally make that function, but I won't write an explanation of that.
            i.SetObject(Adaptor(i.GetObject(), AdaptedNumArr: Calculator(i.GetObject(), i.GetLength()), ToAdopt: Objacts_arr = new GameObject[i.GetLength()]));
            Place(wanted: i.GetObject(), i.GetLength(), i.GetRoomName());
        }
    }

    private void LinkedListAdaptation()
    {


        Objected obj = new(Kitchen_Objects, house_names[0]);
        ListedGameObject.AddLast(obj);

        obj.SetFully(Office_objects, house_names[1]);
        ListedGameObject.AddLast(obj);

        obj.SetFully(Room3_objects, house_names[2]);
        ListedGameObject.AddLast(obj);

        obj.SetFully(Room4_objects, house_names[3]);
        ListedGameObject.AddLast(obj);

        obj.SetFully(Room5_objects, house_names[4]);
        ListedGameObject.AddLast(obj);

        obj.SetFully(Room6_objects, house_names[5]);
        ListedGameObject.AddLast(obj);

        obj.SetFully(Room7_objects, house_names[6]);
        ListedGameObject.AddLast(obj);

        //ListedGameObject.RemoveFirst();
    }



    private int[] Calculator(GameObject[] objects, int maxSize)
    {
        int[] RandomNumberarray = new int[maxSize];
        for (int i = 0; i < RandomNumberarray.Length; i++)
        {
            do
            {
                RandomNumberarray[i] = Random.Range(0, objects.Length);
            } while (Controller(RandomNumberarray, RandomNumberarray.Length, i));
        }
        return RandomNumberarray;
    }

    private bool Controller(int[] random_Number, int length, int turn)
    {
        for (int controller = 0; controller < length; controller++)
        {
            if (turn != controller)
            {
                if (random_Number[turn] == random_Number[controller])
                {
                    return true;
                }
            }

        }
        return false;
    }

    

    private void Place(GameObject[] wanted, int MaxSize, string WhatItIs)
    {
        for (int i = 0; i < MaxSize; i++)
        {
            string FullName = WhatItIs + " (" + i + ")";
            if (Instantiate(wanted[i], GameObject.Find(FullName).transform.position, Quaternion.identity)) { }
            else break;
        }
    }
}
