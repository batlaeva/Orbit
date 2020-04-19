using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    [Range(3, 36)] public int segments;
    public Ellipse ellipse;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();  
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++) {
            Vector2 position2D = ellipse.Evaluate((float)i / (float)segments);
            points[i] = new Vector3(position2D.x, position2D.y, 0f);
        }
        points[segments] = points[0];

        lineRenderer.positionCount = segments + 1;
        lineRenderer.SetPositions(points);
    }
    
    private void OnValidate() {
        if (Application.isPlaying && lineRenderer != null) {
            CalculateEllipse();
        }
    }
}
