using UnityEngine;
using UnityEngine.Events;

public interface Interactable
{
    public static Interactable Instance;

    public void Interact();
}
