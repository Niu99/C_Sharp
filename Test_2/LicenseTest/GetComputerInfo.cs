using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseTest
{
    class GetComputerInfo
    {
        public static string GetComputerInformation()
        {
            string Info = string.Empty;
            string CpuId = GetCpuId();//获取CPU型号
            string BaseBoard = GetBaseBoard();
            string BIos = GetBIos();
            string Mac = GetMac();
            Info = string.Concat(CpuId, BaseBoard, BIos, Mac);
            return Info;
        }
        /// <summary>
        /// 获取CPU型号
        /// </summary>
        /// <returns></returns>
        private static string GetCpuId()
        {
            //string info = string.Empty;
            //info = GetHardWareInfo("Win32_Processor", "ProcessorId");
            //return info;
            return GetInfo("Win32_Processor", "ProcessorId");
        }
        
        private static string GetBaseBoard()
        {
            //string info = string.Empty;
            //info = GetHardWareInfo("Win32_BaseBoard", "SerialNumber");
            //return info;
            return GetInfo("Win32_BaseBoard", "SerialNumber");
        }

        private static string GetBIos()
        {
            //string info = string.Empty;
            //info = GetHardWareInfo("Win32_BIOS", "SerialNumber");
            //return info;

            return GetInfo("Win32_BIOS", "SerialNumber");
        }

        private static string GetMac()
        {
            string info = string.Empty;
            info = GetMacAddInfo();
            return info;
        }

        private static string GetInfo(string type,string num)
        {
            string info = string.Empty;
            info = GetHardWareInfo(type, num);
            return info;
            
        }
        private static string GetHardWareInfo(string typePath, string key)
        {
            try
            {
                ManagementClass managementClass = new ManagementClass(typePath);
                ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
                PropertyDataCollection propertyDataCollection = managementClass.Properties;
                foreach (PropertyData property in propertyDataCollection)
                {
                    if (property.Name == key)
                    {
                        foreach (ManagementObject management in managementObjectCollection)
                        {
                            return management.Properties[property.Name].Value.ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return string.Empty;
        }

        private static string GetMacAddInfo()
        {
            string key = "SYSTEM\\CurrentControlSet\\Control\\Network\\{ 4D36E972 - E325 - 11CE - BFC1 - 08002BE10318}\\";
            string macadd = string.Empty;
            try
            {
                NetworkInterface[] NetInt = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface network in NetInt)
                {
                    if (network.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                        && network.GetPhysicalAddress().ToString().Length != 0)
                    {
                        string fRegistryKey = key + network.Id + "\\Connection";
                        RegistryKey regkey = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                        if (regkey != null)
                        {
                            string fPnpInstanceID = regkey.GetValue("PnpInstanceID", "").ToString();
                            int fMediaSubType = Convert.ToInt32(regkey.GetValue("MediaSubType", 0));
                            if (fPnpInstanceID.Length > 3 && fPnpInstanceID.Substring(0, 3) == "PCI")
                            {
                                macadd = network.GetPhysicalAddress().ToString();
                                for (int i = 1; i < 6; i++)
                                {
                                    macadd = macadd.Insert(3 * i - 1, ":");
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("");
            }
            return macadd;
        }



    }
}
