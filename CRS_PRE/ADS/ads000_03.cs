using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic.Devices;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace CRS_PRE.ADS
{
    public partial class ads000_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;

        public ads000_03()
        {
            InitializeComponent();
        }

        private void fi_lim_frm() {
            lb_nom_equ.Text = string.Empty;
            tb_sis_ope.Text = string.Empty;
            tb_pro_ces.Text = string.Empty;
            tb_mem_ran.Text = string.Empty;
            tb_pla_sis.Text = string.Empty;
            tb_bio_sis.Text = string.Empty;
            tb_dir_ipp.Text = string.Empty;
            tb_dir_mac.Text = string.Empty;
            tb_fir_win.Text = string.Empty;
            tb_red_dom.Text = string.Empty;
            tb_red_pub.Text = string.Empty;
            tb_net_fra.Text = string.Empty;
            tb_run_cry.Text = string.Empty;
        }

        private void ads000_03_Load(object sender, EventArgs e)
        {
            // Limpia los controles
            fi_lim_frm();

            // Obtiene Nombre del Equipo
            lb_nom_equ.Text = SystemInformation.ComputerName;

            // Despliega Información del Sistema Operativo
            tb_sis_ope.Text = fi_sis_ope();

            // Despliega Información del procesador
            tb_pro_ces.Text = fi_inf_pro();

            // Obtiene Informacion Memoria RAN                      
            tb_mem_ran.Text = fi_mem_ran();

            // Obtiene la placa base del sistema
            tb_pla_sis.Text = fi_pla_bas();

            // Obtiene la Version Bios
            tb_bio_sis.Text = fi_ser_bio();

            // Obtiene la Direccion Ip local
            tb_dir_ipp.Text = fi_dir_ipp();

            // Obtiene la Direccion MAC
            tb_dir_mac.Text = fi_dir_mac();

            // Obtiene el estado del Firewall de Windows
            fi_fir_win();

            // Obtiene la Version del NET.Framework
            tb_net_fra.Text = fi_net_fra();

            // Obtiene la Version del Runtime CrystalReportView
            tb_run_cry.Text = fi_cry_rep();
        }

        private static string fi_sis_ope()
        {
            // Obtiene algunas claves del sistema operativo */
            string cla_ve1 = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
            string cla_ve2 = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";

            // Obtiene Registro KEY */
            RegistryKey loc_mac = Registry.LocalMachine;
            RegistryKey sub_cl1 = loc_mac.OpenSubKey(cla_ve1);
            RegistryKey sub_cl2 = loc_mac.OpenSubKey(cla_ve2);

            // Obtiene el nombre del Sistema Operativo */
            string ver_nam = new ComputerInfo().OSFullName.Replace("Microsoft ", "");
            string com_pil = sub_cl1.GetValue("CurrentBuild").ToString();
            string rel_ide = sub_cl1.GetValue("ReleaseId").ToString();
            string arq_pro = sub_cl2.GetValue("PROCESSOR_ARCHITECTURE").ToString();
            if (arq_pro.Equals("AMD64"))
                arq_pro = "64 bits";
            else
                arq_pro = "32 bits";


            // Despliega Mensaje
            return ver_nam + " " + arq_pro + " Versión: " + com_pil + "." + rel_ide;
        }

        private static string fi_inf_pro()
        {
            string cla_pro = @"HARDWARE\DESCRIPTION\System\CentralProcessor\0";
            RegistryKey key_pro = Registry.LocalMachine.OpenSubKey(cla_pro);
            return key_pro.GetValue("ProcessorNameString").ToString();
        }

        private static string fi_mem_ran()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject item in moc)
            {
                return Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1048576 / 1024, 0)) + " GB";
            }

            return "No Lecturable";
        }

        private static string fi_pla_bas()
        {
            // Obteniendo lista de placas base
            ManagementObjectCollection mbCol = new ManagementClass("Win32_BaseBoard").GetInstances();
            // Enumerando la lista
            ManagementObjectCollection.ManagementObjectEnumerator mbEnum = mbCol.GetEnumerator();
            // Mueva el cursor al primer elemento de la lista
            mbEnum.MoveNext();
            // Obtener el número de serie de esa placa base específica
            return ((ManagementObject)(mbEnum.Current)).Properties["SerialNumber"].Value.ToString();
        }

        private static string fi_ser_bio()
        {
            SelectQuery Sq = new SelectQuery("Win32_BIOS");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject mo in osDetailsCollection)
            {                
                return mo["SMBIOSBIOSVersion"].ToString();
            }

            return "No Lecturable";
        }

        private static string fi_dir_ipp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No Conectado";
        }

        private static string fi_dir_mac()
        {
            try
            {
                string mac_add = string.Empty;
                string dir_mac = string.Empty;

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up){
                        mac_add += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }

                for (int n = 0; n < mac_add.Length; n++) {
                    if (n == 2 || n == 4 || n == 6 || n == 8 || n == 10 || n == 12){
                        dir_mac = dir_mac + ":" + mac_add.Substring(n, 1);
                    }else {
                        dir_mac = dir_mac + mac_add.Substring(n, 1);
                    }
                }

                return dir_mac;

            }catch (Exception) {
                return "No Conectado";
            }
        }

        private void fi_fir_win()
        {
            // Crea constante para los tipos de cortafuegos.
            const int NET_FW_PROFILE2_DOMAIN = 1;
            const int NET_FW_PROFILE2_PRIVATE = 2;
            const int NET_FW_PROFILE2_PUBLIC = 4;

            // Cree el tipo de firewall.
            Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");

            // Utilice el tipo de cortafuegos para crear un objeto de administrador de cortafuegos.
            dynamic FWManager = Activator.CreateInstance(FWManagerType);

            // Obtén la configuración del firewall.
            bool CheckDomain =
                FWManager.FirewallEnabled(NET_FW_PROFILE2_DOMAIN);
            bool CheckPrivate =
                FWManager.FirewallEnabled(NET_FW_PROFILE2_PRIVATE);
            bool CheckPublic =
                FWManager.FirewallEnabled(NET_FW_PROFILE2_PUBLIC);

            // Verifique el estado del firewall.
            if (CheckDomain == true && CheckPrivate == true && CheckPublic == true){
                tb_fir_win.Text = "Seguro";
            }else {
                tb_fir_win.Text = "Inseguro";
            }

            if (CheckDomain == true){
                tb_red_dom.Text = "Activado";
            }else {
                tb_red_dom.Text = "Desactivado";
            }

            if (CheckPrivate == true){
                tb_red_pri.Text = "Activado";
            }else{
                tb_red_pri.Text = "Desactivado";
            }

            if (CheckPublic == true){
                tb_red_pub.Text = "Activado";
            }else{
                tb_red_pub.Text = "Desactivado";
            }
        }

        private static string fi_net_fra()
        {
            try
            {
                string net_fra = Environment.Version.ToString();
                int m = 0;
                int i = 0;

                for (int n = 0; n < net_fra.Length; n++)
                {
                    if (net_fra.Substring(n, 1) == ".")
                    {
                        i = i + 1;
                        if (i == 2)
                        {
                            m = n;
                        }
                    }
                }

                return net_fra.Substring(0, m + 2);
            }
            catch (Exception)
            {
                return "No Instalado";
            }
        }

        private static string fi_cry_rep()
        {
            try
            {                        
                foreach (Assembly MyVerison in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (MyVerison.FullName.Substring(0, 38) == "CrystalDecisions.CrystalReports.Engine")
                    {
                        System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(MyVerison.Location);
                        return fileVersionInfo.FileVersion.ToString();
                    }
                }
                return "No Instalado";
            }
            catch (Exception)
            {
                return "No Instalado";
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
