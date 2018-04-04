using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RunTimeBake : MonoBehaviour
{

    public NavMeshSurface mySurface;

    //// Use this for initialization
    //void Start()
    //{

    //}
    //public bool editorBake;
    //// Update is called once per frame
    //void Update()
    //{
    //    if (editorBake)
    //    {
    //        //do a thing
    //        mySurface.Bake();
    //        editorBake = false;
    //    }
    //}

    public void Bake()
    {
        mySurface.Bake();
    }
}
