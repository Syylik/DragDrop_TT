using UnityEngine;

public class Placeholder : MonoBehaviour
{
    private bool _isOccupied = false;

    public bool TryPlaceOnIt()
    {
        if(_isOccupied) return false;
        _isOccupied = true;
        return true;
    }

    public void GrabFromPlace()
    {
        _isOccupied = false;
    }
}
