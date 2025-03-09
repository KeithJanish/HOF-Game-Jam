using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 1f;

    public float speed = 5f;

    private Transform targetTransform;

    private Vector2 direction;

    private GameObject targetObject;

    private string targetTag = "Player";
    private string grappleTag = "DreamCircle";

    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        //if(targetObject != null)
        //{

        //}
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        targetTransform = targetObject.transform;
        direction = (targetTransform.position - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            print("Collided with an enemy!");
            direction = -direction;
        }
    }



}
