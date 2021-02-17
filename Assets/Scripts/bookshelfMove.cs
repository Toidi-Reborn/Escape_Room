using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookshelfMove : MonoBehaviour
{

    GameObject bookCase;
    private float distanceMoved = 0;
    public bool moving = false;
    Vector3 startLocation;
    Vector3 endLocation;


    private void Start()
    {

        startLocation = transform.position;

        endLocation = startLocation + new Vector3(8,0,0); 
        
    }



    void Update()
    {
        
    }




    public void moveOpen()
    {

        if (distanceMoved < 2.5f)
        {
            Vector3 oldSpot = transform.position;
            transform.Translate(1, 0, 0 * Time.deltaTime * 3.5f);
            distanceMoved += Vector3.Distance(oldSpot, transform.position);
        }

    }


    public void startOpen()
    {
        StartCoroutine("openShelf");

    }


    public IEnumerator openShelf()
    {
        Vector3 moveVectorVar = startLocation;

        // wait x seconds before starting
        yield return new WaitForSeconds(1f);

        // start routine
        for (float i = 0; moveVectorVar.x <= endLocation.x; i += 100) //i doesnt matter - alt ways to do this
        {
            // move bookShelf
            moveVectorVar.x = moveVectorVar.x + 0.1f;
            transform.position = moveVectorVar;

            // process then wait and continue
            yield return new WaitForSeconds(0f);
        }

    }


}
