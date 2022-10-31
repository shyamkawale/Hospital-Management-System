using System;
namespace HospitalManagement.Models
{
    public class ResponseStatus<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<T> Records { get; set; } = null;
        public T Record { get; set; }
    }
}

