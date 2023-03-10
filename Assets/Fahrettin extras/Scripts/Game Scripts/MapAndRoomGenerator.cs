using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAndRoomGenerator : MapGlobalVeriables
{
    public GameObject[] objects;
    public string WhatIamWorking;

    public GameObject[] Rooms;
    

    private GameObject[] Objacts_arr;
    private GameObject[] Room_arr;
    
    private int ObjectMaxSize = 0;
    private int RoomMaxSize = 0;

    private int[] FinalArrayObjects;
    private readonly int[] FinalArrayRooms =null;

    private void Start()
    { 

        ObjectMaxSize = objects.Length;
        RoomMaxSize = Rooms.Length;

        Objacts_arr = new GameObject[ObjectMaxSize];
        Room_arr = new GameObject[RoomMaxSize];

        FinalArrayObjects = Calculator(maxSize: ObjectMaxSize);
        //FinalArrayRooms = Calculator(maxSize: RoomMaxSize);

        Objacts_arr = Adaptor(AdaptedNumArr: FinalArrayObjects, ToAdopt: Objacts_arr);

        //Room_arr = Adaptor(AdaptedNumArr: FinalArrayRooms, ToAdopt: Room_arr);

        Place(wanted: Objacts_arr, MaxSize: ObjectMaxSize, WhatItIs: WhatIamWorking);

    }

    private int[] Calculator(int maxSize)
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

    private GameObject[] Adaptor(int[] AdaptedNumArr, GameObject[] ToAdopt)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            int j = AdaptedNumArr[i];
            ToAdopt[i] = objects[j];
        }
        return ToAdopt;
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


    protected GameObject GetSpesificObject_FinalArrayObjects_AsObject(int wanted)
    {

        if (Objacts_arr[wanted] == null)
            return null;
        return Objacts_arr[wanted];
    }

    protected GameObject GetSpesificObject_FinalArrayRooms_AsObject(int wanted)
    {
        for (int i = 0; i < FinalArrayRooms.Length; i++)
        {
            if (i == wanted)
            {
                return Rooms[i];
            }
        }    
        return null;
    }
}
