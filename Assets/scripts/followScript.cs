using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : AnimalHolder
{
    public Transform targetObj;
   

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, targetObj.position, 10 * Time.deltaTime);
        
    }
}
