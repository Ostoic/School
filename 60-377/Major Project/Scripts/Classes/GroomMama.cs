using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class GroomMama : Enemy
    {
        //GroomMama moves around and gives birth to more groomba
        int direction = -1;//GroomMama can move in both positive and negative x directions!

        Spells.GroombaBirth birth;
        protected override void Start()
        {
            base.Start();
            this.birth = new Spells.GroombaBirth(this);
            this.LearnSpell("GroombaBirth", birth);
        }

        protected override void Update()
        {
            base.Update();
            if (this.birth.Cast())
            {
                this.birth.SetCooldown(0);
                this.CastSpell("GroombaBirth");
                this.birth.SetCooldown(10);
            }

            //make two babies
            //Instantiate(Resources.Load("Groomba"), new Vector3(transform.position.x - 1, transform.position.y + 2, 0), Quaternion.identity); 
            //Instantiate(Resources.Load("Groomba"), new Vector3(transform.position.x + 1, transform.position.y + 2, 0), Quaternion.identity); 

            if (Random.Range(1, 20) == 1)
                this.direction *= -1;

            transform.position += new Vector3(direction, 0, 0) * Time.deltaTime;
        }
    }
}