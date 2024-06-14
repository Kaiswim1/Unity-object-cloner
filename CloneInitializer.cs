using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneInitializer : MonoBehaviour
{
    void Start()
    { 
        Cloner.stitchRight(GameObject.FindGameObjectWithTag("Player"), 3);  
        Cloner.stitchLeft(GameObject.FindGameObjectWithTag("Player"), 3);  
        Cloner.stitchUp(GameObject.FindGameObjectWithTag("Player"), 3); 
    }
}
