﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Adventure
{
    public partial class Current_Quests : Form
    {
        private Player player;
        public Current_Quests(Player playerI)
        {
            InitializeComponent();
            player = playerI;
            listQuests();
        }
        private void listQuests()
        {
            textBox1.Text = "";
            for (int i = 0; i < player.quests.Count; i++)
			{
                if (player.quests[i].type == "Kill")
                {
                    textBox1.Text += "Kill the " + player.quests[i].objective + "'s: Kill " + player.quests[i].amount + " " + player.quests[i].npcname + "'s and recieve " + player.quests[i].rgold + " gold and " + player.quests[i].rreputation + ".";
                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += "Turn in this quest to " + player.quests[i].npcname + " to recieve your reward.";
                    textBox1.Text += Environment.NewLine;
                }
			}
        }
    }
}
