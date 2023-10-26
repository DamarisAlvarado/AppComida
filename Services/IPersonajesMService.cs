using AppComida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppComida.Services
{
    public interface  IPersonajesMService
    {
        public Task<List<Personajes>> Obtener();
  
    }
}
