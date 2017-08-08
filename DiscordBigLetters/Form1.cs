using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordBigLetters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = 0;
            richTextBox2.Text = "------------ New Message ------------\n";
            if (richTextBox1.Text.Length >= 10000)
            {
                MessageBox.Show("Enter Text Less Than '10000' characters");
            }
            else
            {
                int counter = 0;
                for (int i = 0; i < richTextBox1.Text.Length; i++)
                {
                    counter += 1;
                    if(counter >= 9)
                    {
                        richTextBox2.Text += "\n\n------------ New Message ------------\n";
                        counter = 0;
                    }
                    if (richTextBox1.Text[i].ToString() != " ")
                    {
                        if (!Char.IsLetter(richTextBox1.Text[i]))
                        {
                            if (checkBox2.Checked)
                            {
                                richTextBox2.Text += richTextBox1.Text[i];
                            }else
                            {
                                counter -= 1;
                            }
                        }
                        else
                        {
                            char index = richTextBox1.Text[i];
                            string lowerIndex = index.ToString().ToLower();
                            richTextBox2.Text += String.Format(":regional_indicator_{0}: ", lowerIndex);
                        }                       
                    }
                    else
                    {
                        if (checkBox1.Checked)
                        {
                            richTextBox2.Text += " ";
                        }
                    }
                }
            }
        }
        int index = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                string text = richTextBox2.Text;
                string[] splits = text.Split(new string[] { "\n\n------------ New Message ------------\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (index <= splits.Length)
                {
                    if (index == 0)
                    {
                        richTextBox2.Select(index + 38, splits[index].Length - 38);
                    }
                    else
                    {
                        int c = 0;
                        for (int x = 0; x < index; x++)
                        {
                            c += splits[x].Length;
                            c += 40;
                        }
                        richTextBox2.Select(c, splits[index].Length);
                    }
                    richTextBox2.Focus();

                    index += 1;
                }
                else
                {
                    MessageBox.Show("You can't go any further");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox2.SelectedText);
            }
            catch { }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        int switchs = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = DiscordBigLetters.Properties.Resources.ripbear;
            ImageLayout[] layouts = { ImageLayout.Center, ImageLayout.Stretch, ImageLayout.Tile, ImageLayout.Zoom };
            switch (switchs)
            {
                case 0:
                    this.BackgroundImageLayout = layouts[0];
                    break;
                case 1:
                    this.BackgroundImageLayout = layouts[1];
                    break;
                case 2:
                    this.BackgroundImageLayout = layouts[2];
                    break;
                case 3:
                    this.BackgroundImageLayout = layouts[3];
                    break;
            }
            if(switchs >= 3)
            {
                switchs = 0;
            }
            else
            {
                switchs += 1;
            }
        }
    }
}
