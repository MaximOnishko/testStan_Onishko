using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Move : MonoBehaviour
{
    Cyrcle cyrcle;
    Boundary boundaryScript;

    Vector3 direction;
    float  startTime;
    [SerializeField]
    float force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boundaryScript = GetComponent<Boundary>();
        cyrcle = GetComponent<Cyrcle>();
    }

    void Update()
    {
        ClickDetect();
    }
    void ClickDetect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    direction = transform.position - hit.point;

                    Debug.Log(hit.point);
                }

            }

            float diff = Time.time - startTime;
            if (diff > 5) diff = 5;
            else if (diff < 1) diff = 1;

            AddForce(force * diff);
        }
    }
    public void BoundaryDetect(string side)
    {
        if(side == "horizontal")
        {
            transform.position = new Vector3(boundaryScript.pos.x = boundaryScript.boundary.OrderBy(x => Vector3.Distance(transform.position, new Vector3(x, 0, 0))).FirstOrDefault(), boundaryScript.pos.y, boundaryScript.pos.z);
            rb.velocity = new Vector3(rb.velocity.x * (-1), 0, rb.velocity.z);
      
           // rb.AddForce(new Vector3(rb.velocity.x, 0, 0) * (-1) * 100);
        }
        if (side == "vertical")
        {
            transform.position = new Vector3(boundaryScript.pos.x, boundaryScript.pos.y, boundaryScript.pos.z = boundaryScript.boundary.OrderBy(z => Vector3.Distance(transform.position, new Vector3(0, 0, z))).FirstOrDefault());
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z * (-1));

            //rb.AddForce(new Vector3(0, 0, rb.velocity.z) * (-1) * 100);
        }
    }
    void AddForce(float force)
    {
        rb.AddForce(direction * force, ForceMode.Force);
    }
}
