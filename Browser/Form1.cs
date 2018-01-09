using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }
            
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            materialSingleLineTextField2.Text = "https://www.google.com";
            ChromiumWebBrowser chrome = new ChromiumWebBrowser(materialSingleLineTextField2.Text);
            chrome.Parent = materialTabControl1.SelectedTab;
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += chrome_AddressChanged;
            chrome.TitleChanged += chrome_TitleChanged;
        }

        void chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() => { materialTabControl1.Text = e.Address; }));
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = materialTabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if(chrome != null)
                chrome.Load(materialSingleLineTextField2.Text);
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = materialTabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chrome != null)
                chrome.Refresh();
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = materialTabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chrome != null) {
                if (chrome.CanGoForward)
                {
                    chrome.Forward();
                }
            }
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chrome = materialTabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
             if (chrome != null)
             {
                 if (chrome.CanGoBack)
                 {
                     chrome.Back();
                 }
             }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New tab";
            materialTabControl1.Controls.Add(tab);
            materialTabControl1.SelectTab(materialTabControl1.TabCount - 1);
            ChromiumWebBrowser chrome = new ChromiumWebBrowser("https://www.google.com");
            chrome.Parent = tab;
            chrome.Dock = DockStyle.Fill;
            materialSingleLineTextField2.Text = "https://www.google.com";
            chrome.AddressChanged += chrome_AddressChanged;
            chrome.TitleChanged += chrome_TitleChanged;
        }

        void chrome_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() => { materialTabControl1.SelectedTab.Text = e.Title; }));
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }




    }
}
