using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    [SerializeField] int HitPoints;
    [Tooltip("Every enemy hitting will decrease this field")]
    [SerializeField] NumberField HealthField;
    private void Start()
    {
        HealthField.SetNumber(HitPoints);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            if(tag != "Player") // fix this later..
                Destroy(other.gameObject);
            --HitPoints;
            HealthField.SetNumber(HitPoints);
            if (HitPoints == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
