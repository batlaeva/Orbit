using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse {
   
   public float a; //большая полуось
    public float b; //малая полуось

   public Ellipse (float a, float b) {
       this.a = a;
       this.b = b;
   }

   public Vector2 Evaluate(float t) {
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Sin(angle) * a;
        float y = Mathf.Cos(angle) * b;

        return new Vector2(x, y);
   }
}
