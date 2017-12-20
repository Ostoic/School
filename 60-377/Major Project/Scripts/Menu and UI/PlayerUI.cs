using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace MenuUI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        private Slider healthSlider;

        [SerializeField]
        private RawImage deathScreen;

        [SerializeField]
        private GameObject playerObj;

        [SerializeField]
        private Text spellNameText;

        [SerializeField]
        private Text chargesText;

        private Classes.Player player;

        private Spells.Blink blink;
        private Spells.Laser laser;
        private Spells.Invulnerability invuln;
        private Spells.Health shield;
        private Spells.InvertGravity gravity;

        private bool dead = false;

        private float startTime = 0;

        private int lastHealthValue = 3;

        private int spellCharges = 5;

        private int previousValue = 0;

        // Use this for initialization
        void Start()
        {
            this.healthSlider.value = this.healthSlider.maxValue;
            this.player = this.playerObj.GetComponent<Classes.Player>();
            this.blink = (Spells.Blink)this.player.GetSpell("Blink");
            this.laser = (Spells.Laser)this.player.GetSpell("Laser");
            this.invuln = (Spells.Invulnerability)this.player.GetSpell("Invulnerability");
            this.shield = (Spells.Health)this.player.GetSpell("Health");
            this.gravity = (Spells.InvertGravity)this.player.GetSpell("InvertGravity");

            this.ToggleSpellUI(false);
        }

        public void SetSpellText(string spellName, int charges)
        {
            this.spellNameText.text = System.String.Format("Powerup: {0}", spellName);
            this.chargesText.text = System.String.Format("{0} charges left", charges);
            this.ToggleSpellUI(true);
        }

        public void SetSpellTimerText(string spellName, int timeLeft)
        {
            this.spellNameText.text = System.String.Format("Powerup: {0}", spellName);
            this.chargesText.text = System.String.Format("{0} seconds left", timeLeft);
            this.ToggleSpellUI(true);
        }

        public void PlayerDied()
        {
            this.dead = true;
            this.startTime = Time.time;
        }

        public void OnPlayerDied()
        {
            if (Time.time - this.startTime > 5)
                SceneManager.LoadScene("MainMenu");

            if (!this.deathScreen.enabled)
            {
                this.deathScreen.enabled = true;
                this.healthSlider.value = this.healthSlider.minValue;
            }
        }

        private void ToggleSpellUI(bool state)
        {
            this.spellNameText.enabled = state;
            this.chargesText.enabled = state;
        }

        public void UpdateUI(Classes.Player player)
        {
            if (player.GetHealth() != this.lastHealthValue)
            {
                this.lastHealthValue = player.GetHealth();
                this.healthSlider.value = this.lastHealthValue;
            }

            if (this.player.HasBuff("Blink"))
            {
                this.SetSpellText("Blink", this.blink.GetChargesLeft());
            }

            else if (this.player.HasBuff("Laser"))
            {
                this.SetSpellTimerText("Laser", (int)this.laser.GetTimeLeft());
            }

            else if (this.player.HasBuff("InvertGravity"))
            {
                this.SetSpellTimerText("InvertGravity", (int)this.gravity.GetTimeLeft());
            }

            else if (this.player.HasBuff("Invulnerability"))
            {
                this.SetSpellTimerText("Invulnerability", (int)this.invuln.GetTimeLeft());
            }

            else if (this.player.HasBuff("Health"))
            {
                this.SetSpellTimerText("Health Shield", (int)this.shield.GetTimeLeft());
            }

            else if (this.player.GetActiveBuffs().Count == 0)
                this.ToggleSpellUI(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (this.dead)
                this.OnPlayerDied();

            this.UpdateUI(this.player);
        }
    }
}