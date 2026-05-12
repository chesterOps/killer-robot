using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 _initialPos;
    [SerializeField] private float _threshold = -30f;

    void Awake()
    {
        _initialPos = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y <= _threshold)
        {
            transform.position = _initialPos;
        }
    }
}
