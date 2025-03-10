using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_InefableMedia.Repositorios
{
    interface interfaz<T>{

        T find(int id);
        List<T> findAll();
        bool guardar(T model);
        bool guardar(List<T> models);
        bool actualizar(T model);
        bool borrar(T model);
    }
}
