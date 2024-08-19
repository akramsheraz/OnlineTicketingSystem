using BuildingBlocks.APIModels;
using EventManagement.API.Models;
using EventManagement.Application.Commands;
using EventManagement.Application.Queries;
using EventManagement.Domain;
using MediatR;

namespace EventManagement.API.Services
{
    public class EventService
    {
        private readonly ILogger<EventService> _logger;
        private readonly ISender _sender;
        
        public EventService(ILogger<EventService> logger, ISender sender)
        {
            _logger = logger;
            this._sender = sender;         
        }
        public GetEventsResponse GetEvents(SearchEventsRequest eventRquest)
        {
            GetEventsResponse apiResponse = new GetEventsResponse();
            try
            {
                GetEventsQuery query = new GetEventsQuery();
                var response = _sender.Send(query);
                
                if (response.Result != null)
                {
                    if (response.Result.Count > 0)
                    {
                        List<Event> filteredEvents = response.Result;

                        if (!string.IsNullOrEmpty(eventRquest.Title))
                            filteredEvents = filteredEvents.Where(a => a.Title.Contains(eventRquest.Title)).ToList();

                        if (eventRquest.StartDate > DateTime.MinValue)
                            filteredEvents = filteredEvents.Where(a => a.Date > eventRquest.StartDate).ToList();

                        if (eventRquest.EndDate > DateTime.MinValue)
                            filteredEvents = filteredEvents.Where(a => a.Date < eventRquest.EndDate).ToList();


                        if (!string.IsNullOrEmpty(eventRquest.Category))
                            filteredEvents = filteredEvents.Where(a => a.Category.Contains(eventRquest.Category)).ToList();


                        apiResponse.events = filteredEvents;
                        apiResponse.Code = "200";
                        apiResponse.Message = "success";
                    }
                    else
                    {
                        apiResponse.Code = "400";
                        apiResponse.Message = "events information does not exits";
                    }
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "events information does not exits";
                }

            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


        public APIResponse AddEvent(AddEventRequest objEventRequest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                CreateEventCommand command = new CreateEventCommand();

                Event newEvent = new Event()
                {
                    Title = objEventRequest.Title,
                    Description = objEventRequest.Description,
                    Category= objEventRequest.Category,
                    Date= objEventRequest.Date,
                    VenueId= objEventRequest.VenueId,
                    Status ="active"
                };

                command.objEvent = newEvent;
                var response = _sender.Send(command);

                if (response.Result != null)
                {
                    apiResponse.Code = "200";
                    apiResponse.Message = "success";
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "events information does not exits";
                }

            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


        public APIResponse EditEvent(EditEventRequest objEventRequest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                // check event already exists or not

                GetEventByIdQuery query = new GetEventByIdQuery(objEventRequest.EventId);
                var queryResponse = _sender.Send(query);

                if (queryResponse.Result != null)
                {
                    Event updatedEvent = new Event()
                    {
                        EventId = objEventRequest.EventId,
                        Title = objEventRequest.Title,
                        Description = objEventRequest.Description,
                        Category = objEventRequest.Category,
                        Date = objEventRequest.Date,
                        VenueId = objEventRequest.VenueId,
                        Status = objEventRequest.Status
                    };

                    UpdateEventCommand command = new UpdateEventCommand();
                    command.updateEvent = updatedEvent;
                    var commandResponse = _sender.Send(command);

                    if (commandResponse.Result != null)
                    {
                        apiResponse.Code = "200";
                        apiResponse.Message = "success";
                    }
                    else
                    {
                        apiResponse.Code = "400";
                        apiResponse.Message = "events information does not exits";
                    }
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "events information does not exits";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


        public APIResponse DeleteEvent(int eventId)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                // check event already exists or not

                GetEventByIdQuery query = new GetEventByIdQuery(eventId);
                var queryResponse = _sender.Send(query);

                if (queryResponse.Result != null)
                {  
                    DeleteEventCommand command = new DeleteEventCommand(eventId);                    
                    var commandResponse = _sender.Send(command);

                    if (commandResponse.Result != null)
                    {
                        apiResponse.Code = "200";
                        apiResponse.Message = "success";
                    }
                    else
                    {
                        apiResponse.Code = "400";
                        apiResponse.Message = "events information does not exits";
                    }
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "events information does not exits";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


    }
}
