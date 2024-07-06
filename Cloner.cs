using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour
{
    private static int cloneIterator = 0;    
    private static GameObject clone;  
    private static int numberOfAllClones = 0;  

    private static void stitchHelperH(GameObject g, int manyClones, int direction){               
            Vector3 origin = g.transform.position; 
            cloneIterator=direction; 
            numberOfAllClones+=manyClones; 
            while (GameObject.FindGameObjectsWithTag(g.tag).Length <= numberOfAllClones){
                    clone = GameObject.Instantiate(g, new Vector3( g.transform.position.x + (g.GetComponent<SpriteRenderer>().bounds.size.x * cloneIterator), g.transform.position.y, 0), Quaternion.identity); 
                    cloneIterator+=direction;  
            }     
            g.transform.position=origin; 
            
    } 

    private static void stitchHelperV(GameObject g, int manyClones, int direction){  
            Vector3 origin = g.transform.position; 
            cloneIterator=direction; 
            numberOfAllClones+=manyClones; 
            while (GameObject.FindGameObjectsWithTag(g.tag).Length <= numberOfAllClones){
                    clone = GameObject.Instantiate(g, new Vector3( g.transform.position.x, g.transform.position.y + (g.GetComponent<SpriteRenderer>().bounds.size.y * cloneIterator), 0), Quaternion.identity); 
                    cloneIterator+=direction;  
            }     
            g.transform.position=origin;   
    } 


    
    public static void stitchRight(GameObject g,int manyClones){ 
        stitchHelperH(g,manyClones,1);      
    }       
    public static void stitchLeft(GameObject g,int manyClones){
        stitchHelperH(g,manyClones,-1);
    }    
    public static void stitchUp(GameObject g,int manyClones){
        stitchHelperV(g,manyClones,1);
    }       
    public static void stitchDown(GameObject g,int manyClones){
        stitchHelperV(g,manyClones,-1);
    }   
    

    public static void spawnProjectile(GameObject g, Vector3 velocity, int lifetimeMillis){
       spawnProjectile(g, g.transform.position, velocity, lifetimeMillis); 
    }

    public static void spawnProjectile(GameObject g, Vector3 origin, Vector3 velocity, int lifetimeMillis){
         if (!g.CompareTag("Clone")){
            GameObject clone = GameObject.Instantiate(g, origin, Quaternion.identity);
            clone.tag = "Clone";
            clone.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
            GameObject.Destroy(clone, lifetimeMillis / 1000f);
        }  
    }
}
