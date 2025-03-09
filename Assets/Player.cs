using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float horMove;
    public float vertMove;
    public Rigidbody2D rigbody;
    public GameObject dcFab; // DreamCirclePrefab
    public GameObject dcObj; // DreamCircleObject
    public Vector2 moveToHere;
    public Vector2 dcObjThrowPoint;
    public int spawnDelayTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        //vertMove = Input.GetAxis("Vertical");

        rigbody.AddForce(new Vector2(horMove, vertMove));

        if (Input.GetKeyDown(KeyCode.Mouse0) && dcObj == null)
        {
            spawnDelayTimer = 100;
            dcObj = Instantiate(dcFab, transform.position, Quaternion.identity);
            dcObjThrowPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //dcObj.transform.position = transform.position;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveToHere = (dcObj.transform.position - transform.position) * 2; //Vector2.MoveTowards(transform.position, dcObj.transform.position, 0.1f);

                rigbody.AddForce(moveToHere);
            }

            if (Input.GetKey(KeyCode.S))
            {
                dcObj.transform.position = Vector2.MoveTowards(dcObj.transform.position, transform.position, 0.1f);
            }
            else
            {
                dcObj.transform.position = Vector2.MoveTowards(dcObj.transform.position, dcObjThrowPoint, 0.1f);
            }
            spawnDelayTimer -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("DreamCircle") && spawnDelayTimer <= 0)
        {
            Destroy(other.gameObject);
            Debug.Log("DreamCircle Destroyed");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
