using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleChao : MonoBehaviour
{

    public float speed;
    private Rigidbody2D chaoRb;
    private bool instanciado;

    // Start is called before the first frame update
    void Start()
    {
        chaoRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        chaoRb.velocity = new Vector2(speed, 0);
                if(instanciado == false){
            if(transform.position.x <= 0){               
                GameObject temp = Instantiate(this.gameObject);
                temp.transform.position = new Vector3(transform.position.x + 20, transform.position.y,transform.position.z);
                 instanciado = true;
            }
    }
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

}
