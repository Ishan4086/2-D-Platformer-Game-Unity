using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Enemy_Saw : MonoBehaviour
{
    [SerializeField] private float movementdistance;
    [SerializeField] private float movementspeed;
    [SerializeField] private float damage;
    private bool movingleft=true;

    private float leftedge;
    private float rightedge;
    private void Awake()
    {
        leftedge = transform.position.x - movementdistance;
        rightedge = transform.position.x + movementdistance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftedge)
            {
                transform.position = new Vector3(transform.position.x - movementspeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = false;
            
        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + movementspeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = true;
        }


    }

    
}
