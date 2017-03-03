using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GNTKeyboard;
using System.Xml;

namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {

        public XmlDocument doc = new XmlDocument();
        public XmlNodeList nodeList;
        public XmlNode root;

        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            this.ActiveControl = textBox1;
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Code fuer Shortcut Version, die an der Mausposition sich oeffnet
            /*var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;*/

            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            doc.Load(a.GetManifestResourceStream("GNTKeyboard.Resources.Wordlist.xml"));
            //doc.Load(@"Wordlist.xml");
            root = doc.DocumentElement;
            nodeList = root.SelectNodes("descendant::word");
        }


        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (Char)Keys.Escape:
                    textBox1.Clear();
                    textBox1.Focus();
                    e.Handled = true;
                    break;
            }
        }

        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    textBox1.Clear();
                    e.Handled = true;
                    break;
                case Keys.Left:
                    if (textBox1.SelectionStart > 1)
                    {
                        textBox1.SelectionStart = textBox1.SelectionStart - 1;
                        changeButtonTexts(textBox1.Text[textBox1.SelectionStart - 1]);
                        e.Handled = true;
                    }
                    //textBox1.Text = "Geht!";
                    //changeButtonTexts('η');
                    break;
                case Keys.Right:
                    if (textBox1.SelectionStart > 0)
                    {
                        //textBox1.SelectionStart = textBox1.SelectionStart - 1;
                        changeButtonTexts(textBox1.Text[textBox1.SelectionStart]);
                        //e.Handled = true;
                    }
                    break;
            }
        }

        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                //case (Char)Keys.Escape: textBox1.Clear(); break;
                /*
                --- Grossbuchstaben ---
                */
                case 'A': addTextToTextBox("Α", e); changeButtonTexts(e.KeyChar); break;
                case 'B': addTextToTextBox("Β", e); break;
                case 'G': addTextToTextBox("Γ", e); break;
                case 'D': addTextToTextBox("Δ", e); break;
                case 'E': addTextToTextBox("Ε", e); changeButtonTexts(e.KeyChar); break;
                case 'Z': addTextToTextBox("Ζ", e); break;
                case 'H': addTextToTextBox("Η", e); changeButtonTexts(e.KeyChar); break;
                case 'Q': addTextToTextBox("Θ", e); break;
                case 'I': addTextToTextBox("Ι", e); changeButtonTexts(e.KeyChar); break;
                case 'K': addTextToTextBox("Κ", e); break;
                case 'L': addTextToTextBox("Λ", e); break;
                case 'M': addTextToTextBox("Μ", e); break;
                case 'N': addTextToTextBox("Ν", e); break;
                case 'J': addTextToTextBox("Ξ", e); break;
                case 'O': addTextToTextBox("Ο", e); changeButtonTexts(e.KeyChar); break;
                case 'P': addTextToTextBox("Π", e); break;
                case 'R': addTextToTextBox("Ρ", e); changeButtonTexts(e.KeyChar); break;
                case 'S': addTextToTextBox("Σ", e); break;
                case 'T': addTextToTextBox("Τ", e); break;
                case 'Y': addTextToTextBox("Υ", e); changeButtonTexts(e.KeyChar); break;
                case 'F': addTextToTextBox("Φ", e); break;
                case 'X': addTextToTextBox("Χ", e); break;
                case 'C': addTextToTextBox("Ψ", e); break;
                case 'W': addTextToTextBox("Ω", e); changeButtonTexts(e.KeyChar); break;
                /*
                --- Kleinbuchstaben ---
                */
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

            

            comboBox1.Items.Clear();
            if (checkBox1.Checked) loadComboBox();
        }

        private void loadComboBox ()
        {
            int i = 0;
            //Change the price on the books.
            foreach (XmlNode word in nodeList)
            {
                if (word.FirstChild.InnerText.IndexOf(textBox1.Text) > -1)
                {
                    comboBox1.Items.Add(word.FirstChild.NextSibling.InnerText);
                    i++;
                    if (i == 10) break;
                }
            }

            if (comboBox1.Items.Count > 0) comboBox1.Text = comboBox1.Items[0].ToString();
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
                case 'A':
                    button1.Text = "Ἀ";
                    button2.Text = "Ἁ";
                    button3.Text = "Ἂ";
                    button4.Text = "Ἃ";
                    button5.Text = "Ἄ";
                    button6.Text = "Ἅ";
                    button7.Text = "Ἆ";
                    button8.Text = "Ἇ";
                    button9.Text = "ᾈ";
                    button10.Text = "ᾉ";
                    button11.Text = "ᾊ";
                    button12.Text = "ᾋ";
                    button13.Text = "ᾌ";
                    button14.Text = "ᾍ";
                    button15.Text = "ᾎ";
                    button16.Text = "ᾏ";
                    break;
                case 'E':
                    button1.Text = "Ἐ";
                    button2.Text = "Ἑ";
                    button3.Text = "Ἒ";
                    button4.Text = "Ἓ";
                    button5.Text = "Ἔ";
                    button6.Text = "Ἕ";
                    button7.Text = "Ὲ";
                    button8.Text = "Έ";
                    break;
                case 'H':
                    button1.Text = "Ἠ";
                    button2.Text = "Ἡ";
                    button3.Text = "Ἢ";
                    button4.Text = "Ἣ";
                    button5.Text = "Ἤ";
                    button6.Text = "Ἥ";
                    button7.Text = "Ἦ";
                    button8.Text = "Ἧ";
                    button9.Text = "ᾘ";
                    button10.Text = "ᾙ";
                    button11.Text = "ᾚ";
                    button12.Text = "ᾛ";
                    button13.Text = "ᾜ";
                    button14.Text = "ᾝ";
                    button15.Text = "ᾞ";
                    button16.Text = "ᾟ";
                    break;
                case 'I':
                    button1.Text = "Ἰ";
                    button2.Text = "Ἱ";
                    button3.Text = "Ἲ";
                    button4.Text = "Ἳ";
                    button5.Text = "Ἴ";
                    button6.Text = "Ἵ";
                    button7.Text = "Ἶ";
                    button8.Text = "Ἷ";
                    button9.Text = "Ὶ";
                    button10.Text = "Ί";
                    break;
                case 'O':
                    button1.Text = "Ὀ";
                    button2.Text = "Ὁ";
                    button3.Text = "Ὂ";
                    button4.Text = "Ὃ";
                    button5.Text = "Ὄ";
                    button6.Text = "Ὅ";
                    button7.Text = "Ὸ";
                    button8.Text = "Ό";
                    break;
                case 'R':
                    button1.Text = "Ῥ";
                    break;
                case 'Y':
                    button1.Text = "Ὑ";
                    button2.Text = "Ὓ";
                    button3.Text = "Ὕ";
                    button4.Text = "Ὗ";
                    button5.Text = "Ῠ";
                    button6.Text = "Ῡ";
                    button7.Text = "Ὺ";
                    button8.Text = "Ύ";
                    break;
                case 'W':
                    button1.Text = "Ὠ";
                    button2.Text = "Ὡ";
                    button3.Text = "Ὢ";
                    button4.Text = "Ὣ";
                    button5.Text = "Ὤ";
                    button6.Text = "Ὥ";
                    button7.Text = "Ὦ";
                    button8.Text = "Ὧ";
                    button9.Text = "ᾨ";
                    button10.Text = "ᾩ";
                    button11.Text = "ᾪ";
                    button12.Text = "ᾫ";
                    button13.Text = "ᾬ";
                    button14.Text = "ᾭ";
                    button15.Text = "ᾮ";
                    button16.Text = "ᾯ";
                    button17.Text = "Ὼ";
                    button18.Text = "Ώ";
                    button19.Text = "ῼ";
                    break;
                case 'ἀ':
                case 'ἁ':
                case 'ἂ':
                case 'ἃ':
                case 'ἄ':
                case 'ἅ':
                case 'ἆ':
                case 'ἇ':
                case 'ὰ':
                case 'ά':
                case 'ᾀ':
                case 'ᾁ':
                case 'ᾂ':
                case 'ᾃ':
                case 'ᾄ':
                case 'ᾅ':
                case 'ᾆ':
                case 'ᾇ':
                case 'ᾲ':
                case 'ᾳ':
                case 'ᾴ':
                case 'ᾶ':
                case 'ᾷ':
                case 'α':
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
                case 'ἐ':
                case 'ἑ':
                case 'ἒ':
                case 'ἓ':
                case 'ἔ':
                case 'ἕ':
                case 'ὲ':
                case 'έ':
                case 'ε':
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
                case 'ἠ':
                case 'ἡ':
                case 'ἢ':
                case 'ἣ':
                case 'ἤ':
                case 'ἥ':
                case 'ἦ':
                case 'ἧ':
                case 'ὴ':
                case 'ή':
                case 'ᾐ':
                case 'ᾑ':
                case 'ᾒ':
                case 'ᾓ':
                case 'ᾔ':
                case 'ᾕ':
                case 'ᾖ':
                case 'ᾗ':
                case 'ῂ':
                case 'ῃ':
                case 'ῄ':
                case 'ῆ':
                case 'ῇ':
                case 'η':
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
                case 'ἰ':
                case 'ἱ':
                case 'ἲ':
                case 'ἳ':
                case 'ἴ':
                case 'ἵ':
                case 'ἶ':
                case 'ἷ':
                case 'ὶ':
                case 'ί':
                case 'ῖ':
                case 'ι':
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
                case 'ὀ':
                case 'ὁ':
                case 'ὂ':
                case 'ὃ':
                case 'ὄ':
                case 'ὅ':
                case 'ὸ':
                case 'ό':
                case 'ο':
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
                case 'ῤ':
                case 'ῥ':
                case 'ρ':
                case 'r':
                    button1.Text = "ῤ";
                    button2.Text = "ῥ";
                    break;
                case 'ὐ':
                case 'ὑ':
                case 'ὒ':
                case 'ὓ':
                case 'ὔ':
                case 'ὕ':
                case 'ὖ':
                case 'ὗ':
                case 'ὺ':
                case 'ύ':
                case 'ῦ':
                case 'υ':
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
                case 'ὠ':
                case 'ὡ':
                case 'ὢ':
                case 'ὣ':
                case 'ὤ':
                case 'ὥ':
                case 'ὦ':
                case 'ὧ':
                case 'ᾠ':
                case 'ᾡ':
                case 'ᾢ':
                case 'ᾣ':
                case 'ᾤ':
                case 'ᾥ':
                case 'ᾦ':
                case 'ᾧ':
                case 'ῲ':
                case 'ῳ':
                case 'ῴ':
                case 'ῶ':
                case 'ῷ':
                case 'ὼ':
                case 'ώ':
                case 'ω':
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
            if (button1.Text.Length > 0) buttonToTextBox(button1.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Length > 0) buttonToTextBox(button2.Text);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text.Length > 0) buttonToTextBox(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text.Length > 0) buttonToTextBox(button4.Text);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text.Length > 0) buttonToTextBox(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text.Length > 0) buttonToTextBox(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text.Length > 0) buttonToTextBox(button7.Text);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text.Length > 0) buttonToTextBox(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text.Length > 0) buttonToTextBox(button9.Text);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text.Length > 0) buttonToTextBox(button10.Text);
        }


        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text.Length > 0) buttonToTextBox(button11.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text.Length > 0) buttonToTextBox(button12.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text.Length > 0) buttonToTextBox(button13.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Text.Length > 0) buttonToTextBox(button14.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text.Length > 0) buttonToTextBox(button15.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.Text.Length > 0) buttonToTextBox(button16.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Text.Length > 0) buttonToTextBox(button17.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.Text.Length > 0) buttonToTextBox(button18.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.Text.Length > 0) buttonToTextBox(button19.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.Text.Length > 0) buttonToTextBox(button20.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.Text.Length > 0) buttonToTextBox(button21.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (button22.Text.Length > 0) buttonToTextBox(button22.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.Text.Length > 0) buttonToTextBox(button23.Text);
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
            //Hier wird kopiert.
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void copySuggestionBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 0) Clipboard.SetText(comboBox1.Text);
            textBox1.Focus();
        }
        

        private void comboBox1_HitEnter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = true;
                comboBox1.Items.Clear();
                if (checkBox1.Checked) loadComboBox();
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = "";
                comboBox1.Items.Clear();
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
             if (checkBox2.Checked)
             {
                 this.TopMost = true;
                 checkBox2.Image = GNTKeyboard.Properties.Resources.PinnedItem_32x;
             } else
             {
                 this.TopMost = false;
                 checkBox2.Image = GNTKeyboard.Properties.Resources.PushpinUnpin_32x;
             }
        }
    }
}
