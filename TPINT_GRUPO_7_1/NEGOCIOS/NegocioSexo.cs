using ENTIDADES;
using DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioSexo
    {
        private DaoSexo ltSexo = new DaoSexo();

        // Obtengo la lista de dias de atencion llamando al metodo ObtenerSexo de DaoSexo
        public List<Sexo> ObtenerSexo()
        {
            return ltSexo.ObtenerSexo();
        }
    }
}
