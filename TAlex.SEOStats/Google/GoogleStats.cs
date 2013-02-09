using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TAlex.SEOStats.Google
{
    public class GoogleStats : IBaseStats<GoogleResult>
    {
        private const UInt32 GoogleMagic = 0xE6359A60;
        private const string PRRequstPattern = "http://toolbarqueries.google.com/tbr?client=navclient-auto&features=Rank&ch={0}&features=Rank&q=info:{1}";


        #region IBaseStats<GoogleResult> Members

        public GoogleResult GetStats(string domain)
        {
            GoogleResult result = new GoogleResult();

            string url = new Uri(domain).AbsoluteUri;
            string checksum = CalcChecksum(url);
            string query = String.Format(PRRequstPattern, checksum, url);

            try
            {
                WebRequest request = WebRequest.Create(query);
                string response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                if (response.Length == 0)
                    result.PageRank = -1;
                else
                    result.PageRank = int.Parse(Regex.Match(response, "Rank_1:[0-9]:([0-9]+)").Groups[1].Value);

                result.Success = true;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        #endregion

        private static void Mix(ref UInt32 a, ref UInt32 b, ref UInt32 c)
        {
            a -= b; a -= c; a ^= c >> 13;
            b -= c; b -= a; b ^= a << 8;
            c -= a; c -= b; c ^= b >> 13;
            a -= b; a -= c; a ^= c >> 12;
            b -= c; b -= a; b ^= a << 16;
            c -= a; c -= b; c ^= b >> 5;
            a -= b; a -= c; a ^= c >> 3;
            b -= c; b -= a; b ^= a << 10;
            c -= a; c -= b; c ^= b >> 15;
        }

        public static string CalcChecksum(string url)
        {
            url = String.Format("info:{0}", url);

            int length = url.Length;

            UInt32 a, b;
            UInt32 c = GoogleMagic;

            int k = 0;
            int len = length;

            a = b = 0x9E3779B9;

            while (len >= 12)
            {
                a += (UInt32)(url[k + 0] + (url[k + 1] << 8) + (url[k + 2] << 16) + (url[k + 3] << 24));
                b += (UInt32)(url[k + 4] + (url[k + 5] << 8) + (url[k + 6] << 16) + (url[k + 7] << 24));
                c += (UInt32)(url[k + 8] + (url[k + 9] << 8) + (url[k + 10] << 16) + (url[k + 11] << 24));
                Mix(ref a, ref b, ref c);
                k += 12;
                len -= 12;
            }
            c += (UInt32)length;
            switch (len)  /* all the case statements fall through */
            {
                case 11:
                    c += (UInt32)(url[k + 10] << 24);
                    goto case 10;
                case 10:
                    c += (UInt32)(url[k + 9] << 16);
                    goto case 9;
                case 9:
                    c += (UInt32)(url[k + 8] << 8);
                    goto case 8;
                /* the first byte of c is reserved for the length */
                case 8:
                    b += (UInt32)(url[k + 7] << 24);
                    goto case 7;
                case 7:
                    b += (UInt32)(url[k + 6] << 16);
                    goto case 6;
                case 6:
                    b += (UInt32)(url[k + 5] << 8);
                    goto case 5;
                case 5:
                    b += (UInt32)(url[k + 4]);
                    goto case 4;
                case 4:
                    a += (UInt32)(url[k + 3] << 24);
                    goto case 3;
                case 3:
                    a += (UInt32)(url[k + 2] << 16);
                    goto case 2;
                case 2:
                    a += (UInt32)(url[k + 1] << 8);
                    goto case 1;
                case 1:
                    a += (UInt32)(url[k + 0]);
                    break;
                default:
                    break;
                /* case 0: nothing left to add */
            }

            Mix(ref a, ref b, ref c);

            return String.Format("6{0}", c);
        }
    }
}
