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

        private bool dead = false;

        private float startTime = 0;

        private int lastHealthValue = 3;

        private string spellName = "Spell";

        private int spellCharges = 5;

        private int previousCharges = 5;

        // Use this for initialization
        void Start()
        {
            this.healthSlider.value = this.healthSlider.maxValue;
            this.player = this.playerObj.GetComponent<Classes.Player>();
            this.blink = (Spells.Blink)this.player.GetSpell("Blink");

            this.ToggleSpellUI(false);
        }

        public void SetSpellText(string spellName, int charges)
        {
            this.spellCharges = charges;
            this.spellName = spellName;
            this.spellNameText.text = System.String.Format("Powerup: {0}", this.spellName);
            this.chargesText.text = System.String.Format("{0} charges left", this.spellCharges);
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
                if (!this.spellNameText.enabled || this.blink.GetChargesLeft() != this.previousCharges)
                {
                    this.previousCharges = this.blink.GetChargesLeft();
                    this.SetSpellText("Blink", this.blink.GetChargesLeft());

                    if (!this.spellNameText.enabled) this.spellNameText.enabled = true;
                    if (!this.chargesText.enabled) this.chargesText.enabled = true;
                }
            }

            if (this.player.GetActiveBuffs().Count == 0)
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