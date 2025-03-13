using UnityEngine;

public class DragDropSystem : MonoBehaviour
{
    private IGrabable _currentItem;
    [SerializeField] private LayerMask _grabLayer, _placeholderLayer;

    public void TryStartDrag()
    {
        RaycastHit2D hit = InputHandler.WhatUnderCursorByLayer(_grabLayer);
        if(hit && hit.collider.TryGetComponent<IGrabable>(out IGrabable item))
        {
            _currentItem = item;
            item.Grab();
        }
    }

    public void Release()
    {
        if(_currentItem != null)
        {
            var hit = InputHandler.WhatUnderCursorByLayer(_placeholderLayer);
            if( hit && hit.collider.TryGetComponent<Placeholder>(out Placeholder holder) && holder.TryPlaceOnIt())
            {
                _currentItem.SetPosition(holder.transform.position);
                _currentItem.ReleaseAtPlaceholder(holder);
            }
            else _currentItem.Release();
            _currentItem = null;
        }
    }

    private void Update()
    {
        if(_currentItem != null)
        {
            _currentItem.SetPosition(InputHandler.GetMouseWorldPosition());
        }
    }
}