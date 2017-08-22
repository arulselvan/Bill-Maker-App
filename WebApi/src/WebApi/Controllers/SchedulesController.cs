namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        [HttpGet]
        public IEnumerable<Schedule> Get()
        {
            var viewModel = new List<Schedule> {
                new Schedule
                {
                    attendees = new int[]{1,2,5,34,76},
                    creatorId = 231123,
                    creator = "test",
                    dateCreated = DateTime.Now,
                    dateUpdated = DateTime.Now,
                    description = "test desc",
                    id = 4343,
                    location = "test",
                    status = "Active",
                    timeEnd = DateTime.Now.AddDays(1),
                    timeStart = DateTime.Now.AddDays(-3),
                    title = "test title",
                    type = "Software",
                }
            };
            return viewModel;
        }
    }
    
    public class Schedule
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }
        public string creator { get; set; }
        public int creatorId { get; set; }
        public int[] attendees { get; set; }
    }
}
