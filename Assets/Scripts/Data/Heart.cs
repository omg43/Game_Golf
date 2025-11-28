using Assets.Scripts.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "HealHeart", menuName = "Projectile/Heart Projectile")]
public class Heart : Projectile
{
    [SerializeField] private int amountHeal = 1;

    public override void OnLevelUp()
    {
        stone.levelController.ChangeMaxHealt();
       base.OnLevelUp();
    }

    public override void OnHitClub()
    {
        stone.levelController.IncreaseHealth(amountHeal);
    }
}
