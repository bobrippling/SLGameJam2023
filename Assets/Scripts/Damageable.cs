using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    void Start() {
    }

    void Update() {
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("gotya");
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("gotya2");
    }
}
