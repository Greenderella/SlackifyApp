using SlackifyApp.Models;
using System.Collections.Generic;

namespace SlackifyApp.Controllers
{
    public class Db
    {
        private List<SlackifyConfiguration> _lista;

        public Db()
        {
            _lista = new List<SlackifyConfiguration>();
        }

        internal void Save(SlackifyConfiguration param)
        {
            _lista.Add(param);
        }

        internal dynamic Cantidad()
        {
            return _lista.Count;
        }
    }
}