using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ListViews.ModelView
{
    public class Empleados: BaseModel
    {
        public Empleados()
        {
        }

            public string Nombre { get; set; }
            public string Profesion { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Image { get; set; }
            public Double Sueldo { get; set; }
    }
}

