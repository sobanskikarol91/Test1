using UnityEngine;
using System.Collections;
using UnityEngine.Profiling;

public class Test1 : MonoBehaviour 
{
    void Update()
    {
        Profiler.BeginSample("aaaaaaaa");
        Debug.Log("this code is being profiled");
        Profiler.EndSample();
    }
}
