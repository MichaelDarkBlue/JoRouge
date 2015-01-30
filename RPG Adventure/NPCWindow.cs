using System;
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
    public partial class NPCWindow : Form
    {
        private Random r = new Random();
        private List<Item> inventory;
        private NPC npc;
        private Player player;
        private TextBox messageBox;
        private int lvlmod;
        private Quest quest = new Quest("", "", 0, "", 0, 0, 0, 0);
        public NPCWindow(NPC npci, Player playeri, TextBox messageBoxi, int lvlmodI)
        {
            InitializeComponent();
            npc = npci;
            player = playeri;
            inventory = playeri.inventory;
            messageBox = messageBoxi;
            lvlmod = lvlmodI;
            this.Text = npc.name + " the " + npc.type;
            randomtalk();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (npc.quest)
            {
                Quest.randomQuest(out quest, lvlmod, r);
                quest.npcname = npc.name;
                if (quest.type == "Kill")
                {
                    textBox.Text = npc.name + " the " + npc.type + ": \"I have an urgent quest for you. " + quest.objective + "'s have been attacking our town we need you to kill " + quest.amount + " of them to teach them a lesson.\" If you complete this quest you will recieve " + quest.rgold + " gold, " + quest.rreputation + " reputation, and " + quest.rxp + " xp.";
                }
                npc.quest = false;
            }
            else
            {
                randomtalk();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (quest != null)
            {
                player.quests.Add(quest);
                textBox.Text = npc.name + " the " + npc.type + ": \"Thankyou for accepting this great quest.\"";
            }
            quest = null;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (quest != null)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"Hopefully someone else will come along to help us.\"";
            }
            quest = null;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < player.quests.Count; i++)
            {
                if (player.quests[i].npcname == npc.name)
                {
                    textBox.Text = npc.name + " the " + npc.type + ": \"Thankyou for completing this quest.\"";
                    textBox.Text += Environment.NewLine + "You recieved " + player.quests[i].rgold + " gold, " + player.quests[i].rreputation + " reputation, and " + player.quests[i].rxp + " xp.";
                    player.reputation += player.quests[i].rreputation;
                    player.gold += player.quests[i].rgold;
                    player.xp += player.quests[i].rxp;
                    player.quests.Remove(player.quests[i]);
                }
            }
        }
        private void randomtalk()
        {
            int random = r.Next(1, 6 + 1);
            if (random == 1)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"The weather has been nice lately has it not?\"";
            }
            else if (random == 2)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"Orcs have been stirring up trouble recently.\"";
            }
            else if (random == 3)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"I wish everyone could just get along.\"";
            }
            else if (random == 4)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"Tell me more about the outside world.\"";
            }
            else if (random == 5)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"There is a legend of mysterious creatures that breathe FIRE.\"";
            }
            else if (random == 6)
            {
                textBox.Text = npc.name + " the " + npc.type + ": \"The world around us is always changing.\"";
            }
        }
    }
}
