using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;
using System.Xml;

namespace Btc_Calculator
{
    class MyClass
    {
        public static List<string> GetNetworkHashrate(string Xpath)
        {
            Uri url = new Uri("https://bitcoinwisdom.com/bitcoin/difficulty");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(html);
            //İndirilen Html kodları, yukarıda oluşturulan htmlagilitypack'den türetilen htmldocument nesnesine aktarılıyor...

            HtmlNodeCollection basliklar = htmldoc.DocumentNode.SelectNodes(Xpath);
            //İstediğimiz Element'in özelliğini yani filtrelemeyi yapacağımız alan...
            /// html / body / div[2] / table[2] / tbody / tr[4] / td[2]

            List<string> liste = new List<string>();
            //Gelen veriyi saklayacağımız alan String tipinden oluşturuluyor.

            foreach (var baslik in basliklar)
            {
                liste.Add(baslik.InnerText);
                //Parse ettiğimiz linklerin üzerinde yazan yazılar dizi halinde listeye ekleniyor...
            }

            return liste;
            //for (int i = 0; i < liste.Count; i++)
            //{
            //    Console.WriteLine(liste[i]);
            //    //Basit bir döngü ile aldığımız veriler ekrana yazılıyor...
            //}

            //Console.ReadLine();
            ////Ekran beklemede :)
        }

        public static List<string> GetCurrency(string Xpath)
        {
            Uri url = new Uri("https://btc-e.com/exchange/btc_usd");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(html);
            //İndirilen Html kodları, yukarıda oluşturulan htmlagilitypack'den türetilen htmldocument nesnesine aktarılıyor...

            HtmlNodeCollection basliklar = htmldoc.DocumentNode.SelectNodes(Xpath);
            //İstediğimiz Element'in özelliğini yani filtrelemeyi yapacağımız alan...
            /// html / body / div[2] / table[2] / tbody / tr[4] / td[2]

            List<string> liste = new List<string>();
            //Gelen veriyi saklayacağımız alan String tipinden oluşturuluyor.

            foreach (var baslik in basliklar)
            {
                liste.Add(baslik.InnerText);
                //Parse ettiğimiz linklerin üzerinde yazan yazılar dizi halinde listeye ekleniyor...
            }

            return liste;
            //for (int i = 0; i < liste.Count; i++)
            //{
            //    Console.WriteLine(liste[i]);
            //    //Basit bir döngü ile aldığımız veriler ekrana yazılıyor...
            //}

            //Console.ReadLine();
            ////Ekran beklemede :)
        }

        public static List<string> GetTRYCurrency(string siteURL,string Xpath)
        {
            Uri url = new Uri(siteURL);
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(html);
            //İndirilen Html kodları, yukarıda oluşturulan htmlagilitypack'den türetilen htmldocument nesnesine aktarılıyor...

            HtmlNodeCollection basliklar = htmldoc.DocumentNode.SelectNodes(Xpath);
            //İstediğimiz Element'in özelliğini yani filtrelemeyi yapacağımız alan...
            /// html / body / div[2] / table[2] / tbody / tr[4] / td[2]

            List<string> liste = new List<string>();
            //Gelen veriyi saklayacağımız alan String tipinden oluşturuluyor.

            foreach (var baslik in basliklar)
            {
                liste.Add(baslik.InnerText);
                //Parse ettiğimiz linklerin üzerinde yazan yazılar dizi halinde listeye ekleniyor...
            }

            return liste;
            //for (int i = 0; i < liste.Count; i++)
            //{
            //    Console.WriteLine(liste[i]);
            //    //Basit bir döngü ile aldığımız veriler ekrana yazılıyor...
            //}

            //Console.ReadLine();
            ////Ekran beklemede :)
        }
    }

    class DövizKur
    {
        string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

        public static string USD()
        {
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            //return (string.Format("USD: {0}", USD));
            return USD;
        }

        public string USD_Date()
        {

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            return (string.Format("Tarih {0} || USD     : {1}", exchangeDate.ToShortDateString(), USD));
        }

        public string EURO()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            return (string.Format("EURO: {0}", EURO));
        }

        public string EURO_Date()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            return (string.Format("Tarih {0} || EURO   : {1}", exchangeDate.ToShortDateString(), EURO));
        }


        public string POUND()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            return (string.Format("POUND: {0}", POUND));
        }

        public string POUND_Date()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            return (string.Format("Tarih {0} || POUND: {1}", exchangeDate.ToShortDateString(), POUND));
        }


    }

}
