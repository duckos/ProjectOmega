using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Tower object.
    /// </summary>
    class TowerScript : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;
        /// <summary>
        /// Gets or sets health of tower.
        /// </summary>
        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }

        [SerializeField] private float _reloadTime = 1f;
        /// <summary>
        /// Gets or sets time to "reload".
        /// </summary>
        public float ReloadTime
        {
            get { return _reloadTime; }
            set { _reloadTime = value; }
        }

        [SerializeField] private float _shootingCooldown = 0f;
        /// <summary>
        /// Gets or sets shooting cooldown of tower.
        /// </summary>
        public float ShootingCooldown
        {
            get { return _shootingCooldown; }
            set { _shootingCooldown = value; }
        }

        [SerializeField] private List<GameObject> _playerUnitsInRange = new List<GameObject>();
        /// <summary>
        /// Gets or sets collection of player unit objects in range of tower.
        /// </summary>
        public List<GameObject> PlayerUnitsInRange
        {
            get { return _playerUnitsInRange; }
            protected set { _playerUnitsInRange = value; }
        }

        /// <summary>
        /// Update method of unity script.
        /// </summary>
        public void Update()
        {
            if (Health <= 0f)
            {
                Destroy(this.gameObject);

                // TODO: mozno nebude uplne znicenie ale len zmena objektu veze na kopu skal, mozno ju pridu opravovat trpazlici, v takom pripade bude skript v prazdnom rodicovskom objekte obsahujuci objekt veze a pripadne dalsie objekty
            }

            if (ShootingCooldown > 0f)
            {
                ShootingCooldown -= Time.deltaTime;
            }
            else
            {
                PlayerUnitsInRange.RemoveAll(t => t == null);
                if(PlayerUnitsInRange.Count > 0)
                {
                    ShootingCooldown = ReloadTime;

                    // TODO: strielanie veze na prvu ulozenu hracovu jednotku
                }
            }
        }
    }
}
