using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace CuckooCommon
{
    public class JobScheduler
    {
        public class EmailJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                using (var message = new MailMessage("test@acsal.com", "nmonasterio@acsal.com"))
                {

                    JobDataMap dataMap = context.MergedJobDataMap;

                    var superStuff = (Amazingers)dataMap.Where(d => d.Key == "superstuff").First().Value;

                    message.Subject = dataMap.GetString("name");
                    message.Body = "Woot";
                    using (SmtpClient client = new SmtpClient
                    {
                        Host = "relay.ntdomain.lan"
                        
                    })
                    {
                        client.Send(message);
                    }
                }
            }
        }


        public static void StartScheduler()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

            scheduler.Start();

            var jobs = Jobs.GetAllJobs();

            var super = new Amazingers();
            super.SuperValue = "Wahoo";

            IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            var jobData = new JobDataMap();
            jobData.Add("superstuff", super);
            jobData.Add("name", "foo");

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInSeconds(30)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                  ).UsingJobData(jobData)
                .Build();

            scheduler.ScheduleJob(job, trigger);

        }
    }

    public class Amazingers
    {
        public string SuperValue { get; set; } 
    }
}
