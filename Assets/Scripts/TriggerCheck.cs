using UnityEngine;
using UnityEngine.Events;
public class TriggerCheck : MonoBehaviour
{
    public UnityEvent Enter;
    public UnityEvent Exit;
    private void OnTriggerEnter(Collider other)
    {
        Enter?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        Exit?.Invoke();
    }
}
