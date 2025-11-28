using Assets.Scripts.Data;
using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
[CreateAssetMenu(fileName = "Coal", menuName = "Projectile/Coal Projectile")]
public class Coal : Projectile
{
    [SerializeField] private int score;
    public override void OnHitClub()
    {
        stone.OnRemoveHp();
        stone.levelController.RemoveStone(stone);
        Destroy(stone.gameObject, 0.2f);
        base.OnHitClub();
    }
    public override void OnMissed()
    {
        stone.OnAddScore(score);
        stone.levelController.RemoveStone(stone);
        Destroy(stone.gameObject, 0.6f);
        base.OnMissed();
    }
    public override void OnLevelUp()
    {
        score++;
        base.OnLevelUp();
    }
}
