using Hangfire;
using HangFireDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class HangFireHelper
    {
        public JobInfo CreateJob(JobInfo jobInfo)
        {
            string guid = Guid.NewGuid().ToString();
            jobInfo.GUID = guid;


            //Linked Job
            //CreateLinkedJobs(jobInfo);

            //Scheduled Jobs/Delayed Jobs
            //CreateScheduleJob(jobInfo);

            //BackgroundJob
            //CreateBackgroundJob(jobInfo);

            //Recurring Job
            //CreateRecurringJob(jobInfo);
            return jobInfo;
        }

        private void CreateLinkedJobs(JobInfo jobInfo)
        {
            var jobId = BackgroundJob.Schedule(() => JobRunner.ExecuteJob(jobInfo), TimeSpan.FromSeconds(10));

            BackgroundJob.ContinueJobWith(jobId,
                () => JobRunner.ExecuteJob(jobInfo));
        }

        private void CreateScheduleJob(JobInfo jobInfo)
        {
            var jobId = BackgroundJob.Schedule(() => JobRunner.ExecuteJob(jobInfo), TimeSpan.FromSeconds(30));
            jobInfo.GUID = jobId;
        }

        private void CreateBackgroundJob(JobInfo jobInfo)
        {
            var jobId = BackgroundJob.Enqueue(() => JobRunner.ExecuteJob(jobInfo));
            jobInfo.GUID = jobId;
        }

        private void CreateRecurringJob(JobInfo jobInfo)
        {
            RecurringJob.AddOrUpdate(jobInfo.GUID, () =>  JobRunner.ExecuteJob(jobInfo)    , Cron.Minutely, TimeZoneInfo.Local);
        }
    }
}
