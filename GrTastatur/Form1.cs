using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrTastatur;

namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            this.ActiveControl = textBox1;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Code fuer Shortcut Version, die an der Mausposition sich oeffnet
            /*var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;*/
        }


        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a': addTextToTextBox("α", e); changeButtonTexts(e.KeyChar); break;
                case 'b': addTextToTextBox("β", e); break;
                case 'g': addTextToTextBox("γ", e); break;
                case 'd': addTextToTextBox("δ", e); break;
                case 'e': addTextToTextBox("ε", e); changeButtonTexts(e.KeyChar); break;
                case 'z': addTextToTextBox("ζ", e); break;
                case 'h': addTextToTextBox("η", e); changeButtonTexts(e.KeyChar); break;
                case 'q': addTextToTextBox("θ", e); break;
                case 'i': addTextToTextBox("ι", e); changeButtonTexts(e.KeyChar); break;
                case 'k': addTextToTextBox("κ", e); break;
                case 'l': addTextToTextBox("λ", e); break;
                case 'm': addTextToTextBox("μ", e); break;
                case 'n': addTextToTextBox("ν", e); break;
                case 'j': addTextToTextBox("ξ", e); break;
                case 'o': addTextToTextBox("ο", e); changeButtonTexts(e.KeyChar); break;
                case 'p': addTextToTextBox("π", e); break;
                case 'r': addTextToTextBox("ρ", e); changeButtonTexts(e.KeyChar); break;
                case 's': addTextToTextBox("σ", e); break;
                case 'v': addTextToTextBox("ς", e); break;
                case 't': addTextToTextBox("τ", e); break;
                case 'y': addTextToTextBox("υ", e); changeButtonTexts(e.KeyChar); break;
                case 'f': addTextToTextBox("φ", e); break;
                case 'x': addTextToTextBox("χ", e); break;
                case 'c': addTextToTextBox("ψ", e); break;
                case 'w': addTextToTextBox("ω", e); changeButtonTexts(e.KeyChar); break;
            }
        }

        private void addTextToTextBox(string newChar, KeyPressEventArgs e)
        {
            var selectionIndex = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(selectionIndex, newChar);
            textBox1.SelectionStart = selectionIndex + 1;
            e.Handled = true;
        }

        private void changeButtonTexts(Char rootChar)
        {
            clearAllButtons();
            switch (rootChar)
            {
                case 'a':
                    button1.Text = "ἀ";
                    button2.Text = "ἁ";
                    button3.Text = "ἂ";
                    button4.Text = "ἃ";
                    button5.Text = "ἄ";
                    button6.Text = "ἅ";
                    button7.Text = "ἆ";
                    button8.Text = "ἇ";
                    button9.Text = "ὰ";
                    button10.Text = "ά";
                    button11.Text = "ᾀ";
                    button12.Text = "ᾁ";
                    button13.Text = "ᾂ";
                    button14.Text = "ᾃ";
                    button15.Text = "ᾄ";
                    button16.Text = "ᾅ";
                    button17.Text = "ᾆ";
                    button18.Text = "ᾇ";
                    button19.Text = "ᾲ";
                    button20.Text = "ᾳ";
                    button21.Text = "ᾴ";
                    button22.Text = "ᾶ";
                    button23.Text = "ᾷ";
                    break;
                case 'e':
                    button1.Text = "ἐ";
                    button2.Text = "ἑ";
                    button3.Text = "ἒ";
                    button4.Text = "ἓ";
                    button5.Text = "ἔ";
                    button6.Text = "ἕ";
                    button7.Text = "ὲ";
                    button8.Text = "έ";
                    break;
                case 'h':
                    button1.Text = "ἠ";
                    button2.Text = "ἡ";
                    button3.Text = "ἢ";
                    button4.Text = "ἣ";
                    button5.Text = "ἤ";
                    button6.Text = "ἥ";
                    button7.Text = "ἦ";
                    button8.Text = "ἧ";
                    button9.Text = "ὴ";
                    button10.Text = "ή";
                    button11.Text = "ᾐ";
                    button12.Text = "ᾑ";
                    button13.Text = "ᾒ";
                    button14.Text = "ᾓ";
                    button15.Text = "ᾔ";
                    button16.Text = "ᾕ";
                    button17.Text = "ᾖ";
                    button18.Text = "ᾗ";
                    button19.Text = "ῂ";
                    button20.Text = "ῃ";
                    button21.Text = "ῄ";
                    button22.Text = "ῆ";
                    button23.Text = "ῇ";
                    break;
                case 'i':
                    button1.Text = "ἰ";
                    button2.Text = "ἱ";
                    button3.Text = "ἲ";
                    button4.Text = "ἳ";
                    button5.Text = "ἴ";
                    button6.Text = "ἵ";
                    button7.Text = "ἶ";
                    button8.Text = "ἷ";
                    button9.Text = "ὶ";
                    button10.Text = "ί";
                    button11.Text = "ῖ";
                    break;
                case 'o':
                    button1.Text = "ὀ";
                    button2.Text = "ὁ";
                    button3.Text = "ὂ";
                    button4.Text = "ὃ";
                    button5.Text = "ὄ";
                    button6.Text = "ὅ";
                    button7.Text = "ὸ";
                    button8.Text = "ό";
                    break;
                case 'r':
                    button1.Text = "ῤ";
                    button2.Text = "ῥ";
                    break;
                case 'y':
                    button1.Text = "ὐ";
                    button2.Text = "ὑ";
                    button3.Text = "ὒ";
                    button4.Text = "ὓ";
                    button5.Text = "ὔ";
                    button6.Text = "ὕ";
                    button7.Text = "ὖ";
                    button8.Text = "ὗ";
                    button9.Text = "ὺ";
                    button10.Text = "ύ";
                    button11.Text = "ῦ";
                    break;
                case 'w':
                    button1.Text = "ὠ";
                    button2.Text = "ὡ";
                    button3.Text = "ὢ";
                    button4.Text = "ὣ";
                    button5.Text = "ὤ";
                    button6.Text = "ὥ";
                    button7.Text = "ὦ";
                    button8.Text = "ὧ";
                    button9.Text = "ᾠ";
                    button10.Text = "ᾡ";
                    button11.Text = "ᾢ";
                    button12.Text = "ᾣ";
                    button13.Text = "ᾤ";
                    button14.Text = "ᾥ";
                    button15.Text = "ᾦ";
                    button16.Text = "ᾧ";
                    button17.Text = "ῲ";
                    button18.Text = "ῳ";
                    button19.Text = "ῴ";
                    button20.Text = "ῶ";
                    button21.Text = "ῷ";
                    button22.Text = "ὼ";
                    button23.Text = "ώ";
                    break;
            }
        }

        private void clearAllButtons()
        {

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            button16.Text = "";
            button17.Text = "";
            button18.Text = "";
            button19.Text = "";
            button20.Text = "";
            button21.Text = "";
            button22.Text = "";
            button23.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button1.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button2.Text);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button4.Text);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button7.Text);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button9.Text);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button10.Text);
        }


        private void button11_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button11.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button12.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button13.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button14.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button15.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button16.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button17.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button18.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button19.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button20.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button21.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button22.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            buttonToTextBox(button23.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AboutBox1 abBox = new AboutBox1();
            abBox.Show();
        }


        private void buttonToTextBox(string letter)
        {
            if (textBox1.Text.Length > 0)
            {
                var selectionIndex = textBox1.SelectionStart;
                StringBuilder sb = new StringBuilder(textBox1.Text);
                sb[selectionIndex - 1] = letter.ToCharArray()[0];
                textBox1.Text = sb.ToString();

                textBox1.SelectionStart = selectionIndex;
            }
            textBox1.Focus();
        }
        

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0) Clipboard.SetText(textBox1.Text);
            textBox1.Focus();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }
    }
}
