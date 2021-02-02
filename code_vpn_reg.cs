using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
namespace vpn
{
public partial class Form1 : Form
{
//time
int i = 5;
public Form1()
{
InitializeComponent();
//time
timer1.Enabled = true;
timer1.Start();
try
{
//regedit64
//string user = Environment.UserName;
RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
localKey = localKey.CreateSubKey(@"SOFTWARE\Fortinet\FortiClient\Sslvpn\Tunnels\Tecnisa S.A");
localKey.SetValue("Description", "VPN"); localKey.SetValue("Server", "186.225.113.253:10443");
localKey.SetValue("DATA1", "DigiteUsuarioDeRede");
//localKey.SetValue("DATA1", "" + user);
localKey.SetValue("ServerCert", "0");
localKey.Close();
//exit
this.Close();
}
catch (Exception ex)
{
//log
log.Text = (ex.Message);
}
}
private void timer1_Tick_1(object sender, EventArgs e)
{
//time
i = i - 1;
if (i == 0)
{
Application.Exit();
}
timeclosed.Text = i.ToString();
}
private void lblGitHub_Click_1(object sender, EventArgs e)
{
//link
Process.Start("https://github.com/rodesgom");
}
private void copy_Click(object sender, EventArgs e)
{
//copylog
Clipboard.SetText(log.Text);
}
}
}