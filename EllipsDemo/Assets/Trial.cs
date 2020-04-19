using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    public GameObject planet;
    public Material trialMat;
    public float trialTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        TrailRenderer tr = planet.AddComponent<TrailRenderer>();
        tr.time = trialTime;
        tr.startWidth = 0.1f;
        tr.endWidth = 0;
        tr.material = trialMat;
        tr.startColor = new Color(1, 1, 0, 0.1f);
        tr.endColor = new Color(0, 0, 0, 0);
    }
}
