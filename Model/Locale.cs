using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.IO;

namespace Model
{
    // Pattern:
    /*public sealed class Singleton
        {
            private static readonly Object s_lock = new Object();
            private static Singleton instance = null;

            private Singleton()
            {
            }

            public static Singleton Instance
            {
                get
                {
                    if (instance != null) return instance;
                    Monitor.Enter(s_lock);
                    Singleton temp = new Singleton();
                    Interlocked.Exchange(ref instance, temp);
                    Monitor.Exit(s_lock);
                    return instance;
                }
            }
        }*/
    // Singleton class
    public sealed class Locale
    {
        private static readonly Object s_lock = new Object();
        private static Locale instance = null;

        private string[] keys;
        private string[] values;
        private const int maxKeys = 100;
        private const string localesPath = "Locales/";
        private const string localesExt = ".txt";

        private Locale() // init
        {
            string culture = CultureInfo.CurrentCulture.Name;
            ReadLocaleFile(culture, out string[] k1, out string[] v1, out int c1);

            string[] k2 = null, v2 = null;
            int c2 = 0;
            string[] lang = culture.Split(new Char[] { '-' }, 2);
            if (lang.Count() > 1)
            {
                k2 = new string[maxKeys];
                v2 = new string[maxKeys];
                ReadLocaleFile(lang[0], out k2, out v2, out c2);
            }
            if (c1 == 0 && c2 == 0)
            {
                keys = new string[0];
                values = new string[0];
            }
            else if (c2 == 0)
            {
                FillArray(c1, k1, v1);
            }
            else if (c1 == 0)
            {
                FillArray(c2, k2, v2);
            }
            else
            {
                int i1, i2;
                for (i2 = 0; i2 < c2; i2++)
                    for (i1 = 0; i1 < c1; i1++)
                        if (k1[i1] == k2[i2])
                        {
                            k2[i2] = "";
                            break;
                        }
                for (i2 = 0; i2 < c2; i2++)
                    if (k2[i2] != "")
                    {
                        k1[c1] = k2[i2];
                        v1[c1] = v2[i2];
                        c1++;
                        if (c1 >= maxKeys) throw new Exception("Count of params in " + culture
                            + " and " + lang[0] + " is greater than maximum (" + maxKeys + ")");
                    }
                FillArray(c1, k1, v1);
            }
        }

        private void FillArray(int c, string[] k, string[] v)
        {
            keys = new string[c];
            values = new string[c];
            for (int i = 0; i < c; i++)
            {
                keys[i] = k[i];
                values[i] = v[i].Replace("\\n","\n");
            }
        }

        private void ReadLocaleFile(string file_name, out string[] keys, out string[] values, out int count)
        {
            count = 0;
            string fn = localesPath + file_name + localesExt;
            if (File.Exists(fn))
            {
                keys = new string[maxKeys];
                values = new string[maxKeys];
                using (StreamReader sr = File.OpenText(fn))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s!="" && s[0] > 'A' && s[0] < 'z')
                        {
                            string[] t = s.Split(new Char[] { '=' }, 2);
                            if (t.Count() == 2)
                            {
                                if (count >= maxKeys) throw new Exception("Count of params in Locale file "
                                    + fn + " is greater than maximum (" + maxKeys + ")");
                                keys[count] = t[0].Trim();
                                values[count] = t[1].Trim();
                                count++;
                            }
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                keys = new string[0];
                values = new string[0];
            }
        }

        public string Get(string key)
        {
            for (int i = keys.Count() - 1; i >= 0; i--)
            {
                if (keys[i] == key) return values[i];
            }
            return "";
        }

        public static Locale Instance
        {
            get
            {
                if (instance != null) return instance;
                Monitor.Enter(s_lock);
                Locale temp = new Locale();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(s_lock);
                return instance;
            }
        }
    }
}
