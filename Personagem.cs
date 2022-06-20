using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    private Animator anim;
    // public Camera cam;
    private Rigidbody rigid;
    public float Jumpforce = 500;
    public float groundDistance = 0.3f;
    private bool jump=false;
    public LayerMask whatIsGround;
    public AudioClip somColetavel;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject camPira;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 2f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", v);
        anim.SetFloat("turningSpeed", h);

        if (Input.GetButtonDown("Jump"))
        {
            
            if (jump == false)
            {
                rigid.AddForce(Vector3.up * Jumpforce);

                anim.SetTrigger("Jump");

                stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);

    

            }
           

        }

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, groundDistance, whatIsGround))
        {

            anim.SetBool("Grounded", true);
            anim.applyRootMotion = true;
            jump = false;



        }
        else
        {

            anim.SetBool("Grounded", false);
            jump = true;
        }

        stepClimb();
    }

    void stepClimb()
    {

        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
            {
                rigid.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }

        RaycastHit hitLower45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.1f))
        {

            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 0.2f))
            {
                rigid.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f))
        {

            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f))
            {
                rigid.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pira"))
        {
            Debug.Log("GG");
            Jogo.fogo = true;
            mainCam.SetActive(false);
            camPira.SetActive(true);
            
            //Application.Quit();
        }
        else if (other.gameObject.CompareTag("Coletavel"))
        {
            AudioSource.PlayClipAtPoint(somColetavel, transform.position);
            Destroy(other.gameObject);
            Debug.Log("coleta");
            Jogo.coleta = true;
        }
    }

   
}

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f))
        {

            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f))
            {
                rigid.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pira"))
        {
            Jogo.fogo = true;
            //Application.Quit();
        }
    }

   
}
