using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Renderer mRender;
    private Material currentMaterial;
    public float  incrementoOffset;
    public float speed;
    private float offset;

    public string sortingLayer;
    public int orderInlayer;

    // Start is called before the first frame update
    void Start()
    {
        mRender = GetComponent<Renderer>();
        mRender.sortingLayerName = sortingLayer;
        mRender.sortingOrder = orderInlayer;
        currentMaterial = mRender.material;        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset += incrementoOffset;
        currentMaterial.SetTextureOffset("_MainTex",new Vector2(offset * speed,0));
    }
}
