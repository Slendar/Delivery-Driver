using UnityEngine;
using UnityEngine.Animations;

public class Drive : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 200f;
    [SerializeField] private float moveSpeed = 20f;

    [SerializeField] private float slowSpeed = 15f;
    [SerializeField] private float boostSpeed = 30f;

    [SerializeField] private LayerMask boostersLayerMask;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(boostersLayerMask.value, 2))
        {
            moveSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if(moveAmount != 0)
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
        }
        transform.Translate(0, moveAmount, 0);
    }
}
