using DATOS;
using ENTIDADES;
using System.Collections.Generic;

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
