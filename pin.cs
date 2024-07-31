using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool fallen { get; private set; }
    public bool removed { get; private set; }

    private Rigidbody rb;
    private Vector3 position;

    void Awake () {
        position = transform.position;
        TryGetComponent(out rb);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.y < 1.0f && !fallen) {
            fallen = true;
        }
    }

    public void RemovePin () {
        gameObject.SetActive(false);
        removed = true;
    }

    public void Reset () {
        fallen = false;
        removed = false;
        rb.isKinematic = true;
        transform.rotation = Quaternion.identity;
        transform.position = position;
        gameObject.SetActive(true);
        rb.isKinematic = false;
    }
}
