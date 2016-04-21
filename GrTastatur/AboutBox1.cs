using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrTastatur
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
            webBrowser1.DocumentText = "<html><head><title>GrTastur - Hilfe</title></head><body><p>Das Programm funktioniert so, dass man in dem Textfeld deutsche Buchstaben eintippt, welche dann direkt in griechische Buchstaben umgewandelt werden. Dabei entsprechen folgende Buchstaben einander:</p>" +
"<table style='width: 600px;'>" +
"<tbody>" +
" <tr style='height: 20px; background-color: #cccccc; font-family: \'Times New Roman\'; font-size: 18pt;'>" +
"  <td style = 'text-align: center; height: 20px;' ><strong> α </strong></td>" +
"   <td style = 'text-align: center; height: 20px;' ><strong> β </strong></td>" +
"    <td style = 'text-align: center; height: 20px;' ><strong> γ </strong></td>" +
"     <td style = 'text-align: center; height: 20px;' ><strong> δ </strong></td>" +
"      <td style = 'text-align: center; height: 20px;' ><strong> ε </strong></td>" +
"       <td style = 'text-align: center; height: 20px;' ><strong> ζ </strong></td>" +
"        <td style = 'text-align: center; height: 20px;' ><strong> η </strong></td>" +
"         <td style = 'text-align: center; height: 20px;' ><strong> θ </strong></td>" +
"          <td style = 'text-align: center; height: 20px;' ><strong> ι </strong></td>" +
"           <td style = 'text-align: center; height: 20px;' ><strong> κ </strong></td>" +
"            </tr>" +
"            <tr style = 'height: 22px;' >" +
"             <td style = 'text-align: center; height: 22px;' > a </td>" +
"              <td style = 'text-align: center; height: 22px;' > b </td>" +
"               <td style = 'text-align: center; height: 22px;' > g </td>" +
"                <td style = 'text-align: center; height: 22px;' > d </td>" +
"                 <td style = 'text-align: center; height: 22px;' > e </td>" +
"                  <td style = 'text-align: center; height: 22px;' > z </td>" +
"                   <td style = 'text-align: center; height: 22px;' > h </td>" +
"                    <td style = 'text-align: center; height: 22px;' > q </td>" +
"                     <td style = 'text-align: center; height: 22px;' > i </td>" +
"                      <td style = 'text-align: center; height: 22px;' > k </td>" +
"                       </tr>" +
"                       <tr style = 'height: 8px; background-color: #cccccc; font-family: \'Times New Roman\'; font-size: 18pt;' >" +
"                        <td style = 'text-align: center; height: 8px;' ><strong> λ </strong></td>" +
"                         <td style = 'text-align: center; height: 8px;' ><strong> μ </strong></td>" +
"                          <td style = 'text-align: center; height: 8px;' ><strong> ν </strong></td>" +
"                           <td style = 'text-align: center; height: 8px;' ><strong> ξ </strong></td>" +
"                            <td style = 'text-align: center; height: 8px;' ><strong> ο </strong></td>" +
"                             <td style = 'text-align: center; height: 8px;' ><strong> π </strong></td>" +
"                              <td style = 'text-align: center; height: 8px;' ><strong> ρ </strong></td>" +
"                               <td style = 'text-align: center; height: 8px;' ><strong> σ </strong></td>" +
"                                <td style = 'text-align: center; height: 8px;' ><strong> ς </strong></td>" +
"                                 <td style = 'text-align: center; height: 8px;' ><strong> τ </strong></td>" +
"                                  </tr>" +
"                                  <tr style = 'height: 22px;' >" +
"                                   <td style = 'text-align: center; height: 22px;'> l </td>" +
"                                    <td style = 'text-align: center; height: 22px;'> m </td>" +
"                                     <td style = 'text-align: center; height: 22px;'> n </td>" +
"                                      <td style = 'text-align: center; height: 22px;'> j </td>" +
"                                       <td style = 'text-align: center; height: 22px;'> o </td>" +
"                                        <td style = 'text-align: center; height: 22px;'> p </td>" +
"                                         <td style = 'text-align: center; height: 22px;'> r </td>" +
"                                          <td style = 'text-align: center; height: 22px;'> s </td>" +
"                                           <td style = 'text-align: center; height: 22px;'> v </td>" +
"                                            <td style = 'text-align: center; height: 22px;'> t </td>" +
"                                             </tr>" +
"                                             <tr style = 'height: 17.2847px; background-color: #cccccc; font-family: \'Times New Roman\'; font-size: 18pt;'>" +
"                                              <td style = 'text-align: center; height: 17.2847px;'><strong> υ </strong></td>" +
"                                               <td style = 'text-align: center; height: 17.2847px;'><strong> φ </strong></td>" +
"                                                <td style = 'text-align: center; height: 17.2847px;'><strong> χ </strong></td>" +
"                                                 <td style = 'text-align: center; height: 17.2847px;'><strong> ψ </strong></td>" +
"                                                  <td style = 'text-align: center; height: 17.2847px;'><strong> ω </strong></td>" +
"                                                   <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                    <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                     <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                      <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                       <td style = 'text-align: center; height: 17.2847px;'><strong> </strong></td>" +
"                                                        </tr>" +
"                                                        <tr style = 'height: 22px;'>" +
"                                                         <td style = 'text-align: center; height: 22px;' > y </td>" +
"                                                          <td style = 'text-align: center; height: 22px;' > f </td>" +
"                                                           <td style = 'text-align: center; height: 22px;' > x </td>" +
"                                                            <td style = 'text-align: center; height: 22px;' > c </td>" +
"                                                             <td style = 'text-align: center; height: 22px;' > w </td>" +
"                                                              <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                               <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                 <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                  <td style = 'text-align: center; height: 22px;' ></td>" +
"                                                                   </tr>" +
"                                                                   </tbody>" +
"                                                                   </table>" +
"                                                                   <p> Wenn man<strong> α, ε, η, ι, ο, ρ, υ </strong> oder <strong> ω </strong> eintippt, passen sich die Buttons im oberen Bereich an, sodass man den eingetippten Buchstaben mit passendem Akzent / Asper / Lenis / Jota / Zirkumflex wählen kann. Klickt man auf einen solchen Button, wird der eingetippte Buchstabe ohne Zeichen durch den entsprechenden Buchstaben mit Zeichen ersetzt. <strong> Derzeit funktioniert das Programm nur mit Kleinbuchstaben.</strong></p></body></html>";
            webBrowser1.Show();
        }
    }
}
