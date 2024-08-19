using EventManagement.Domain;
using Microsoft.Identity.Client;

namespace EventManagement.API.Models
{
    public class SearchEventsRequest
    {
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public string Category { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }

    public class AddEventRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; } = TimeSpan.Zero;
        public int VenueId { get; set; }
    }

    public class EditEventRequest
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; } = TimeSpan.Zero;
        public int VenueId { get; set; }
        public string Status { get; set; }
    }

    public class DeleteEventRequest
    {
        public int EventId { get; set; }       
    }

}
