﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Windows
{
    public class GameOverWindow : GenericWindow
    {
        public Text leftStatsLabel;
        public Text leftStatsValues;
        public Text rightStatsLabel;
        public Text rightStatsValues;
        public Text scoreValue;

        public float statsDelay = 1f;

        private int currentStat = 0;
        private int totalStats = 6;
        private int statsPerColumn = 3;
        private float delay = 0;

        private void UpdateStatText(Text label, Text value)
        {
            label.text += $"Stat {currentStat}\n";
            value.text += $"{Random.Range(0, 1000):D4}\n";
        }

        private void ShowNextStat()
        {
            if (currentStat > totalStats - 1)
            {
                scoreValue.text = $"{Random.Range(0, 1000000000):D10}\n";
                currentStat = -1;
                return;
            }

            if (currentStat < statsPerColumn)
            {
                UpdateStatText(leftStatsLabel, leftStatsValues);
            }
            else
            {
                UpdateStatText(rightStatsLabel, rightStatsValues);
            }

            currentStat++;
        }

        void Update()
        {
            delay += Time.deltaTime;
            if (delay > statsDelay && currentStat != -1)
            {
                ShowNextStat();
                delay = 0;
            }
        }

        public void ClearText()
        {
            leftStatsLabel.text = "";
            leftStatsValues.text = "";
            rightStatsLabel.text = "";
            rightStatsValues.text = "";
            scoreValue.text = "";
        }

        public override void Open()
        {
            ClearText();
            base.Open();
        }

        public override void Close()
        {
            base.Close();
            currentStat = 0;
        }

        public void OnNext()
        {
            manager.Open(2);
        }
    }
}