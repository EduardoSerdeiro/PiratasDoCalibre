using UnityEngine;
using System.Collections;

public class PlaneMesh
{
    public static Mesh Create(int row = 10, int column = 10)
    {

        Mesh mesh = new Mesh();
        mesh.name = "PlaneMesh";
        Vector3[] verts;
        int[] indices;
        Vector2[] UV;

        verts = new Vector3[row * column];
        UV = new Vector2[column * row];

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < column; c++)
            {
                verts[(r * column) + c] = new Vector3(c, 0, r);
                UV[(r * column) + c] = new Vector2(c / (float)column - 1, r / (float)row - 1);
            }
        }

        mesh.vertices = verts;

        mesh.uv = UV;



        indices = new int[(row - 1) * (column - 1) * 2 * 3];

        int k = 0;
        for (int r = 0; r < (row - 1); r++)
        {
            for (int c = 0; c < (column - 1); c++)
            {

                indices[k++] = (int)((r + 1) * column + c); //2
                indices[k++] = (int)(r * column + (c + 1)); //1
                indices[k++] = (int)(r * column + c); //0

                indices[k++] = (int)((r + 1) * column + c); //3
                indices[k++] = (int)((r + 1) * column + (c + 1)); //4
                indices[k++] = (int)(r * column + (c + 1)); //5


            }

        }
        mesh.triangles = indices;
        mesh.RecalculateNormals();

        return mesh;
    }
}
