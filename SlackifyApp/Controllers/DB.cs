using System;
using SlackifyApp.Models;
using System.Collections.Generic;

namespace SlackifyApp.Controllers
{
    public class DB
    {
        private List<SlackifyConfiguration> lista;

        public DB()
        {
            lista = new List<SlackifyConfiguration>();
        }

        internal void save(SlackifyConfiguration param)
        {
            lista.Add(param);
        }

        internal dynamic cantidad()
        {
            return lista.Count;
        }
    }
}