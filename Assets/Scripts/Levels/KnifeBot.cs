using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBot : MonoBehaviour
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
        {
            StartScatter();
        }
    }

    private void StartScatter()
    {
        transform.parent = Camera.main.transform.parent;
        _rigidbody.gravityScale = UnityEngine.Random.Range(2f, 4f);
    }
}
