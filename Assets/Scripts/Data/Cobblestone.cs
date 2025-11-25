using Assets.Scripts.Data;
using UnityEngine;
[CreateAssetMenu(fileName = "Cobblestone", menuName = "Projectile/Cobblestone Projectile")]
public class Cobblestone : Projectile
{
    [SerializeField] private GameObject m_partycleDestroy;

    [SerializeField] private int score;
    public override void OnHitClub()
    {
        stone.OnAddScore(score);
        base.OnHitClub();
    }
    public override void OnMissed()
    {
        stone.OnRemoveHp();
        base.OnMissed();
    }
    public override void OnLevelUp()
    {
        score++;
    }
}
