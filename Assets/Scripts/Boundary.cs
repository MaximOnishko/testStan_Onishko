using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float[] boundary = new float[4] { minX, maxX, minY, maxY };
    public static float minX, maxX, minY, maxY;
   // List<float> boundaryList = new List<float>();
    public Vector3 pos;
    Player player;
    Move move;


    void Start()
    {
        move = GetComponent<Move>();
        player = GetComponent<Player>();

        player.size = transform.localScale;


        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, camDistance, 0));
        Vector3 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, camDistance, 1));


        boundary[0] = minX = bottomCorner.x + player.size.x / 2;
        boundary[1] = maxX = topCorner.x - player.size.x / 2;
        boundary[2] = minY = bottomCorner.y - player.size.x / 2; ;
        boundary[3] = maxY = -minY ;
        //pos = transform.position;
        //Debug.Log(boundary[0]);
        //pos.x = boundary.OrderBy(x => x).FirstOrDefault();
        //Debug.Log(pos.x);
        //foreach (var item in boundary)
        //{
        //   //oundaryList.Add(item);
        //    Debug.Log(item);
        //    pos.x = boundary.OrderBy(x => x).FirstOrDefault();
        //}
        
        //Debug.Log(pos.x);
    }
    void Update()
    {
        pos = transform.position;
        if (pos.x < minX || pos.x > maxX)
        {
            move.BoundaryDetect("horizontal");
        }

        if (pos.z > minY || pos.z < maxY)
        {
            move.BoundaryDetect("vertical");
        }
    }
}
