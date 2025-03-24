using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Obstacles : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float limitX;
 
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if(transform.position.x < -limitX)
        {
            transform.localPosition = new Vector3(26, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
