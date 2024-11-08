using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class PlaneGenerator : MonoBehaviour
{
    //references
    Mesh myMesh;
    MeshFilter meshFilter;

    //Plane settings
    [SerializeField] Vector2 planeSize= new Vector2(1,1);
    [SerializeField] int planeResolution = 1;

    //mesh values
    List<Vector3> vertices;
    List<int> triangles;

    //initialize mesh and assign meshFilter reference
    private void Awake()
    {
        myMesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = myMesh;
    }

    // Update is called once per frame
    void Update()
    {
        //min avoids errors, max keeps performance sane
        planeResolution = Mathf.Clamp(planeResolution, 1, 50);

        GeneratePlane(planeSize, planeResolution);
        // use left to right or Ripple
        LeftToRightSine(Time.timeSinceLevelLoad);
        AssignMesh();
    }

    void LeftToRightSine(float time)
    {
        for(int i = 0; i<vertices.Count; i++)
        {
            Vector3 vertex = vertices[i];
            vertex.y = Mathf.Sin(time+vertex.x);
            vertices[i] = vertex;
        }
    }

    void GeneratePlane(Vector2 size, int resolution)
    {
        //create vertices
        vertices = new List<Vector3>();
        float xPerStep = size.x / resolution;
        float yPerStep = size.y / resolution;
        for(int y = 0; y<resolution+1; y++)
        {
            for (int x = 0; x < resolution + 1; x++)
            {
                vertices.Add(new Vector3(x*xPerStep,0,y*yPerStep));
            }
        }

        //Create triangles
        triangles= new List<int>();
        for(int row= 0; row<resolution; row++)
        {
            for (int column = 0; column<resolution; column++)
            {
                int i = (row * resolution) + row + column;
                //first triangle
                triangles.Add(i);
                triangles.Add(i+ (resolution) + 1);
                triangles.Add(i + (resolution) + 2);

                //second triangle
                triangles.Add(i);
                triangles.Add(i + resolution + 2);
                triangles.Add(i+1);
            }
        }
    }

    void AssignMesh()
    {
        myMesh.Clear();
        myMesh.vertices = vertices.ToArray();
        myMesh.triangles = triangles.ToArray();
    }

    void RippleSine(float time)
    {
        Vector3 origin = new Vector3(planeSize.x/2,0,planeSize.y/2);

        for(int i= 0; i<vertices.Count; i++)
        {
            Vector3 vertex = vertices[i];
            float distanceFromCenter = (vertex-origin).magnitude;
            vertex.y = Mathf.Sin(time+distanceFromCenter);
            vertices[i] = vertex;
        }
    }
}
