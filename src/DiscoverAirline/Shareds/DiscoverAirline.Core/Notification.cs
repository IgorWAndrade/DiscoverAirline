using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscoverAirline.Core
{
    public class Notification
    {
        private string Message { get; set; }
        private object Data { get; set; }
        private List<string> Errors { get; set; } = new List<string>();

        public Notification()
        {
            Errors.Clear();
        }
        public string Get()
        {
            if (IsValid())
            {
                return JsonConvert.SerializeObject(
                    new
                    {
                        Message = Message,
                        Data = Data
                    });
            }
            return JsonConvert.SerializeObject(
                    new
                    {
                        Errors = GetErrors()
                    });
        }

        public List<string> GetErrors() => Errors.ToList();

        public void SetMessage(string message) => Message = message;

        public void SetData(object result) => Data = result;

        public void AddError(string erro)
        {
            Errors.Add(erro);
        }

        public bool IsValid()
        {
            return !GetErrors().Any();
        }

        public static Notification Create(object data)
        {
            var result = new Notification();
            result.SetData(data);

            return result;
        }

        public static Notification Create() => new Notification();
    }
}
