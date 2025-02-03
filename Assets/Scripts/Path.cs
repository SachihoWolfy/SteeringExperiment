using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public LinkedList<GameObject> path;
    public GameObject[] children;
    public Seeker seeker;
    // Start is called before the first frame update

    private void Awake()
    {
        path = new LinkedList<GameObject>(children);
        seeker.myTarget = path.First.Value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(seeker.myTarget.transform.position,seeker.transform.position) < 1f)
        {
            path.AddLast(path.First.Value);
            path.RemoveFirst();
            seeker.myTarget = path.First.Value;
        }
    }
}
