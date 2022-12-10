using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    internal class Auto
    {
        private string znacka;
        private int spotrebaNaSto;
        private int ujetoCelkem;
        private DateTime okamzikRozjezdu;
        private DateTime dobaJizdyCelkem;
        bool jede;
        public Auto(string znacka, int spotrebaNaSto)
        {
            this.znacka = znacka;
            this.spotrebaNaSto = spotrebaNaSto;
            jede = false;
        }
        public string Jede
        {
            get
            {
                if (jede == false)
                {
                    return "stojí";
                }
                else
                {
                    return "jede";
                }
            }
        }
        public int VratUjeteKm()
        {
            return ujetoCelkem;
        }
        public void Rozjed()
        {
            jede = true;
            okamzikRozjezdu = DateTime.Now;
        }
        public void Zastav(int ujeto)
        {
            jede = false;
            ujetoCelkem += ujeto;
            TimeSpan timespan = DateTime.Now - okamzikRozjezdu;
            dobaJizdyCelkem = dobaJizdyCelkem.AddSeconds(timespan.TotalSeconds);
        }
        public double CelkovaSpotreba(int spotrebaNaSto)
        {
            return (double)spotrebaNaSto * ((double)ujetoCelkem / 100);
        }

        public override string ToString()
        {
            return " Značka: " + znacka + "\n Celkem ujeto: " + VratUjeteKm() + "\n Celková spotřeba: " + CelkovaSpotreba(spotrebaNaSto) + "\n Stav auta: " + Jede + "\n Celková doba jízdy: " + dobaJizdyCelkem.Second + " vteřin";
        }
    }
}
