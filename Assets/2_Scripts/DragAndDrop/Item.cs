using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Item : MonoBehaviour, IGrabable
{
    private Placeholder _holder;

    private Rigidbody2D _rb2d;
    private Collider2D _collider;

    public void Grab()
    {
        if(_holder != null) 
        {
            _holder.GrabFromPlace();
            _holder = null;
        }
        _rb2d.isKinematic = true;
        _collider.isTrigger = true;
    }

    public void Release()
    {
        _rb2d.velocity = Vector3.zero;
        _rb2d.isKinematic = false;
        _collider.isTrigger = false;
    }

    public void ReleaseAtPlaceholder(Placeholder holder)
    {
        _holder = holder;
        _rb2d.velocity = Vector3.zero;
        _rb2d.isKinematic = true;
        _collider.isTrigger = true;   
    }

    public void SetPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    private void OnValidate()
    {
        _rb2d ??= GetComponent<Rigidbody2D>();
        _collider ??= GetComponent<Collider2D>();  
    }

}
