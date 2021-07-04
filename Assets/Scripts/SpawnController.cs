using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] objPrefab;
    private float currentTime;
    public float tempSpawn;
    private float posY;
   


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    
    }

    // Update is called once per frame
    void Update()
    {   
        posY = transform.position.y;
        currentTime += Time.deltaTime;
        int posicao = Random.Range(0,150);

        if(posicao <= 50){
            posY = -1.66f;
        }
        else if(posicao > 50 && posicao < 100){
            posY = -2.2f;
        }
        else if(posicao >100){
            posY = -3f;
        }

        
        if(currentTime >= tempSpawn){
            GameObject temp = Instantiate(objPrefab[0]);
            temp.transform.position = new Vector3(transform.position.x,posY,transform.position.z);
            currentTime = 0;
        }


    }
}
