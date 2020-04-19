using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform pivot; // точка вращения
    public Transform orbitingObject;
    public float orbitTilt; //наклон oтнocитeльнo coлнeчнoгo эквaтopa

    public float semiMajorAxis; //Большая полуось в а.е.
    public float b = 0; //Малая полуось в а.е.
    public float eccentricity; //Эксцентриситет орбиты
    [Range(0f, 1f)] public float orbitProgress;
    // public float orbitPeriod = 3f; //???
    [Range(0f, 0.1f)] public float GP;//Standard gravitational parameter
    public bool orbitActive = true;

    // public float orbitSpeed = 0;
    // public float dist = 0;

    public Ellipse orbitPath; //Большая и маленькая полуоси в а.е.

    // Start is called before the first frame update
    void Start()
    {
        //наклон oтнocитeльнo coлнeчнoгo эквaтopa
        transform.localRotation = Quaternion.Euler(orbitTilt, 0, 0);
        //calculate the semi-minor axis
        orbitPath.b = semiMajorAxis * Mathf.Sqrt(1 - eccentricity * eccentricity);
        orbitPath.a = semiMajorAxis;
        b = orbitPath.b;

        if (orbitingObject == null) {
            orbitActive = false;
            return;
        }
        SetOrbitObjectPosition();
        // StartCoroutine(AnimateOrbit());
        
    }

    void SetOrbitObjectPosition() {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        // orbitPos.x = orbitPos.x-1f;
        // orbitPos.y = orbitPos.y-3;
        // float temp = 1.5f;
        orbitingObject.localPosition = new Vector3(pivot.position.x - orbitPos.x, 0, pivot.position.z - orbitPos.y); //y-up

    }

    // IEnumerator AnimateOrbit() {
    //     // if (orbitPeriod < 0.1f) {
    //     //     orbitPeriod = 0.1f;
    //     // }
    //     ///???
    //     // float orbitSpeed = 1f / orbitPeriod;
    //     Vector3 difference = pivot.position - orbitingObject.position;
    //     dist = difference.magnitude;
    //     float a = Mathf.Max(orbitPath.xAxis, orbitPath.yAxis);
    //     orbitSpeed = Mathf.Sqrt(gravitationalPar * (2 / dist - 1 / a));
    //     while (orbitActive)
    //     {
    //         orbitProgress += Time.deltaTime * orbitSpeed;
    //         orbitProgress %= 1f;
    //         SetOrbitObjectPosition();
    //         yield return null;
    //     }
    // }

    void Update() {
        Vector3 difference = pivot.position - orbitingObject.position;
        float dist = difference.magnitude;
        float orbitSpeed = Mathf.Sqrt(GP * (2 / dist - 1 / orbitPath.a));
        if (orbitActive) {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitObjectPosition();
        }
    }
}


    