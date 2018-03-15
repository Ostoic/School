using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class Fireball : Unit
    {
        private float explosionRadius = 6;

        Vector3 target;
        GameObject Player;
        Classes.Player playerClass;

        Rigidbody playerbody;
        // Use this for initialization
        private void Start()
        {
            Player = (GameObject.FindGameObjectWithTag("Player"));
            playerClass = Player.GetComponent<Player>();

            this.LearnSpell("Explosion", new Spells.Explosion(this));
            playerbody = Player.GetComponent<Rigidbody>();

            //Player =(GameObject) GameObject.FindGameObjectsWithTag ("Player");
            this.transform.LookAt(Player.transform.position);
        }
        
        /// <summary>
        /// Upon collision
        /// </summary>
        private void OnCollisionEnter()
        {
            // Find all the objects we collided with.
            Collider[] collisions = Physics.OverlapSphere(this.transform.position, explosionRadius);

            // For each collision,
            foreach (Collider collider in collisions)
            {
                // If we hit a unit, cast the explode spell on it.
                Unit unit = collider.GetComponent<Unit>();

                if (unit) this.CastSpell("Explosion", unit);
            }

            // Afterwards, die.
            Destroy(this.gameObject);
        }

        // Update is called once per frame
        protected override void Update()
        {
            transform.position += transform.forward * (10 * Time.deltaTime);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            GameObject.Instantiate(Resources.Load("Effects\\LargeRedEffect"), this.transform.position, Quaternion.identity);
        }
    }
}