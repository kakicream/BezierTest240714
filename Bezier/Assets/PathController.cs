using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public GameObject path_SC;
    PathCreator pc_SC;
    BezierPath bp_SC;
    VertexPath vp_SC;

    public GameObject path_LC;
    PathCreator pc_LC;
    BezierPath bp_LC;
    VertexPath vp_LC;

    public int pathNumbers;
    public bool pressOnce;
    public float randPos;


    void Start()
    {
        pc_SC = path_SC.GetComponent<PathCreator>();
        bp_SC = pc_SC.bezierPath;
        vp_SC = pc_SC.path;

        pc_LC = path_LC.GetComponent<PathCreator>();
        bp_LC = pc_LC.bezierPath;
        vp_LC = pc_LC.path;

        // pathNumbers = 0;
        pressOnce = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (pressOnce == false)
            {
                randPos = Random.Range(0f, 100f);
                Debug.Log(randPos);
                
                bp_SC.MovePoint(3, new Vector3(0, 0, 200 + randPos));
                bp_SC.MovePoint(6, new Vector3(6, 0, 250 + randPos));
                
                bp_LC.MovePoint(3, new Vector3(6, 0, 200 + randPos));
                bp_LC.MovePoint(6, new Vector3(0, 0, 250 + randPos));
                
                pressOnce = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pressOnce = false;
        }
    }
}
