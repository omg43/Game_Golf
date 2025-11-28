using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Projectile : ScriptableObject
    {
        [SerializeField] private string m_projectileName;
        [SerializeField] private string m_projectileDescription;

        public Action<Stone> AddScore;

        [Min(1)] public int maxLevel;

        public Stone stone;
        public int level;
        public int damage;

        public string ProjectileName => m_projectileName;
        public string ProjectileDescription => m_projectileDescription;
        public virtual void OnProjectileInitialize() 
        {
            stone.Hit += OnHitClub;
            stone.Missed += OnMissed;
        }
        public virtual void OnHitClub()
        {
            Unscribe();
        }

        public virtual void OnMissed()
        {
            Unscribe();
        }

        public virtual void OnLevelUp()
        {
            level++;
        }
        public void Unscribe()
        {
            stone.Hit -= OnHitClub;
            stone.Missed -= OnMissed;
        }
    }
}
