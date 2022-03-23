using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private GameObject _log;
    [SerializeField] private Rigidbody2D _rigidbody;
    void Start()
    {
        transform.parent = _log.transform;
    }

    private void FixedUpdate()
    {
        if (Knife._isFinish == true)
            SetTranformParent();    
    }

    public void SetTranformParent()
    {
        transform.parent = Camera.main.transform.parent;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

}
