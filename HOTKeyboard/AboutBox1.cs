using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTKeyboard
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            
        }

        

        #region Assemblyattributaccessoren

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = "<html><head><title>HOTKeyboard - Hilfe</title></head><body><p>Das Programm funktioniert so, dass man in dem Textfeld deutsche Buchstaben eintippt, welche dann direkt in hebräische Buchstaben umgewandelt werden. Dabei entsprechen folgende Buchstaben einander:</p>" +
"<table style='width: 600px;'>" +
"<tbody>" +
" <tr style='height: 20px; background-color: #cccccc; font-family: \'Times New Roman\'; font-size: 18pt;'>" +
"  <td style = 'text-align: center; height: 20px;' ><strong> א </strong></td>" +
"   <td style = 'text-align: center; height: 20px;' ><strong> ב </strong></td>" +
"    <td style = 'text-align: center; height: 20px;' ><strong> ג </strong></td>" +
"     <td style = 'text-align: center; height: 20px;' ><strong> ד </strong></td>" +
"      <td style = 'text-align: center; height: 20px;' ><strong> ה </strong></td>" +
"       <td style = 'text-align: center; height: 20px;' ><strong> ו </strong></td>" +
"        <td style = 'text-align: center; height: 20px;' ><strong> ז </strong></td>" +
"         <td style = 'text-align: center; height: 20px;' ><strong> ח </strong></td>" +
"          <td style = 'text-align: center; height: 20px;' ><strong> ט </strong></td>" +
"           <td style = 'text-align: center; height: 20px;' ><strong> י </strong></td>" +
"            </tr>" +
"            <tr style = 'height: 22px;' >" +
"             <td style = 'text-align: center; height: 22px;' > a </td>" +
"              <td style = 'text-align: center; height: 22px;' > b </td>" +
"               <td style = 'text-align: center; height: 22px;' > g </td>" +
"                <td style = 'text-align: center; height: 22px;' > d </td>" +
"                 <td style = 'text-align: center; height: 22px;' > h </td>" +
"                  <td style = 'text-align: center; height: 22px;' > w </td>" +
"                   <td style = 'text-align: center; height: 22px;' > z </td>" +
"                    <td style = 'text-align: center; height: 22px;' > x </td>" +
"                     <td style = 'text-align: center; height: 22px;' > j </td>" +
"                      <td style = 'text-align: center; height: 22px;' > y </td>" +
"                       </tr>" +
"                       <tr style = 'height: 8px; background-color: #cccccc; font-family: \'Times New Roman\'; font-size: 18pt;' >" +
"                        <td style = 'text-align: center; height: 8px;' ><strong> כ </strong></td>" +
"                         <td style = 'text-align: center; height: 8px;' ><strong> ל </strong></td>" +
"                          <td style = 'text-align: center; height: 8px;' ><strong> מ </strong></td>" +
"                           <td style = 'text-align: center; height: 8px;' ><strong> נ </strong></td>" +
"                            <td style = 'text-align: center; height: 8px;' ><strong> ס </strong></td>" +
"                             <td style = 'text-align: center; height: 8px;' ><strong> ע </strong></td>" +
"                              <td style = 'text-align: center; height: 8px;' ><strong> פ </strong></td>" +
"                               <td style = 'text-align: center; height: 8px;' ><strong> צ </strong></td>" +
"                                <td style = 'text-align: center; height: 8px;' ><strong> ק </strong></td>" +
"                                 <td style = 'text-align: center; height: 8px;' ><strong> ר </strong></td>" +
"                                  </tr>" +
"                                  <tr style = 'height: 22px;' >" +
"                                   <td style = 'text-align: center; height: 22px;'> k </td>" +
"                                    <td style = 'text-align: center; height: 22px;'> l </td>" +
"                                     <td style = 'text-align: center; height: 22px;'> m </td>" +
"                                      <td style = 'text-align: center; height: 22px;'> n </td>" +
"                                       <td style = 'text-align: center; height: 22px;'> s </td>" +
"                                        <td style = 'text-align: center; height: 22px;'> [ </td>" +
"                                         <td style = 'text-align: center; height: 22px;'> p </td>" +
"                                          <td style = 'text-align: center; height: 22px;'> c </td>" +
"                                           <td style = 'text-align: center; height: 22px;'> q </td>" +
"                                            <td style = 'text-align: center; height: 22px;'> r </td>" +
"                                             </tr>" +
"                                             <tr style = 'height: 17.2847px; background-color: #cccccc; font-family: \'Times New Roman\'; font-size: 18pt;'>" +
"                                              <td style = 'text-align: center; height: 17.2847px;'><strong> ש </strong></td>" +
"                                               <td style = 'text-align: center; height: 17.2847px;'><strong> ת </strong></td>" +
"                                                <td style = 'text-align: center; height: 17.2847px;'><strong> ך </strong></td>" +
"                                                 <td style = 'text-align: center; height: 17.2847px;'><strong> ם </strong></td>" +
"                                                  <td style = 'text-align: center; height: 17.2847px;'><strong> ן </strong></td>" +
"                                                   <td style = 'text-align: center; height: 17.2847px;'><strong> ף </strong></td>" +
"                                                    <td style = 'text-align: center; height: 17.2847px;'><strong> ץ </strong></td>" +
"                                                     <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                      <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                       <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                        </tr>" +
"                                                        <tr style = 'height: 22px;'>" +
"                                                         <td style = 'text-align: center; height: 22px;' > f </td>" +
"                                                          <td style = 'text-align: center; height: 22px;' > t </td>" +
"                                                           <td style = 'text-align: center; height: 22px;' > $ </td>" +
"                                                            <td style = 'text-align: center; height: 22px;' > ~ </td>" +
"                                                             <td style = 'text-align: center; height: 22px;' > ! </td>" +
"                                                              <td style = 'text-align: center; height: 22px;' > @ </td>" +
"                                                               <td style = 'text-align: center; height: 22px;' > # </td>" +
"                                                                <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                 <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                  <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                   </tr>" +
"                                                                   </tbody>" +
"                                                                   </table>" +
"                                                                   <p> Wenn einer der Konsonanten eingetippt wird, passen sich die Buttons im oberen Bereich an, sodass man den eingetippten Konsonant mit passendem Vokal wählen kann. Klickt man auf einen solchen Button, wird der eingetippte Konsonant ohne Vokal durch den entsprechenden Konsonant mit ausgewähltem Vokal ersetzt.</p></body></html>";
            webBrowser1.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
