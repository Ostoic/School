using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spells;

namespace Classes
{
    public class Enemy2 : Enemy
    {
        float timer;
		bool TimerCount;
      
        private Transform target;
        private Vector3 targetPosition;
        private Rigidbody targetBody;
     
        public void SetTarget(Transform target)
        {
            this.target = target;
           
        }

        public void ExplosiveBody(Rigidbody target)
        {
            this.targetBody = target;
        }

        private bool withinRange()
        {
            targetPosition.x = this.target.position.x;
            targetPosition.y = this.target.position.y;
            return (Vector3.Distance(this.transform.position, targetPosition)<5);
        }

        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            this.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
            this.ExplosiveBody(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>());
            this.LearnSpell("Teleport", new Spells.Teleport(this));
            this.LearnSpell("Explosion", new Spells.Explosion(this));
			TimerCount = false;
            timer = 0;
          
          //  ThisRigidBody = this.GetComponent<Rigidbody>();
           // ThisRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        }

        protected override void Update()
        {
            base.Update();
            if (withinRange())
            {
                Teleport teleport = (Teleport)this.GetSpell("Teleport");
                teleport.SetLocation(targetPosition);
                teleport.Cast();

				TimerCount = true;
            }
			if(TimerCount==true){
				timer += Time.deltaTime;
        }
			if (timer > 1) {
				Explosion explosion = (Explosion)this.GetSpell("Explosion");
				explosion.SetBody(targetBody);
				explosion.Cast();
			}
    }
}
}