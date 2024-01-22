using UnityEditor.UIElements;
using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] int NormalEnemyPoints;
    [SerializeField] int BossPoints;
    [SerializeField] LayerMask BossLayer;
    [SerializeField] LayerMask NormalEnemyLayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && scoreField != null)
        {
            if (BossLayer == (BossLayer | (1 << other.gameObject.layer))) // had to shift left because of how unity works..
                scoreField.AddNumber(BossPoints);
            if (NormalEnemyLayer == (NormalEnemyLayer | (1 << other.gameObject.layer))) // had to shift left because of how unity works..
                scoreField.AddNumber(NormalEnemyPoints);
        }
    }

    public void SetScoreField(NumberField newTextField)
    {
        this.scoreField = newTextField;
    }
}
