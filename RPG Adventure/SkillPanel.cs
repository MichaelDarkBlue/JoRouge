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
    public partial class SkillPanel : Form
    {
        private Player p;
        public SkillPanel(Player inP)
        {
            InitializeComponent();
            p = inP;
            skills();
            stats();
        }
        private void skills()
        {
            //Update Skill Point Display
            skillpoints.Text = "Skill Points: " + p.skillp;
            stats();
        }
        private void stats()
        {
            //Update Stat Display
            statBox.Text = "Stats:";
            statBox.Text += Environment.NewLine + "Max Health: " + p.maxhealth;
            statBox.Text += Environment.NewLine + "Damage: " + p.damage;
            statBox.Text += Environment.NewLine + "Resistance: " + p.defence;
            statBox.Text += Environment.NewLine + "Archery Level: " + p.archery;
            statBox.Text += Environment.NewLine + "Ranged Damage: " + p.rangeD;
            statBox.Text += Environment.NewLine + "Ranged Accuracy: " + p.rangedA + "%";
            statBox.Text += Environment.NewLine + "Ranged Range: " + p.rangedR;
            statBox.Text += Environment.NewLine + "Theivery: " + p.theivery;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (p.skillp > 0)
            {
                p.maxhealth++;
                p.health = p.maxhealth;
                p.skillp--;
            }
            skills();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (p.skillp > 0)
            {
                p.damage++;
                p.skillp--;
            }
            skills();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (p.skillp > 0)
            {
                p.defence++;
                p.skillp--;
            }
            skills();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (p.skillp > 0)
            {
                p.archery++;
                p.rangeD++;
                p.rangedA += 3;
                p.skillp--;
            }
            skills();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (p.skillp > 0)
            {
                p.theivery++;
                p.skillp--;
            }
            skills();
        }
    }
}
