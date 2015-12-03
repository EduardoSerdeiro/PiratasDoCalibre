using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mar : MonoBehaviour
{

    public Material material;
    public Texture2D texOcean;

    Mesh mesh;
    void Start()
    {

        this.texOcean = Resources.Load<Texture2D>("Textures/Cenario/Mar/texOcean");
        this.mesh = PlaneMesh.Create(100, 100);
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.GetComponent<MeshFilter>().mesh = this.mesh;

        this.gameObject.AddComponent<MeshRenderer>();
        this.gameObject.name = "Ocean";

        this.gameObject.AddComponent<MeshCollider>();

        this.material = new Material((Shader)Resources.Load("Shaders/Mar"));
        this.material.SetColor("_Color", Color.white);
        this.material.SetTexture("_MainTex", this.texOcean);

        this.gameObject.GetComponent<MeshRenderer>().material = this.material;
       // this.gameObject.transform.position = new Vector3(-50, -1, -30);
        //  this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
