using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    
    public Transform[] positions;


    void Awake()
    {
        positions = GetComponentsInChildren<Transform>();
        positions = positions.Skip(1).ToArray();
    }
}

