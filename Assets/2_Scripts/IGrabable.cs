using UnityEngine;

public interface IGrabable
{
    public void Grab();
    public void Release();
    public void ReleaseAtPlaceholder(Placeholder holder);

    public void SetPosition(Vector2 newPosition);
}
