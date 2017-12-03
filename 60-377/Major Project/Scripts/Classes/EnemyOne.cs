using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class EnemyOne : Unit
    {
        private GameObject player;
        private float aggroRadius = 6;

        // Use this for initialization
        void Start()
        {
            this.LearnSpell("Shoot", new Spells.Shoot(this));
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        protected override void Update()
        {
            if (Vector3.Distance(transform.position, player.transform.position) < this.aggroRadius)
            {
                Debug.Log("Close");
                this.CastSpell("Shoot", Utility.GetPlayer<Classes.Player>());
                //Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
            }
        }
    }
}