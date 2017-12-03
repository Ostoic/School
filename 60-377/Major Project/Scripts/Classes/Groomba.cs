using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spells.NonPlayer;

namespace Classes
{
    public class Groomba : Enemy
    {
        int Direction = -1;
        float timer = 0;
        Rigidbody jumpBody;
        GameObject player;
        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            Debug.Log("Groomba");
            jumpBody = this.GetComponent<Rigidbody>();
            player = (GameObject.FindGameObjectWithTag("Player"));
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            timer += Time.deltaTime;
            if ((int)timer % 3 == 0 && timer > 1)
            {
                Direction *= -1;
                jumpBody.AddForce(-Gravity.GetGravityDirection() * 20);
            }

            transform.position += new Vector3(Direction, 0, 0) * Time.deltaTime;
        }

        protected override void OnDestroy()
        {
            player.GetComponent<Objects.Scoreboard>().RegisterKill();
        }
    }
}