using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorenzAttractor : MonoBehaviour
{   

    public float dt = 0.001f, sigma = 10f, rho = 28f, beta = 8f / 3f;

    public int counter = 0, sketchCooldown = 1;
    private Vector3 cursor = new Vector3(4, 4, 4);
    private LineRenderer lineRenderer;
    public GameObject reference;
    public int points = 1000000;
    private int p = 0;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = reference.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.positionCount = points;
    }

    // Update is called once per frame
    void Update()
    {
        float x = cursor.x, y = cursor.y, z = cursor.z;
        float dx = sigma * (y - x), 
              dz = (x * y) - (beta * z),
              dy = x * (rho - z) - y;
        counter++;
        cursor.x += (dx * dt);
        cursor.y += (dy * dt);
        cursor.z += (dz * dt);
        if (counter % sketchCooldown == 0) {
            if (p < points) 
                lineRenderer.SetPosition(p, cursor);
            p++;
        }
        Debug.Log(cursor);
    }
}
