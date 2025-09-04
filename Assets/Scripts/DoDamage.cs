using UnityEngine;
using UnityEngine.Events;
public class Spike : MonoBehaviour
{
    [SerializeField] float damageAmount = 3;

    [SerializeField] HealthSO health;
    public float damageOverTime;
    //[SerializeField] UnityEvent DoDamage;
    private void Update()
    {
        damageOverTime += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            int Layer = LayerMask.NameToLayer("Player");

            if (other.gameObject.layer == Layer && damageOverTime > 3)
            {
                damageOverTime = 0;
                health.DoDamage(damageAmount);
            }
        }

    }


}
