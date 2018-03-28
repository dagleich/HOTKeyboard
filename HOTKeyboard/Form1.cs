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
using HOTKeyboard;
using System.Xml;

namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {
        public XmlDocument doc = new XmlDocument();
        public XmlNodeList nodeList;
        public XmlNode root;
        public Dictionary<string, string> hebWords = new Dictionary<string, string>();
        public Dictionary<string, string> hebWords1 = new Dictionary<string, string>();
        public Dictionary<string, string> hebWords2 = new Dictionary<string, string>();
        public Dictionary<string, string> hebWords3 = new Dictionary<string, string>();
        public Dictionary<string, string> hebWords4 = new Dictionary<string, string>();
        public Dictionary<string, string> hebWords5 = new Dictionary<string, string>();
        public List<string> finalWord = new List<string>();
        public Dictionary<char, string[]> buchstabenListe = new Dictionary<char, string[]>();
        int finalWordPos = 0;

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
            buchstabenListe.Add('א', new []{ "אְ", "אֱ", "אֲ", "אֳ", "אִ", "אֵ", "אֶ", "אַ", "אָ", "אֹ", "אֻ"});
            buchstabenListe.Add('ב', new[] { "בּ", "בְ", "בֱ", "בֲ", "בֳ", "בִ", "בֵ", "בֶ", "בַ", "בָ", "בֹ", "בֻ", "בְּ", "בֱּ", "בֲּ", "בֳּ", "בִּ", "בֵּ", "בֶּ", "בַּ", "בָּ", "בֹּ", "בֻּ" });
            buchstabenListe.Add('ג', new[] { "גְ", "גֱ", "גֲ", "גֳ", "גִ", "גֵ", "גֶ", "גַ", "גָ", "גֹ", "גֻ", "גְּ", "גֱּ", "גֲּ", "גֳּ", "גִּ", "גֵּ", "גֶּ", "גַּ", "גָּ", "גֹּ", "גֻּ" });
            buchstabenListe.Add('ד', new[] { "דְ", "דֱ", "דֲ", "דֳ", "דִ", "דֵ", "דֶ", "דַ", "דָ", "דֹ", "דֻ", "דְּ", "דֱּ", "דֲּ", "דֳּ", "דִּ", "דֵּ", "דֶּ", "דַּ", "דָּ", "דֹּ", "דֻּ" });
            buchstabenListe.Add('ה', new[] { "הְ", "הֱ", "הֲ", "הֳ", "הִ", "הֵ", "הֶ", "הַ", "הָ", "הֹ", "הֻ", "הְּ", "הֱּ", "הֲּ", "הֳּ", "הִּ", "הֵּ", "הֶּ", "הַּ", "הָּ", "הֹּ", "הֻּ" });
            buchstabenListe.Add('ו', new[] { "וּ", "וֹ", "וְ", "וֱ", "וֲ", "וֳ", "וִ", "וֵ", "וֶ", "וַ", "וָ", "וֻ", "וְּ", "וֱּ", "וֲּ", "וֳּ", "וִּ", "וֵּ", "וֶּ", "וַּ", "וָּ", "וֹּ", "וֻּ" });
            buchstabenListe.Add('ז', new[] { "זְ", "זֱ", "זֲ", "זֳ", "זִ", "זֵ", "זֶ", "זַ", "זָ", "זֹ", "זֻ", "זְּ", "זֱּ", "זֲּ", "זֳּ", "זִּ", "זֵּ", "זֶּ", "זַּ", "זָּ", "זֹּ", "זֻּ" });
            buchstabenListe.Add('ח', new[] { "חְ", "חֱ", "חֲ", "חֳ", "חִ", "חֵ", "חֶ", "חַ", "חָ", "חֹ", "חֻ" });
            buchstabenListe.Add('ט', new[] { "ט", "טּ", "טְ", "טֱ", "טֲ", "טֳ", "טִ", "טֵ", "טֶ", "טַ", "טָ", "טֹ", "טֻ", "טְּ", "טֱּ", "טֲּ", "טֳּ", "טִּ", "טֵּ", "טֶּ", "טַּ", "טָּ", "טֹּ" });
            buchstabenListe.Add('י', new[] { "יּ", "יְ", "יֱ", "יֲ", "יֳ", "יִ", "יֵ", "יֶ", "יַ", "יָ", "יֹ", "יֻ", "יְּ", "יֱּ", "יֲּ", "יֳּ", "יִּ", "יֵּ", "יֶּ", "יַּ", "יָּ", "יֹּ", "יֻּ" });
            buchstabenListe.Add('כ', new[] { "כּ", "כְ", "כֱ", "כֲ", "כֳ", "כִ", "כֵ", "כֶ", "כַ", "כָ", "כֹ", "כֻ", "כְּ", "כֱּ", "כֲּ", "כֳּ", "כִּ", "כֵּ", "כֶּ", "כַּ", "כָּ", "כֹּ", "כֻּ", "ך", "ךּ", "ךְ"});
            buchstabenListe.Add('ל', new[] { "לּ", "לְ", "לֱ", "לֲ", "לֳ", "לִ", "לֵ", "לֶ", "לַ", "לָ", "לֹ", "לֻ", "לְּ", "לֱּ", "לֲּ", "לֳּ", "לִּ", "לֵּ", "לֶּ", "לַּ", "לָּ", "לֹּ", "לֻּ" });
            buchstabenListe.Add('מ', new[] { "מּ", "מְ", "מֱ", "מֲ", "מֳ", "מִ", "מֵ", "מֶ", "מַ", "מָ", "מֹ", "מֻ", "מְּ", "מֱּ", "מֲּ", "מֳּ", "מִּ", "מֵּ", "מֶּ", "מַּ", "מָּ", "מֹּ", "מֻּ", "ם" });
            buchstabenListe.Add('נ', new[] { "נּ", "נְ", "נֱ", "נֲ", "נֳ", "נִ", "נֵ", "נֶ", "נַ", "נָ", "נֹ", "נֻ", "נְּ", "נֱּ", "נֲּ", "נֳּ", "נִּ", "נֵּ", "נֶּ", "נַּ", "נָּ", "נֹּ", "נֻּ", "ן" });
            buchstabenListe.Add('ס', new[] { "ס", "סּ", "סְ", "סֱ", "סֲ", "סֳ", "סִ", "סֵ", "סֶ", "סַ", "סָ", "סֹ", "סֻ", "סְּ", "סֱּ", "סֲּ", "סֳּ", "סִּ", "סֵּ", "סֶּ", "סַּ", "סָּ", "סֹּ", "סֻּ" });
            buchstabenListe.Add('ע', new[] { "ע", "עְ", "עֱ", "עֲ", "עֳ", "עִ", "עֵ", "עֶ", "עַ", "עָ", "עֹ", "עֻ" });
            buchstabenListe.Add('פ', new[] { "פ", "פּ", "פְ", "פֱ", "פֲ", "פֳ", "פִ", "פֵ", "פֶ", "פַ", "פָ", "פֹ", "פֻ", "פְּ", "פֱּ", "פֲּ", "פֳּ", "פִּ", "פֵּ", "פֶּ", "פַּ", "פָּ", "פֹּ", "פֻּ", "ף" });
            buchstabenListe.Add('צ', new[] { "צ", "צּ", "צְ", "צֱ", "צֲ", "צֳ", "צִ", "צֵ", "צֶ", "צַ", "צָ", "צֹ", "צֻ", "צְּ", "צֱּ", "צֲּ", "צֳּ", "צִּ", "צֵּ", "צֶּ", "צַּ", "צָּ", "צֹּ", "צֻּ", "ץ" });
            buchstabenListe.Add('ק', new[] { "ק", "קּ", "קְְ", "קֱ", "קֲ", "קֳ", "קִ", "קֵ", "קֶ", "קַ", "קָ", "קֹ", "קֻ", "קְּ", "קֱּ", "קֲּ", "קֳּ", "קִּ", "קֵּ", "קֶּ", "קַּ", "קָּ", "קֹּ", "קֻּ" });
            buchstabenListe.Add('ר', new[] { "ר", "רּ", "רְ", "רֱ", "רֲ", "רֳ", "רִ", "רֵ", "רֶ", "רַ", "רָ", "רֹ", "רֻ", "רְּ", "רֱּ", "רֲּ", "רֳּ", "רִּ", "רֵּ", "רֶּ", "רַּ", "רָּ", "רֹּ", "רֻּ" });
            buchstabenListe.Add('ש', new[] { "‎שׂ", "שְׂ", "שֱׂ", "שֲׂ", "שֳׂ", "שִׂ", "שֵׂ", "שֶׂ", "שַׂ", "שָׂ", "שֹׂ", "שֻׂ", "שְּׂ", "שֱּׂ", "שֲּׂ", "שֳּׂ", "שִּׂ", "שֵּׂ", "שֶּׂ", "שַּׂ", "שָּׂ", "שֹּׂ", "שֻּׂ" });
            buchstabenListe.Add('שׁ', new[] { "שְׁ", "שֱׁ", "שֲׁ", "שֳׁ", "שִׁ", "שֵׁ", "שֶׁ", "שַׁ", "שָׁ", "שֹׁ", "שֻׁ", "שְּׁ", "שֱּׁ", "שֲּׁ", "שֳּׁ", "שִּׁ", "שֵּׁ", "שֶּׁ", "שַּׁ", "שָּׁ", "שֹּׁ", "שֻּׁ" });
            buchstabenListe.Add('ת', new[] { "ת","תּ", "תְ","תֱ","תֲ","תֳ","תִ","תֵ","תֶ","תַ","תָ","תֹ","תֻ","תְּ","תֱּ","תֲּ","תֳּ","תִּ","תֵּ","תֶּ","תַּ","תָּ","תֹּ","תֻּ" });

            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            doc.Load(a.GetManifestResourceStream("HOTKeyboard.Resources.Wordlist.xml"));
            root = doc.DocumentElement;
            nodeList = root.SelectNodes("descendant::word");
            int i = 1;
            
            foreach (XmlNode word in nodeList)
            {
                if (hebWords.ContainsKey(word.FirstChild.InnerText))
                {
                    while (hebWords.ContainsKey(word.FirstChild.InnerText + i.ToString())) i++;
                    hebWords.Add(word.FirstChild.InnerText + i.ToString(), word.FirstChild.NextSibling.InnerText);
                }
                else hebWords.Add(word.FirstChild.InnerText, word.FirstChild.NextSibling.InnerText);
                i = 1;
            }
            

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
                    finalWord.Clear();
                    finalWordPos = 0;
                    e.Handled = true;
                    break;
                case Keys.Left:
                    if (finalWordPos < finalWord.Count())
                    {
                        finalWordPos++;
                    }
                    if (finalWordPos > 0) changeButtonTexts(findConsonant(finalWord.ElementAt(finalWordPos - 1).ToString()));
                    else clearAllButtons();
                    break;
                case Keys.Right:
                    if (finalWordPos > 0)
                    {
                        finalWordPos--;

                        if (finalWordPos > 0) changeButtonTexts(findConsonant(finalWord.ElementAt(finalWordPos - 1).ToString()));
                        else clearAllButtons();
                    }
                    else clearAllButtons();
                    break;
                case Keys.Delete:
                    if (finalWordPos < finalWord.Count()) finalWord.RemoveAt(finalWordPos);

                    comboBox1.Items.Clear();
                    if (checkBox1.Checked) loadComboBox();
                    break;
                case Keys.Back:
                    if ((finalWordPos < textBox1.Text.Count()) && (finalWordPos >= 1)) finalWord.RemoveAt(--finalWordPos);
                    else if ((finalWordPos == textBox1.Text.Count()) && (finalWordPos >= 1)) finalWord.RemoveAt(--finalWordPos);

                    comboBox1.Items.Clear();
                    if (checkBox1.Checked) loadComboBox();
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
                case 'a': addTextToTextBox('א', e); break;
                case 'b': addTextToTextBox('ב', e); break;
                case 'g': addTextToTextBox('ג', e); break;
                case 'd': addTextToTextBox('ד', e); break;
                case 'h': addTextToTextBox('ה', e); break;
                case 'w': addTextToTextBox('ו', e); break;
                case 'z': addTextToTextBox('ז', e); break;
                case 'x': addTextToTextBox('ח', e); break;
                case 'j': addTextToTextBox('ט', e); break;
                case 'y': addTextToTextBox('י', e); break;
                case 'k': addTextToTextBox('כ', e); break;
                case 'l': addTextToTextBox('ל', e); break;
                case 'm': addTextToTextBox('מ', e); break;
                case 'n': addTextToTextBox('נ', e); break;
                case 's': addTextToTextBox('ס', e); break;
                case '[': addTextToTextBox('ע', e); break;
                case 'p': addTextToTextBox('פ', e); break;
                case 'c': addTextToTextBox('צ', e); break;
                case 'q': addTextToTextBox('ק', e); break;
                case 'r': addTextToTextBox('ר', e); break;
                case 'f': addTextToTextBox('ש', e); break;
                case 'v': addTextToTextBox('שׁ', e); break;
                case 't': addTextToTextBox('ת', e); break;
                case '$': addTextToTextBox('ך', e); break;
                case '~': addTextToTextBox('ם', e); break;
                case '!': addTextToTextBox('ן', e); break;
                case '@': addTextToTextBox('ף', e); break;
                case '#': addTextToTextBox('ץ', e); break;
            }
            
            comboBox1.Items.Clear();
            if (checkBox1.Checked) loadComboBox();
        }

        char findConsonant (string letter)
        {
            char consonant = letter[0];
            foreach (char buchstabe in buchstabenListe.Keys)
            {
                if (letter[0] == buchstabe)
                {
                    consonant = buchstabe;
                    break;
                }
                else if (buchstabenListe[buchstabe].Contains(letter))
                {
                    consonant = buchstabe;
                    break;
                }
                
            }
            return consonant;
        }

        private void loadComboBox ()
        {
            int i = 0;
            int nrCharTextBox = textBox1.Text.Length;
            Dictionary<string, string> hebWordsLocal = new Dictionary<string, string>();

            if (nrCharTextBox == 1) { hebWordsLocal = hebWords; hebWords1.Clear(); hebWords2.Clear(); hebWords3.Clear(); hebWords4.Clear(); hebWords5.Clear(); }
            else if (nrCharTextBox == 2) { hebWordsLocal = hebWords1; hebWords2.Clear(); hebWords3.Clear(); hebWords4.Clear(); hebWords5.Clear(); }
            else if (nrCharTextBox == 3) { hebWordsLocal = hebWords2; hebWords3.Clear(); hebWords4.Clear(); hebWords5.Clear(); }
            else if (nrCharTextBox == 4) { hebWordsLocal = hebWords3; hebWords4.Clear(); hebWords5.Clear(); }
            else if (nrCharTextBox == 5) { hebWordsLocal = hebWords4; hebWords5.Clear(); }
            else if (nrCharTextBox >= 6) { hebWordsLocal = hebWords5; }


            foreach (KeyValuePair<string, string> hebWord in hebWordsLocal)
            {
                if ((hebWord.Key.IndexOf(textBox1.Text) > -1) || (hebWord.Value.IndexOf(textBox1.Text) > -1))
                {
                    if (nrCharTextBox == 1) hebWords1.Add(hebWord.Key, hebWord.Value);
                    else if (nrCharTextBox == 2) hebWords2.Add(hebWord.Key, hebWord.Value);
                    else if (nrCharTextBox == 3) hebWords3.Add(hebWord.Key, hebWord.Value);
                    else if (nrCharTextBox == 4) hebWords4.Add(hebWord.Key, hebWord.Value);
                    else if (nrCharTextBox == 5) hebWords5.Add(hebWord.Key, hebWord.Value);

                    i++;
                    if (i <= 10) comboBox1.Items.Add(hebWord.Value);
                }
            }

            if (comboBox1.Items.Count > 0) comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void addTextToTextBox(char newChar, KeyPressEventArgs e)
        {

            finalWord.Insert(finalWordPos, newChar.ToString());
            finalWordPos++;
            e.Handled = true;
            int i = 0;
            int y = 0;
            int selectionPos = 0;
            textBox1.Clear();
            foreach (string letter in finalWord)
            {
                textBox1.Text += letter;
                i++;
                y = y + letter.Length;
                if (i == finalWordPos) selectionPos = y;
            }
            textBox1.SelectionStart = selectionPos;
            //textBox1.Text = textBox1.Text + ": " + finalWord[finalWordPos - 1];
            changeButtonTexts(newChar);
        }

        private void changeButtonTexts(Char rootChar)
        {
            clearAllButtons();
            int i = 1;
            foreach (string buchstabe in buchstabenListe[rootChar])
            {
                this.Controls["button" + i.ToString()].Text = buchstabe;
                i++;
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
            button24.Text = "";
            button25.Text = "";
            button26.Text = "";
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
            if (button24.Text.Length > 0) buttonToTextBox(button24.Text);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.Text.Length > 0) buttonToTextBox(button25.Text);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (button26.Text.Length > 0) buttonToTextBox(button26.Text);
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            AboutBox1 abBox = new AboutBox1();
            abBox.Show();
        }


        private void buttonToTextBox(string letter)
        {
            int i = 0;
            int y = 0;
            int selectionPosition = 0;
            finalWord.RemoveAt(finalWordPos-1);
            finalWord.Insert(finalWordPos-1, letter);
            textBox1.Clear();
            foreach (string finalWordLetter in finalWord)
            {
                i++;
                y = y + finalWordLetter.Count();
                if (i == finalWordPos) selectionPosition = y;
                textBox1.Text += finalWordLetter;
            }
            textBox1.SelectionStart = selectionPosition;
            
            textBox1.Focus();

            comboBox1.Items.Clear();
            if (checkBox1.Checked) loadComboBox();
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
                 checkBox2.Image = HOTKeyboard.Properties.Resources.PinnedItem_32x;
             } else
             {
                 this.TopMost = false;
                 checkBox2.Image = HOTKeyboard.Properties.Resources.PushpinUnpin_32x;
             }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
