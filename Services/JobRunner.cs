using HangFireDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class JobRunner
    {
        public static void ExecuteJob(JobInfo jobInfo)
        {
            //Execute Job
            Console.Write($"{jobInfo.JobName}");
            string path = @"E:\WORKSPACE\Projects\Learning\Tutorials\ASP.Net Core\HangFire";
            path = Path.Combine(path, string.Concat(jobInfo.GUID,DateTime.Now.Ticks, ".txt"));
            File.WriteAllText(path, jobInfo.Description);

        }
    }
}
