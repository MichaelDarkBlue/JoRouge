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
        private List<Item> inventory;
        private NPC npc;
        private Player player;
        private TextBox messageBox;
        private int lvlmod;
        public NPCWindow(NPC npci, Player playeri, List<Item> inventoryi, TextBox messageBoxi, int lvlmodI)
        {
            InitializeComponent();
            npc = npci;
            player = playeri;
            inventory = inventoryi;
            messageBox = messageBoxi;
            lvlmod = lvlmodI;
            this.Text = npc.name + " the " + npc.type;
            randomtalk();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (npc.quest)
            {
                ;
            }
        }
        public void randomtalk()
        {
            Random r = new Random();
            int random = r.Next(1, 5 + 1);
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
        }
    }
}
