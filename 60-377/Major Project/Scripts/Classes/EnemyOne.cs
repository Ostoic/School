using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class EnemyOne : Enemy
    {
        private GameObject player;
        private float aggroRadius = 6;

        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            this.LearnSpell("Shoot", new Spells.Shoot(this));
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            if (Vector3.Distance(transform.position, this.player.transform.position) < this.aggroRadius)
                this.CastSpell("Shoot", this.player.GetComponent<Classes.Player>());
        }
    }
}