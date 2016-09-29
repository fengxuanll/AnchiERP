using Anchi.ERP.Common.Extensions;
using Anchi.ERP.Common.IO;
using Anchi.ERP.Common.Net;
using Anchi.ERP.Domain.Sequences.Enum;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Filter;
using Anchi.ERP.Repository.Sequences;
using Anchi.ERP.Service.Users;
using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelList = new List<AuSuburb>();
            var domainUrl = "http://auspost.com.au";
            var indexUrl = "http://auspost.com.au/postcode/suburb-index/";
            var charList = "b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z".Split(',').ToList();

            var filePath = @"D:\Suburb.txt";
            var errorFilePath = @"D:\Suburb_error.txt";
            foreach (var item in charList)
            {
                var i = 0;
                while (true)
                {
                    i++;

                    CQ dom = null;
                    try
                    {
                        dom = CQ.CreateFromUrl(indexUrl + item + i);
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine(string.Format("{0} {1} {2}", item, i, ex));
                        FileUtils.WriteText(errorFilePath, string.Format("{0} {1} {2}", item, i, ex));
                        break;
                    }

                    var suburbList = dom.Select("#suburb-index-list a").ToList();
                    if (!suburbList.Any())
                        break;

                    Console.WriteLine(i);
                    foreach (var suburbItem in suburbList)
                    {
                        var suburbName = suburbItem.InnerText;
                        Console.WriteLine(suburbName);

                        var href = suburbItem.GetAttribute("href");

                        var suburbCq = CQ.CreateFromUrl(domainUrl + href);
                        var resultList = suburbCq.Select(".resultsList.fn_tableResultsList.fn_tablePostcodeList tbody tr").ToList();
                        if (!resultList.Any())
                        {
                            var model = new AuSuburb { SuburbName = suburbName };
                            modelList.Add(model);
                            //FileUtils.WriteText(filePath, string.Format("{0}        {1}        {2}        {3}", model.SuburbName, model.Postcode, model.Suburb, model.Category));
                            break;
                        }

                        foreach (var resultItem in resultList)
                        {
                            var tdList = resultItem.ChildElements.ToList();

                            var model = new AuSuburb();
                            model.SuburbName = suburbName;
                            model.Postcode = tdList[0].ChildElements.First().InnerText;
                            model.Suburb = tdList[1].ChildElements.First().InnerText;
                            model.Category = tdList[2].InnerText;
                            modelList.Add(model);

                            //FileUtils.WriteText(filePath, string.Format("{0}        {1}        {2}        {3}", model.SuburbName, model.Postcode, model.Suburb, model.Category));
                        }
                    }
                }

                var sb = new StringBuilder();
                foreach (var modelItem in modelList)
                {
                    sb.AppendLine(string.Format("{0}        {1}        {2}        {3}", modelItem.SuburbName, modelItem.Postcode, modelItem.Suburb, modelItem.Category));
                }
                FileUtils.WriteText(filePath, sb.ToString());

                modelList.Clear();
            }
        }
    }

    public class AuSuburb
    {
        public string SuburbName
        { get; set; }

        public string Postcode
        { get; set; }

        public string Category
        { get; set; }

        public string Suburb
        { get; set; }
    }
}
