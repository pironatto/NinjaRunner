using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private GameController _gameController;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    public GameObject  prefabTiro;
    public float    forcaTiro;
    public float delayTiro;
    private bool disparo;
  
    public Transform groundCheck;
    public bool isGrounded;
    private float speedY;

    public float jumpForce;
    public int jumpExtra;
    private int extraJump;

    public LayerMask whatIsGround;

    public bool molaColetada;


    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController))as GameController;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        extraJump = jumpExtra;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);
    }


    // Update is called once per frame
    void Update()
    {
        //PARA PULAR
        speedY = playerRb.velocity.y;
        if (isGrounded == true)
        {
            extraJump = jumpExtra;
        }

        if (Input.GetButtonDown("Fire1") && extraJump > 0)
        {            
            Jump();
        }
        else if (Input.GetButtonDown("Fire1") && extraJump == 0 && isGrounded == true)
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire2") && _gameController.municao >0 && disparo == false){
            Atirar();
            StartCoroutine("Tiro");
        }

    }

    private void LateUpdate()
    {
        playerAnimator.SetFloat("Blend", speedY);
        playerAnimator.SetBool("Grouded", isGrounded);
    }


    private void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x,0);
        playerRb.AddForce(new Vector2(0, jumpForce));
        extraJump--;
    }

    private void Atirar(){
        disparo = true;
        _gameController.GerenciarMunicao(-1);
        GameObject temp = Instantiate(prefabTiro);
        temp.transform.position = new Vector2(transform.position.x+1.0f,transform.position.y);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaTiro,0);
        Destroy(temp,2f);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag){
            case "Inimigo":
            Destroy(col.gameObject);
            SceneManager.LoadScene("Fase1");
            break;

                    }          

        
    }

    IEnumerator Tiro(){
        yield return new WaitForSeconds(delayTiro);
        disparo = false;
    }
 


}
