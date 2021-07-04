using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{

    public float speed;
    private Rigidbody2D objRb;


    // Start is called before the first frame update
    void Start()
    {


        objRb = GetComponent<Rigidbody2D>();
        objRb.velocity = new Vector2(speed, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
