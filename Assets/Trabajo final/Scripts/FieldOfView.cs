using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float fov = 360f;
    public int numAristas = 360;
    public float anguloInicial = 0;
    public float distanciaVision =2f;
    public LayerMask layerMask;
    
    private Mesh mesh;
    private Vector3 origen;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origen = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GenerarMesh();
    }
    private void GenerarMesh()
    {
        Vector3[] vertices = new Vector3[numAristas + 2];
        int[] triangulos=new int[numAristas * 3];
        float anguloActual = anguloInicial;
        float incrementoAngulo = fov / numAristas;
        vertices[0] = Vector3.zero;

        int indiceVertices = 1;
        int indiceTriangulos = 0;
        for (int i = 0; i <= numAristas; i++)
        {
            RaycastHit2D raycasthit2d = Physics2D.Raycast(origen, GetVectorFromAngle(anguloActual), distanciaVision, layerMask);

            Vector3 verticeActual;
            if (raycasthit2d.collider == null)
            {
                verticeActual = GetVectorFromAngle(anguloActual) * distanciaVision;
            }
            else
            {
                verticeActual = raycasthit2d.point;
                verticeActual = verticeActual-origen;
            }
            
            vertices[indiceVertices] = verticeActual;
            if (i > 0)
            {
                triangulos[indiceTriangulos] = 0;
                triangulos[indiceTriangulos + 1] = indiceVertices - 1;
                triangulos[indiceTriangulos + 2] = indiceVertices;
                indiceTriangulos += 3;
            }
            indiceVertices++;
            anguloActual -= incrementoAngulo;
            
        }
        
        mesh.vertices = vertices;
        mesh.triangles = triangulos;

    }
    
    Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public void SetOrigin(Vector3 newOrigin)
    {
        transform.position=newOrigin;
        origen=transform.position;
    }

    public void SetAngle(float angle)
    {
        anguloInicial=angle;
    }
}
