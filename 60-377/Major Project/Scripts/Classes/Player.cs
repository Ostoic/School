using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    void Start ()
    {
        // Add HeadStomp to the spell table.
        this.AddSpell("HeadStop", new HeadStomp(this));
	}
}
