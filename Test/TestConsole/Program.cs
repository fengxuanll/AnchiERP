using Anchi.ERP.Domain.Sequences.Enum;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Filter;
using Anchi.ERP.Repository.Sequences;
using Anchi.ERP.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Task.Factory.StartNew(EachWriteSequence);
            }

            Console.ReadLine();
        }

        static void EachWriteSequence()
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(WriteSequence);
            }
        }

        static void WriteSequence()
        {
            Console.WriteLine("财务序列：" + SequenceRepository.Instance.GetNextValue(EnumSequenceType.Finance).ToString("0000"));
            Console.WriteLine("采购序列：" + SequenceRepository.Instance.GetNextValue(EnumSequenceType.Purchase).ToString("0000"));
            Console.WriteLine("维修序列：" + SequenceRepository.Instance.GetNextValue(EnumSequenceType.Repair).ToString("0000"));
            Console.WriteLine("销售序列：" + SequenceRepository.Instance.GetNextValue(EnumSequenceType.Sale).ToString("0000"));
        }
    }
}
