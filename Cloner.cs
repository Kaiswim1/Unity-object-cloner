using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner
{
    // Start is called before the first frame update  
    private static int cloneIterator = 0;   

    /**
    * stitchHorizontal will stitch gameobjects to the left or right of the 
    */ 
    private static void stitchHelperH(GameObject g, int manyClones, int direction){
         while (GameObject.FindGameObjectsWithTag(g.tag).Length <= manyClones){
            cloneIterator+=direction; 
            GameObject.Instantiate(g, new Vector3(g.GetComponent<SpriteRenderer>().bounds.size.x * cloneIterator, g.transform.position.y, 0), Quaternion.identity);  
        }  
    } 
    private static void stitchHelperV(GameObject g, int manyClones, int direction){
         while (GameObject.FindGameObjectsWithTag(g.tag).Length <= manyClones){
            cloneIterator+=direction; 
            GameObject.Instantiate(g, new Vector3(g.transform.position.x, g.GetComponent<SpriteRenderer>().bounds.size.y * cloneIterator, 0), Quaternion.identity);  
        }  
    }

    public static void stitchRight(GameObject g,int manyClones){stitchHelperH(g,manyClones,1);}       
    public static void stitchLeft(GameObject g,int manyClones){stitchHelperH(g,manyClones,-1);}    
    public static void stitchUp(GameObject g,int manyClones){stitchHelperH(g,manyClones,1);}       
    public static void stitchDown(GameObject g,int manyClones){stitchHelperH(g,manyClones,-1);}   




    
    public static void spawnProjectile(GameObject g, Vector3 location, Vector3 velocity, int lifetimeMillis){
        if (!g.CompareTag("Clone")){
            GameObject clone = GameObject.Instantiate(g, location, Quaternion.identity);
            clone.tag = "Clone";
            clone.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
            GameObject.Destroy(clone, lifetimeMillis / 1000f);
        }  
    }

}
