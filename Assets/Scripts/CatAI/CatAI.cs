using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatAI : MonoBehaviour
{
    public Transform layser;
    public float speed;
    public float distractionTime;
    public float idleTime;

    public float angularVelocity;
    private float angle;
    private float distraction;
    private float idle;

    void Start() 
    {
    }

    void Update()
    {
        if(layser == null)
        {
            angle += Random.Range(-angularVelocity, angularVelocity) * Time.deltaTime;
            Vector2 direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, direction.y, 0f);
            
            idle += Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, layser.position, speed * Time.deltaTime);
            
            distraction += Time.deltaTime;
            if(distraction >= distractionTime) {
                layser = null;
                distraction = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(idle >= idleTime) {
            idle = 0f;
            layser = collider.transform;
        }
    }
}
