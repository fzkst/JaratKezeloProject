namespace JaratKezeloProject
{
    public class Jarat
    {
        public List<Jarat> jaratok = new List<Jarat>();
        public List<string> repterek = new List<string> {"Auckland Airport", "Edinburgh Airport", "Hannover Airport", "Glasgow Airport", "Logan Airport"};
        public List<string> jaratszamok = new List<string> {"A111", "A112", "A113", "A114", "A115"};
        

        public Jarat(string jaratszam, string honnanRepter, string hovaRepter, DateTime indulas, int kesesIdeje)
        {
            Jaratszam = jaratszam;
            HonnanRepter = honnanRepter;
            HovaRepter = hovaRepter;
            Indulas = indulas;
            KesesIdeje = kesesIdeje;
        }

        public String Jaratszam { get; set; }
        public String HonnanRepter { get; set; }
        public String HovaRepter { get; set; }
        public DateTime Indulas { get; set; }
        public int KesesIdeje { get; set; }

       
        

        public void UjJarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas, int kesesIdeje)
        {
            if (jaratSzam == "")
            {
                throw new ArgumentException("A járatszámot meg kell adni!", nameof(jaratSzam));
            }
            if (jaratSzam == null)
            {
                throw new ArgumentNullException("A járatszámot meg kell adni!", nameof(jaratSzam));
            }
            if (honnanRepter == "" || hovaRepter == "")
            {
                throw new ArgumentException("A repteret meg kell adni!");
            }
            if (honnanRepter == null || hovaRepter == null)
            {
                throw new ArgumentNullException("A repteret meg kell adni!");
            }
            if (kesesIdeje != 0)
            {
                throw new ArgumentException("Új járat nem késhet!");
            }
            if (jaratszamok.Contains(jaratSzam))
            {
                throw new ArgumentException("Ez a járatszám már létezik!");
            }
            if (!repterek.Contains(honnanRepter) || !repterek.Contains(hovaRepter))
            {
                throw new ArgumentException("Nem létező reptér");
            }
            else
            {                
                Jarat jarat = new Jarat(jaratSzam, honnanRepter, hovaRepter, indulas, kesesIdeje);               
                jaratok.Add(jarat);
                repterek.Add(honnanRepter);
                repterek.Add(hovaRepter);
                jaratszamok.Add(jaratSzam);
            }
        }


        public void Keses(string jaratSzam, int keses)
        {            
            if (jaratSzam == "")
            {
                throw new ArgumentException("A járatszámot meg kell adni!", nameof(jaratSzam));
            }
            if (jaratSzam == null)
            {
                throw new ArgumentNullException("A járatszámot meg kell adni!", nameof(jaratSzam));
            }
            if (!jaratszamok.Contains(jaratSzam))
            {
                throw new ArgumentException("Ez a járatszám nem létezik!", nameof(jaratSzam));
            }
            foreach (Jarat obj in jaratok)
            {
                if (obj.Jaratszam == jaratSzam)
                {     
                    Console.WriteLine(obj.Jaratszam);
                    int osszesKeses = obj.KesesIdeje + keses;
                    if (osszesKeses < 0)
                    {
                        //throw new NegativKesesException(osszesKeses);
                        throw new ArgumentException(nameof(osszesKeses));
                    }
                    else
                    {
                        obj.KesesIdeje = osszesKeses;
                    }
                }
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            if (jaratSzam == "")
            {
                throw new ArgumentException("A járatszámot meg kell adni!", nameof(jaratSzam));
            }
            if (jaratSzam == null)
            {
                throw new ArgumentNullException("A járatszámot meg kell adni!", nameof(jaratSzam));
            }
            DateTime indulas = DateTime.MinValue;
            foreach (Jarat obj in jaratok)
            {
                if (obj.Jaratszam == jaratSzam)
                {   
                    TimeSpan keses = TimeSpan.FromMinutes(obj.KesesIdeje);
                    indulas = obj.Indulas.Add(keses);
                }
            }
            if (!jaratszamok.Contains(jaratSzam))
            {
                throw new ArgumentException("Nincs ilyen járatszámú gép!");
            }
            return indulas;
        }

        public List<string> jaratokRepuloterrol(string repter)
        {
            if (repter == "")
            {
                throw new ArgumentException("A repteret meg kell adni!", nameof(repter));
            }
            if (repter == null)
            {
                throw new ArgumentNullException("A repteret meg kell adni!", nameof(repter));
            }
            List<string> jaratokRepterrol = new List<string>();
            foreach (Jarat obj in jaratok)
            {
                if (repter == obj.HonnanRepter)
                {
                    jaratokRepterrol.Add(obj.Jaratszam);
                }
            }
            if (!repterek.Contains(repter))
            {
                throw new Exception("Nincs ilyen reptér!");
            }
            return jaratokRepterrol;
        }

    }
}