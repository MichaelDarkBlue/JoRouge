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
        private System.Windows.Forms.TextBox messageBox;
        public NPCWindow(NPC npc, Player player, System.Windows.Forms.TextBox messageBox)
        {
            InitializeComponent();
        }
    }
}
