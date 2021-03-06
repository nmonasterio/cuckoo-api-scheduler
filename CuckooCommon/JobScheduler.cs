﻿using System;
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

                    var data = (Jobs)dataMap.Get("jobData");

                    message.Subject = data.Name;
                    message.Body = data.Id.ToString();
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
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

            //scheduler.Start();

            //var jobs = Jobs.GetAllJobs(;

            //foreach (var item in jobs)
            //{

                //IJobDetail job = JobBuilder.Create<EmailJob>().Build();

                //var jobData = new JobDataMap();
                //jobData.Add("jobData", item);

                //ITrigger trigger = TriggerBuilder.Create()
                //    .WithDailyTimeIntervalSchedule
                //      (s =>
                //         s.WithIntervalInSeconds(30)
                //        .OnEveryDay()
                //        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(item.StartTime.Hour, item.StartTime.Minute))
                //      ).UsingJobData(jobData)
                //    .Build();

                //scheduler.ScheduleJob(job, trigger);
           // }
            
            

        }
    }

}
