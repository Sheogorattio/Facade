using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        public class PSU
        {
            public void Start() { Console.WriteLine("PSU: Turned on"); }
        }
        public class BIOS
        {
            public void POST() { Console.WriteLine("BIOS: P.O.S.T."); }
        }
        public class RAM
        {
            public void CheckRAM() { Console.WriteLine("Checking RAM"); }
        }
        public class HDD
        {
            public void SMART() { Console.WriteLine("S.M.A.R.T check"); }
        }
        public class Videocard
        {
            public void Start() { Console.WriteLine("GPU: Start"); }
            public void CheckMonitor() { Console.WriteLine("GPU: Monitor connection check"); }
        }
        public class PC
        {
            PSU psu;
            BIOS bios;
            RAM ram;
            HDD hdd;
            Videocard videocard;
            public PC(PSU psu, BIOS bios, RAM ram, HDD hdd, Videocard videocard)
            {
                this.psu = psu;
                this.bios = bios;
                this.ram = ram;
                this.hdd = hdd;
                this.videocard = videocard;
            }
            public void Start()
            {
                psu.Start();
                bios.POST();
                ram.CheckRAM();
                hdd.SMART();
                videocard.Start();
                videocard.CheckMonitor();
            }
        }
        static void Main(string[] args)
        {
            HDD hdd = new HDD();
            PSU psu = new PSU();
            BIOS bios = new BIOS();
            RAM ram = new RAM();
            Videocard videocard = new Videocard();
            PC pc = new PC(psu, bios, ram,hdd, videocard);
            pc.Start();
            Console.ReadKey();
        }
    }
}
