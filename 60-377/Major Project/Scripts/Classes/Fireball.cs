using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class Fireball : Unit
    {
        Vector3 target;
        GameObject Player;
        Classes.Player playerClass;

        Rigidbody playerbody;
        // Use this for initialization
        void Start()
        {
            Player = (GameObject.FindGameObjectWithTag("Player"));
            playerClass = Player.GetComponent<Player>();

            this.LearnSpell("Explosion", new Spells.Explosion(this));
            playerbody = Player.GetComponent<Rigidbody>();

            //Player =(GameObject) GameObject.FindGameObjectsWithTag ("Player");
            this.transform.LookAt(Player.transform.position);
        }

        void Hit()
        {
            this.CastSpell("Explosion", playerClass);
            //playerbody.AddExplosionForce(1000, transform.position, 3, 3.0f);
            //playerClass.Damage(1);
            Destroy(this.gameObject);
        }

        // Update is called once per frame
        protected override void Update()
        {
            transform.position += transform.forward * (10 * Time.deltaTime);
            if (Vector3.Distance(transform.position, Player.transform.position) < 2)
            {
                Hit();
            }

            if (transform.position.y < 0) Destroy(this.gameObject);

        }
    }
}