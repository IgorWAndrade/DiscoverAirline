using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscoverAirline.Core
{
    public class Notification
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        };
        private string Message { get; set; }
        private object Data { get; set; }
        private List<string> Errors { get; set; } = new List<string>();

        public Notification()
        {
            Errors.Clear();
        }

        public object Get()
        {
            if (IsValid())
            {
                return Data;
            }
            else
            {
                return GetErrors();
            }
        }

        public object GetData() => Data;

        public List<string> GetErrors() => Errors.ToList();

        public void SetMessage(string message) => Message = message;

        public void SetData(object result) => Data = result;

        public void SetDataList(IEnumerable<object> response)
        {
            var list = new List<object>();

            foreach (var item in response)
            {
                var obj = new
                {
                    Id = item.GetType().GetProperty("Id").GetValue(item, null),
                    Name = item.GetType().GetProperty("Name").GetValue(item, null),
                };
                list.Add(obj);
            }

            SetData(list);
        }

        public void AddError(string erro)
        {
            Errors.Add(erro);
        }

        public bool IsValid()
        {
            return !GetErrors().Any();
        }

        public static Notification Create(object data = null)
        {
            var result = new Notification();
            result.SetData(data);

            return result;
        }

        public static Notification Create(IEnumerable<object> response)
        {
            var result = new Notification();
            result.SetDataList(response);

            return result;
        }

    }
}
